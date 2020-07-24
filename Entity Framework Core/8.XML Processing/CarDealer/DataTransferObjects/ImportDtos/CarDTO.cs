using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.ImportDtos
{
    [XmlType("Car")]
    public class CarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public int  TraveledDistance { get; set; }

        [XmlArray("parts")]
        public List<CarPartsDTO>  CarParts { get; set; }
    }

    [XmlType("partId")]
    public class CarPartsDTO
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }

    
}
