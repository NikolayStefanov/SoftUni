using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectDto
    {
        [Required, MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public virtual TaskDto[] Tasks { get; set; }
    }
    
    [XmlType("Task")]
    public class TaskDto
    {
        [Required, MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        [Required]
        public int ExecutionType { get; set; }

        [Required]
        public int LabelType { get; set; }
    }
}
