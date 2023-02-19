using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Contract.ViewModel.Book.Response;
using EbookStore.Contract.ViewModel.Genre.Response;
using EbookStore.Presentation.RefitClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EbookStore.Presentation.View.Pages;

/// <summary>
/// Interaction logic for BookUpdatePage.xaml
/// </summary>
public partial class BookUpdatePage : Page
{
    private readonly MainWindow _mainWindow;
    private readonly IBookClient _bookClient;
    private readonly IGenreClient _genreClient;
    private readonly string _jwtToken;

    private BookDetailResponse OriginalBook;
    public BookUpdateRequest UpdateRequest { get; set; }
    public List<GenreResponse> GenreChoices { get; private set; }

    public BookUpdatePage(
        IBookClient bookClient,
        IGenreClient genreClient)
    {
        _mainWindow = App.Current.MainWindow as MainWindow;
        _bookClient = bookClient;
        _genreClient = genreClient;
        _jwtToken = _mainWindow.JwtToken;

        InitializeComponent();
    }

    public async Task SetOriginalBook(int id)
    {
        OriginalBook = await _bookClient.GetOneAsync(id);
        UpdateRequest = new BookUpdateRequest
        {
            Id = OriginalBook.BookId,
            Title = OriginalBook.Title,
            NumberOfPage = OriginalBook.NumberOfPage,
            Price = OriginalBook.Price,
            Description = OriginalBook.Description,
            CoverImage = OriginalBook.CoverImage,
            PdfLink = OriginalBook.PdfLink,
            EpubLink = OriginalBook.EpubLink,
            BookGenreIds = OriginalBook.BookGenreIds
        };

        this.DataContext = UpdateRequest;
        await LoadGenreData();
    }

    private async Task LoadGenreData()
    {
        GenreChoices = await _genreClient.GetAsync();
        GenreChoices.ForEach(g =>
        {
            if (UpdateRequest.BookGenreIds.Contains(g.GenreId))
            {
                g.IsChecked = true;
            }
        });
        ChooseGenre_ComboBox.ItemsSource = GenreChoices;
        ChooseGenre_ComboBox.Items.Refresh();
    }

    private void Cancel_Button_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.ToHomePage();
    }
}
