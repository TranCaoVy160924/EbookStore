using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Sale.SaleResponse;
public class SaleResponse
{
    public int SaleId { get; set; }
    public string Name { get; set; }
    public double SalePercent { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
