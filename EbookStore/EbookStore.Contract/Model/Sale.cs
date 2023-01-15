using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.Model
{
    public class Sale
    {
        public int SaleID { get; set; }
        public string Name { get; set; }
        public double SalePercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Book> OnSaleBooks { get; set; }
    }
}
