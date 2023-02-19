using EbookStore.Contract.ViewModel.Sale.Response;
﻿using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Contract.ViewModel.Sale.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.SaleRepo;
public interface ISaleRepository
{
    Task <SaleDetailResponse> GetOneAsync(int saleId);
    Task CreateBookSaleAsync(SaleCreateRequest createRequest);

    Task UpdateExtendSaleAsync(SaleExtendRequest saleExtendRequest);
}
