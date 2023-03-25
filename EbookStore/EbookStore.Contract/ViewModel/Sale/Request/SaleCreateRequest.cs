using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Sale.Request;
public class SaleCreateRequest: IValidatableObject
{
    [StringLength(50, MinimumLength = 4, ErrorMessage = "Sale name must be between 4 and 50 characters!")]
    [Required(ErrorMessage = "Please enter sale name")]
    public string Name { get; set; }

    [Range(1, 100, ErrorMessage = "Sale percent must be between 1 and 100!")]
    [Required(ErrorMessage = "Please enter sale percent")]
    public double SalePercent { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter sale start date")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter sale end date")]
    public DateTime EndDate { get; set; }

    public List<int> BookIds { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndDate <= DateTime.Now || StartDate <= DateTime.Today)
        {
            yield return new ValidationResult("Date must be later than today");
        }
        if (EndDate <= StartDate)
        {
            yield return new ValidationResult("End date must be later than start date");
        }

        // other validation conditions
    }
}
