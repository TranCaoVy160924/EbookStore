﻿using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Genre.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Presentation.RefitClient;
public interface IGenreClient
{
    [Get("/Genre")]
    Task<List<GenreResponse>> GetAsync();
}
