using FlightsAggregator.Business.Helpers;
using System.ComponentModel.DataAnnotations;

namespace FlightsAggregator.Business.Entities
{
    public class SearchFlightRequestFilters
    {
        [Required]
        public required string DepartureCity { get; set; }

        [Required]
        public required string DestinationCity { get; set; }

        [Required]
        [NotPastDate]
        public DateTime Date { get; set; }

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }

        public int? LayoversCount { get; set; }

        public string? AirLine { get; set; }

        public bool? LuggageIncluded { get; set; }
    }
}