using EbookStore.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.BookRepo;
public static class BookQueryExtension
{
    public static IQueryable<Book> QueryTitle(this IQueryable<Book> query, string title)
    {
        return query.Where(b => b.Title.Contains(title));
    }

    public static IQueryable<Book> QueryGenres(this IQueryable<Book> query, List<int> genres)
    {
        return query.Where(b => b.BookGenres.Any(bg => genres.Contains(bg.GenreId))); ;
    }

    public static IQueryable<Book> QueryReleaseDate(
        this IQueryable<Book> query, DateTime start, DateTime end)
    {
        return query.Where(b => DateTime.Compare(b.ReleaseDate, start) > 0
            && DateTime.Compare(b.ReleaseDate, end) < 0);
    }
}
