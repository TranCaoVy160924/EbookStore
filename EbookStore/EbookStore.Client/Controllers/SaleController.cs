namespace EbookStore.Client.Controllers;

using EbookStore.Client.RefitClient;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Contract.ViewModel.Sale.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;

public class SaleController: Controller
{   
    public readonly ISaleClient _saleClient;
    private readonly string _jwtToken;
    private PaginationHeader PaginationMetadata;

    public List<SaleResponse> Data { get; private set; }
    
    private async Task LoadSaleData(SaleQueryRequest saleQueryRequest)
    {
        ApiResponse<List<SaleResponse>> response
        = await _saleClient.GetResponseAsync(saleQueryRequest, _jwtToken);
        string headerString = await response.GetPaginationHeader();
        PaginationMetadata = JsonConvert.DeserializeObject<PaginationHeader>(headerString);
        Data = response.ReadResult();
    }
    public IActionResult Index(ISaleClient saleClient) {

        return View();
    }

}
