using System.ComponentModel.DataAnnotations;

namespace FlightsAggregator.Business.Helpers
{
    public class NotPastDateAttribute : ValidationAttribute
    {
        public NotPastDateAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;

            if (DateTime.Compare(((DateTime)value).Date, DateTime.Today) < 0)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success!;
        }
    }
}
