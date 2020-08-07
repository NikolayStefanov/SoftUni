namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var outputResult = new StringBuilder();
            var validProjectsToAdd = new List<Project>();
            var datetimeDefaulValue = default(DateTime);

            var projectsDtos = XmlConverter.Deserializer<ImportProjectDto>(xmlString, "Projects");

            foreach (var projectDto in projectsDtos)
            {
                if (!IsValid(projectDto))
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }
                var projectOpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                DateTime dueDateToAdd;
                var projectDueDate = DateTime.TryParseExact
                    (
                    projectDto.DueDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dueDateToAdd
                    );
                if (projectDto.DueDate != null && projectDto.DueDate != "" && projectOpenDate > dueDateToAdd)
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }

                var newProject = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = dueDateToAdd
                };

                foreach (var taskDto in projectDto.Tasks)
                {

                    if (!IsValid(taskDto) ||
                        !Enum.IsDefined(typeof(ExecutionType), taskDto.ExecutionType) ||
                        !Enum.IsDefined(typeof(LabelType), taskDto.LabelType))
                    {
                        outputResult.AppendLine(ErrorMessage);
                        continue;
                    }
                    var taskOpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (taskOpenDate < newProject.OpenDate)
                    {
                        outputResult.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (newProject.DueDate != datetimeDefaulValue && taskDueDate > newProject.DueDate)
                    {
                        outputResult.AppendLine(ErrorMessage);
                        continue;
                    }
                    var newTask = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };
                    newProject.Tasks.Add(newTask);
                }

                validProjectsToAdd.Add(newProject);
                outputResult.AppendLine(string.Format(SuccessfullyImportedProject, newProject.Name, newProject.Tasks.Count));
            }
            context.Projects.AddRange(validProjectsToAdd);
            context.SaveChanges();

            return outputResult.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var outputResult = new StringBuilder();
            var validEmployeesToAdd = new List<Employee>();

            var importEmployeesDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            foreach (var employeeDto in importEmployeesDtos)
            {
                var uniqueTasks = employeeDto.Tasks.Distinct();

                if (!IsValid(employeeDto))
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }
                var newEmployee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,

                };
                foreach (var taskId in uniqueTasks)
                {
                    if (context.Tasks.All(t=> t.Id != taskId))
                    {
                        outputResult.AppendLine(ErrorMessage);
                        continue;
                    }
                    newEmployee.EmployeesTasks.Add(new EmployeeTask { Employee = newEmployee, TaskId = taskId });
                }
                outputResult.AppendLine(string.Format(SuccessfullyImportedEmployee, newEmployee.Username, newEmployee.EmployeesTasks.Count));
                validEmployeesToAdd.Add(newEmployee);
            }
            context.Employees.AddRange(validEmployeesToAdd);
            context.SaveChanges();
            return outputResult.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}