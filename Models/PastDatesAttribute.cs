using System;
using System.ComponentModel.DataAnnotations;

public class PastDatesAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Your birthdate must be in the past!");
        
        }
    return ValidationResult.Success;
}
}