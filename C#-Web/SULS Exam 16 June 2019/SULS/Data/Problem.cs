using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SULS.Data
{
    public class Problem
    {
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name  { get; set; }

        [Required]
        public int Points { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
