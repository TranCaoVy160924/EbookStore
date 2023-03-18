using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Book.Request;
public class BookUpdateRequest
{
    [Required(ErrorMessage = "Book id is required")]
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 4, ErrorMessage = "Book title must be between 4 and 50 characters!")]
    [Required(ErrorMessage = "Please enter book title")]
    public string Title { get; set; }


    [Range(1, int.MaxValue, ErrorMessage = "Book must have atleast 1 page")]
    [Required(ErrorMessage = "Please enter number of page")]
    public int NumberOfPage { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Book price must more than 0")]
    [Required(ErrorMessage = "Please enter book price")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Please enter book description")]
    public string Description { get; set; }

    [Url]
    [Required(ErrorMessage = "Please enter book cover image")]
    public string CoverImage { get; set; }

    public string PdfLink { get; set; } = String.Empty;

    //public string EpubLink { get; set; } = String.Empty;

    public List<int> BookGenreIds { get; set; } = new List<int>();
}
