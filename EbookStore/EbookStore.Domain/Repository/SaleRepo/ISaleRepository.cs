using EbookStore.Contract.ViewModel.Sale.Response;
﻿using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Contract.ViewModel.Sale.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbookStore.Contract.ViewModel.Pagination;

namespace EbookStore.Domain.Repository.SaleRepo;
public interface ISaleRepository
{
    Task <SaleDetailResponse> GetOneAsync(int saleId);
    Task CreateAsync(SaleCreateRequest createRequest);
    Task<PagedList<SaleResponse>> GetSalesAsync(SaleQueryRequest queryRequest);

    Task UpdateExtendSaleAsync(SaleExtendRequest saleExtendRequest);
}
