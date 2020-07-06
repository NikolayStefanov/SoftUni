using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        [Required, ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [Required, ForeignKey("Medicament")]
        public int MedicamentId { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}
