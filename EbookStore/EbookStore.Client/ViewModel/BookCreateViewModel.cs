using System.ComponentModel.DataAnnotations;

namespace EbookStore.Client.ViewModel;

public class BookCreateViewModel
{
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

    [Required(ErrorMessage = "Please enter book cover image")]
    public IFormFile CoverImage { get; set; }

    public IFormFile PdfFile { get; set; }

    //public IFormFile EpubFile { get; set; }

    public List<int> BookGenreIds { get; set; } = new List<int>();
}
