using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Contract.ViewModel.Sale.Response;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Presentation.RefitClient;

[Headers("Content-Type: application/json")]
public interface ISaleClient
{
    [Get("/Sale")]
    Task<ApiResponse<List<SaleResponse>>> GetResponseAsync([Body] SaleQueryRequest queryRequest,
        [Header("Authorization")] string jwtToken);

    [Post("/Sale")]
    Task SaleExtenedAsync([Body] SaleExtendRequest extendRequest,
        [Header("Authorization")] string jwtToken);
    
}
