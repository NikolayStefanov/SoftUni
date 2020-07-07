namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [MaxLength(250)]
        public string Comments { get; set; }
        [Required, ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        
        [Required, ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor{ get; set; }
    }
}
