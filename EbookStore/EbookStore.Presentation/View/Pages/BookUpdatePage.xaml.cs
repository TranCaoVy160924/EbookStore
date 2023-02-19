using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Contract.ViewModel.Book.Response;
using EbookStore.Contract.ViewModel.Genre.Response;
using EbookStore.Presentation.RefitClient;
using EbookStore.Presentation.Validator.Models;
using EbookStore.Presentation.Validator;
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
            CoverImage = "https://stackoverflow.com/questions/2650144/multiline-for-wpf-textbox",
            PdfLink = "https://stackoverflow.com/questions/2650144/multiline-for-wpf-textbox",
            EpubLink = "https://stackoverflow.com/questions/2650144/multiline-for-wpf-textbox",
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

    private async void UpdateBook_Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            UpdateBook_Button.IsEnabled = false;
            if (ValidateCreateRequest())
            {
                UpdateRequest.Title = Title_TextBox.Text.Trim();
                UpdateRequest.NumberOfPage = int.Parse(NumOfPage_TextBox.Text.Trim());
                UpdateRequest.Price = double.Parse(Price_TextBox.Text.Trim());
                UpdateRequest.BookGenreIds
                    = GenreChoices.Where(g => g.IsChecked).Select(g => g.GenreId).ToList();
                UpdateRequest.Description = Description_TextBox.Text.Trim();
                await _bookClient.UpdateAsync(UpdateRequest, _jwtToken);

                _mainWindow.ToHomePage();
            }
        }
        catch(Exception ex)
        {
            ShowErrorMessage();
            Console.WriteLine(ex.Message);
        }
        finally
        {
            UpdateBook_Button.IsEnabled = true;
        }
    }

    private bool ValidateCreateRequest()
    {
        IErrorable createError = new BookCreateUpdateError
        {
            TitleValidity = Title_TextBox.ValidateValidStringLength(4, 50),
            NumberOfPageValidity = NumOfPage_TextBox.ValidatePositiveInt(),
            PriceValidity = Price_TextBox.ValidatePositiveDouble(),
            DescriptionValidity = Description_TextBox.ValidateHasInput(),
        };

        return createError.IsValid();
    }

    private void ShowErrorMessage()
    {
        UpdateError_TextBlock.Visibility = Visibility.Visible;
    }
}
