using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Sale.SaleExtendRequest;
public class SaleExtendRequest
{
    [Required(ErrorMessage = "Please enter extended sale id")]
    public int SaleId { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter new sale end date")]
    public DateTime NewEndDate { get; set; }
}
