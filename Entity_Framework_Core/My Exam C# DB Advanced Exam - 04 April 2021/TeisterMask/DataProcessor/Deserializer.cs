namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var projects = new List<Project>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectImportDto[]), new XmlRootAttribute("Projects"));

            var projectsDtos = (ProjectImportDto[])xmlSerializer.Deserialize(new StringReader(xmlString));


            foreach (var xmlProject in projectsDtos)
            {
                DateTime openDate;
                bool isDateValid = DateTime.TryParseExact(xmlProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!IsValid(xmlProject) || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidDueDate = DateTime.TryParseExact(xmlProject.DueDate,
                     "dd/MM/yyyy",
                     CultureInfo.InvariantCulture,
                     DateTimeStyles.None,
                     out DateTime dueDate);

                var project = new Project
                {
                    Name = xmlProject.Name,
                    OpenDate = openDate,
                    DueDate = isValidDueDate ? (DateTime?)dueDate : null,
                };

                foreach (var xmlTask in xmlProject.Tasks)
                {
                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact(xmlTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact(xmlTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!IsValid(xmlTask) ||
                        !isTaskOpenDateValid ||
                        !isTaskDueDateValid ||
                        taskOpenDate < openDate ||
                        taskDueDate > dueDate
                        )
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(new Task
                    {
                        Name = xmlTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)xmlTask.ExecutionType,
                        LabelType = (LabelType)xmlTask.LabelType,
                    });
                }

                projects.Add(project);

                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var employees = new List<Employee>();

            var jsonEmployeesDtos = JsonConvert.DeserializeObject<EmployeeJsonImportDto[]>(jsonString);

            var dbTaskIds = context.Tasks.Select(t => t.Id).ToList();

            foreach (var jsonEmployee in jsonEmployeesDtos)
            {
                if (!IsValid(jsonEmployee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = jsonEmployee.Username,
                    Email = jsonEmployee.Email,
                    Phone = jsonEmployee.Phone,
                };

                foreach (var jsonTask in jsonEmployee.Tasks.Distinct())
                {
                    if (!dbTaskIds.Contains(jsonTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    { TaskId = jsonTask });
                }

                employees.Add(employee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));

                context.Employees.Add(employee);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}