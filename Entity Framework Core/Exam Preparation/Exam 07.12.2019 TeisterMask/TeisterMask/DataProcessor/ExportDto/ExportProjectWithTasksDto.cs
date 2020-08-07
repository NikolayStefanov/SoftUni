using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectWithTasksDto
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public ExportTaskDto[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class ExportTaskDto
    {
        public string Name { get; set; }
        public string Label { get; set; }
    }
}
