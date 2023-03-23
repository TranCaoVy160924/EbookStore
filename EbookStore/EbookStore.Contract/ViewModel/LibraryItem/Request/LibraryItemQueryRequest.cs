using EbookStore.Contract.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.LibraryItem.Request;
public class LibraryItemQueryRequest : QueryStringParameters
{
    public string? Title { get; set; } = "";
}
