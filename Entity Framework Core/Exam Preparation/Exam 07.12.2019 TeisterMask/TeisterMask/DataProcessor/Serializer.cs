namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var targetProjects = context.Projects
                .ToList()
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectWithTasksDto
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate =  p.DueDate == null || p.DueDate.Value.Year == 1 ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new ExportTaskDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    }).OrderBy(t=> t.Name).ToArray()
                })
                .OrderByDescending(p=> p.TasksCount)
                .ThenBy(p=> p.ProjectName)
                .ToList();
            var resultXml = XmlConverter.Serialize(targetProjects, "Projects");
            return resultXml;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var givenDateFormat = DateTime.ParseExact(date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var targetEmployees = context.Employees
                .ToList()
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(t => t.Task.OpenDate >= date)
                    .OrderByDescending(t => t.Task.DueDate)
                    .ThenBy(t => t.Task.Name)
                    .Select(t => new
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString()
                    }).ToList()
                })
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .Take(10)
                .ToList();
            var jsonResult = JsonConvert.SerializeObject(targetEmployees, Formatting.Indented);
            return jsonResult;
        }
    }
}