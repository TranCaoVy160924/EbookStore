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

namespace EbookStore.Client.RefitClient;

    [Headers("Content-Type: application/json")]
    public interface ISaleClient
    {
        [Post("/Sale/Search")]
        Task<ApiResponse<List<SaleResponse>>> GetResponseAsync([Body] SaleQueryRequest queryRequest,
            [Header("Authorization")] string jwtToken);

    }
