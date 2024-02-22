using System.ComponentModel.DataAnnotations;

namespace FlightsAggregator.Business.Entities
{
    public class Passenger
    {
        [Required]
        [MaxLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public required string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public required string PassportSeries { get; set; }

        [Required]
        [MaxLength(20)]
        public required string PassportNumber { get; set; }

        [Required]
        public required string Citizenship { get; set; }
    }
}