namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            var context = new SoftUniContext();

            //EXERCISE 1 - Database First
            var fullInformationsAboutEmployees = GetEmployeesFullInformation(context);
            Console.WriteLine(fullInformationsAboutEmployees);

            //EXERCISE 2 - Employees with Salary Over 50 000
            var employeesWithSalaryOver50000 = GetEmployeesWithSalaryOver50000(context);
            Console.WriteLine(employeesWithSalaryOver50000);

            //EXERCISE 3 - Employees from Research and Development
            var employeesFromResearchAndDevelopment = GetEmployeesFromResearchAndDevelopment(context);
            Console.WriteLine(employeesFromResearchAndDevelopment);

           //EXERCISE 4 - Adding a New Address and Updating Employee
            var resultEx4 = AddNewAddressToEmployee(context);
            Console.WriteLine(resultEx4);

           //EXERCISE 5 - Employees and Projects
            var resultEx5 = GetEmployeesInPeriod(context);
            Console.WriteLine(resultEx5);

          //EXERCISE 6 - Addresses by Town
            var resultEx6 = GetAddressesByTown(context);
            Console.WriteLine(resultEx6);

           //EXERCISE 7 - Employee 147
            var resultEx7 = GetEmployee147(context);
            Console.WriteLine(resultEx7);

            //EXERCISE 8 - Departments with More Than 5 Employees
            var resultEx8 = GetDepartmentsWithMoreThan5Employees(context);
            Console.WriteLine(resultEx8);

            //EXERCISE 9 - Find Latest 10 Projects
             var resultEx9 = GetLatestProjects(context);
            Console.WriteLine(resultEx9);

            //EXERCISE 10 - IncreaseSalaries
            var resultEx10 = IncreaseSalaries(context);
            Console.WriteLine(resultEx10);

           // EXERCISE 11 - Find Employees by First Name Starting With Sa
            var resultEx11 = GetEmployeesByFirstNameStartingWithSa(context);
            Console.WriteLine(resultEx11);

            //EXERCISE 12 - Delete Project by Id
            var resultEx12 = DeleteProjectById(context);
            Console.WriteLine(resultEx12);

            //EXERCISE 13 - Remove Town
            var resultEx13 = RemoveTown(context);
            Console.WriteLine(resultEx13);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employeesInfo = context.Employees.Select(x => new { x.EmployeeId, x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary }).OrderBy(x => x.EmployeeId).ToList();
            var result = new StringBuilder();
            foreach (var employee in employeesInfo)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return result.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employeesInfo = context.Employees.Where(x => x.Salary > 50000).Select(x => new { x.FirstName, x.Salary }).OrderBy(x => x.FirstName).ToList();
            var result = new StringBuilder();
            foreach (var employee in employeesInfo)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeesInfo = context.Employees.Join(context.Departments,
                                                       employee => employee.DepartmentId,
                                                       dep => dep.DepartmentId,
                                                       (employee, department) => new
                                                       {
                                                           FirstName = employee.FirstName,
                                                           LastName = employee.LastName,
                                                           Salary = employee.Salary,
                                                           DepartmentName = department.Name
                                                       })
                                                .Where(x => x.DepartmentName == "Research and Development")
                                                .OrderBy(x => x.Salary)
                                                .ThenByDescending(x => x.FirstName);
            var result = new StringBuilder();
            foreach (var employee in employeesInfo)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }
            return result.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
            context.Addresses.Add(newAddress);
            context.SaveChanges();
            var targetEmployee = context.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();
            targetEmployee.AddressId = newAddress.AddressId;
            context.SaveChanges();

            var allEmployeeAdresses = context.Employees.Join(context.Addresses,
                                                             employees => employees.AddressId,
                                                             address => address.AddressId,
                                                             (employee, address) => new
                                                             {
                                                                 AddressId = employee.AddressId,
                                                                 AddressText = address.AddressText
                                                             })
                                                        .OrderByDescending(x => x.AddressId)
                                                        .Take(10);
            var result = new StringBuilder();
            foreach (var adress in allEmployeeAdresses)
            {
                result.AppendLine(adress.AddressText);
            }
            return result.ToString().TrimEnd();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var targerEmployees = context.Employees
                                .Where(x => x.EmployeesProjects
                                            .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                                .Take(10)
                                .Select(x => new
                                {
                                    x.FirstName,
                                    x.LastName,
                                    ManagerFirstName = x.Manager.FirstName,
                                    ManagerLastName = x.Manager.LastName,
                                    Projects = x.EmployeesProjects
                                                        .Select(ep => new
                                                        {
                                                            ep.Project.Name,
                                                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"
                                                                                                             , CultureInfo.InvariantCulture),
                                                            EndDate = ep.Project.EndDate.HasValue
                                                                                        ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt"
                                                                                                            , CultureInfo.InvariantCulture)
                                                                                        : "not finished"
                                                        })
                                                        .ToList()
                                })
                                .ToList();
            var result = new StringBuilder();
            foreach (var employee in targerEmployees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.Projects)
                {
                    result.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                }
            }
            return result.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var targetAddresses = context.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    EmployeeCount = x.Employees.Count
                })
                .ToList();
            var result = new StringBuilder();
            foreach (var address in targetAddresses)
            {
                result.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }
            return result.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects.Select(p => new { p.Project.Name }).OrderBy(p => p.Name).ToList()
                })
                .First();
            var result = $"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}" + Environment.NewLine;
            foreach (var project in employee147.Projects)
            {
                result += $"{project.Name}" + Environment.NewLine;
            }

            return result.TrimEnd();

        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var targetDeps = context.Departments
                .Where(x => x.Employees.Count() > 5)
                .OrderBy(x => x.Employees.Count())
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees.Select(e => new
                    {
                        e.FirstName
                            ,
                        e.LastName
                            ,
                        e.JobTitle
                    }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList()
                })
                .ToList();
            var result = new StringBuilder();
            foreach (var dep in targetDeps)
            {
                result.AppendLine($"{dep.DepartmentName} - {dep.ManagerFirstName} {dep.ManagerLastName}");
                foreach (var employee in dep.Employees)
                {
                    result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }
            return result.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastTenProjects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new { x.Name, x.Description, StartDate = x.StartDate.ToString("M/d/yyyy h:mm:ss tt") })
                .OrderBy(x => x.Name)
                .ToList();
            var result = new StringBuilder();
            foreach (var project in lastTenProjects)
            {
                result.AppendLine(project.Name);
                result.AppendLine(project.Description);
                result.AppendLine(project.StartDate);
            }
            return result.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            decimal hireing = 1.12M;
            var targetEmployees = context.Employees.Where(x => x.Department.Name == "Engineering"
                                                         || x.Department.Name == "Tool Design"
                                                         || x.Department.Name == "Marketing"
                                                         || x.Department.Name == "Information Services").ToList();
            foreach (var employee in targetEmployees)
            {
                employee.Salary *= hireing;
            }
            context.SaveChanges();
            var employees = context.Employees.Where(x => x.Department.Name == "Engineering"
                                                         || x.Department.Name == "Tool Design"
                                                         || x.Department.Name == "Marketing"
                                                         || x.Department.Name == "Information Services")
                        .Select(x => new { x.FirstName, x.LastName, x.Salary })
                        .OrderBy(x => x.FirstName)
                        .ThenBy(x => x.LastName)
                        .ToList();
            var result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var targetEmpoyees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .ToList();
            if (!targetEmpoyees.Any())
            {
                return string.Empty;
            }
            var result = new StringBuilder();
            foreach (var employee in targetEmpoyees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }
            return result.ToString().TrimEnd();
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectsToDelete = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList();
            context.EmployeesProjects.RemoveRange(projectsToDelete);
            var targetProject = context.Projects.Where(x => x.ProjectId == 2).FirstOrDefault();
            context.Projects.Remove(targetProject);

            var takeProjects = context.Projects.Take(10).Select(x => new { x.Name }).ToList();
            var result = new StringBuilder();
            foreach (var proj in takeProjects)
            {
                result.AppendLine(proj.Name);
            }
            return result.ToString().TrimEnd();
        }
        public static string RemoveTown(SoftUniContext context)
        {
            var employeesInSeattle = context.Employees.Where(x => x.Address.Town.Name == "Seattle").ToList();
            foreach (var employee in employeesInSeattle)
            {
                employee.AddressId = null;
            }
            var countOfAddressesInSeattle = context.Addresses.Where(x => x.Town.Name == "Seattle").Count();
            var addressesToRemove = context.Addresses.Where(x => x.Town.Name == "Seattle").ToList();
            context.Addresses.RemoveRange(addressesToRemove);
            var targetCity = context.Towns.Where(x => x.Name == "Seattle").FirstOrDefault();
            context.Towns.Remove(targetCity);
            context.SaveChanges();
            return $"{countOfAddressesInSeattle} addresses in Seattle were deleted";
        }
    }
}
