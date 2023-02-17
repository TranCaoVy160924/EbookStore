using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Utilities;
internal static class PaginatorExtension
{
    public static async Task<PagedList<T>> PaginateResultAsync<T>(
        this IQueryable<T> query, QueryStringParameters queryParams)
    {
        return await PagedList<T>.ToPagedListAsync(query, queryParams.PageNumber, queryParams.PageSize);
    }

    public static PagedList<Dest> MapResultToResponse<Src, Dest>(
        this PagedList<Src> result, IMapper mapper)
    {
        return result.Convert<Dest>(mapper.Map<List<Dest>>(result.Data));
    }
}
