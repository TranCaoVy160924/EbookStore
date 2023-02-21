using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Pagination;

public abstract class QueryStringParameters
{
    const int maxPageSize = 50;
    
    [Range(1, double.MaxValue, ErrorMessage = "Page number must greater than 0")]
    public int PageNumber { get; set; } = 1;


    private int _pageSize = 10;

    [Range(1, 50, ErrorMessage = "Page size must be between 1 and 50")]
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}