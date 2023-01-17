using System.ComponentModel.DataAnnotations;

namespace EbookStore.Application;

public static class ValidateHelper
{
    public static bool Validate<T>(T target)
    {
        var context = new ValidationContext(target, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();

        return Validator.TryValidateObject(target, context, results, true);
    }
}
