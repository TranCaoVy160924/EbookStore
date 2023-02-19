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
}
