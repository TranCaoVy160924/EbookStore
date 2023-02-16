using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Pagination;

public class PagedList<T>
{
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public List<T> Data { get; set; }

    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Data = new List<T>();
        Data.AddRange(items);
    }
    public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }

    public PagedList<E> Convert<E>(List<E> items)
    {
        return new PagedList<E>(items, TotalCount, CurrentPage, PageSize);
    }

    public string GetMetadata()
    {
        var metadata = new PaginationHeader
        {
            TotalCount = TotalCount,
            PageSize = PageSize,
            CurrentPage = CurrentPage,
            TotalPages = TotalPages,
            HasNext = HasNext,
            HasPrevious = HasPrevious
        };

        return JsonConvert.SerializeObject(metadata);
    }
}
