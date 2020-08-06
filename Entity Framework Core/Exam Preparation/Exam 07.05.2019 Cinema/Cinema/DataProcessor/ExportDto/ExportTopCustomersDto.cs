using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ExportDto
{
    [XmlType("Customer")]
    public class ExportTopCustomersDto
    {
        [XmlAttribute]
        public string FirstName { get; set; }
        [XmlAttribute]
        public string LastName { get; set; }
        [XmlElement("SpentMoney")]
        public string SpentMoney { get; set; }
        [XmlElement("SpentTime")]
        public string SpentTime { get; set; }
    }
}
