using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Client.RefitClient;

public static class RefitExtensions
{
    public static async Task<string> GetPaginationHeader<T>(this ApiResponse<T> response)
    {
        if (response.IsSuccessStatusCode)
        {
            string paginationHeader = response.Headers.GetValues("X-Pagination").FirstOrDefault();
            return await Task.FromResult(paginationHeader);
        }
        else
        {
            throw new Exception(response.StatusCode.ToString());
        }
    }

    public static T ReadResult<T>(this ApiResponse<T> response)
    {
        if (response.IsSuccessStatusCode)
        {
            return response.Content;
        }
        else
        {
            throw new Exception(response.StatusCode.ToString());
        }
    }
}
