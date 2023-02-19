using EbookStore.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.SaleRepo;
public static class SaleQueryExtension
{
    public static IQueryable<Sale> QueryId(this IQueryable<Sale> query, int id)
    {
        return query.Where(x => x.SaleId == id);
    }
    public static IQueryable<Sale> QueryName(this IQueryable<Sale> query, string name)
    {
        return query.Where(s => s.Name.Contains(name));
    }
    public static IQueryable<Sale> QuerySaleDate(this IQueryable<Sale> query, DateTime start, DateTime end)
    {
        return query.Where(s => DateTime.Compare(s.StartDate, start) >= 0
            && DateTime.Compare(s.EndDate, end) <= 0);
    }
}
