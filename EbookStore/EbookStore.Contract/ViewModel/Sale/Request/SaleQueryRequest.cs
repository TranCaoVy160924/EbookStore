using EbookStore.Contract.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Sale.Request;
public class SaleQueryRequest : QueryStringParameters
{
    public string Name { get; set; } = "";
    public DateTime StartDate { get; set; } = DateTime.MinValue;
    public DateTime EndDate { get; set; } = DateTime.MaxValue;
}
