using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        [Required]
        public int ScoredGoals { get; set; }
        [Required]
        public int Assists { get; set; }
        [Required]
        public int MinutesPlayed { get; set; }
    }
}
