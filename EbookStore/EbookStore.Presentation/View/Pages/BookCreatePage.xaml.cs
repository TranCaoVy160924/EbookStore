using EbookStore.Contract.ViewModel.Book.Request;
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
/// Interaction logic for BookCreatePage.xaml
/// </summary>
public partial class BookCreatePage : Page
{
    private readonly MainWindow _mainWindow;
    private readonly IBookClient _bookClient;
    private readonly IGenreClient _genreClient;
    private readonly string _jwtToken;

    public BookCreateRequest CreateRequest { get; set; }
    public List<GenreResponse> GenreChoices { get; private set; }

    public BookCreatePage(
        IBookClient bookClient,
        IGenreClient genreClient)
    {
        _mainWindow = App.Current.MainWindow as MainWindow;
        _bookClient = bookClient;
        _genreClient = genreClient;
        _jwtToken = _mainWindow.JwtToken;

        CreateRequest = new BookCreateRequest
        {
            CoverImage = "https://stackoverflow.com/questions/2650144/multiline-for-wpf-textbox",
            PdfLink = "https://stackoverflow.com/questions/2650144/multiline-for-wpf-textbox",
            EpubLink = "https://stackoverflow.com/questions/2650144/multiline-for-wpf-textbox"
        };
        this.DataContext = CreateRequest;

        InitializeComponent();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await LoadGenreData();
    }

    private void Cancel_Button_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.ToHomePage();
    }

    private async Task LoadGenreData()
    {
        GenreChoices = await _genreClient.GetAsync();
        ChooseGenre_ComboBox.ItemsSource = GenreChoices;
        ChooseGenre_ComboBox.Items.Refresh();
    }

    private async void AddBook_Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            AddBook_Button.IsEnabled = false;
            if (ValidateCreateRequest())
            {
                CreateRequest.Title = Title_TextBox.Text.Trim();
                CreateRequest.NumberOfPage = int.Parse(NumOfPage_TextBox.Text.Trim());
                CreateRequest.Price = double.Parse(Price_TextBox.Text.Trim());  
                CreateRequest.BookGenreIds 
                    = GenreChoices.Where(g => g.IsChecked).Select(g => g.GenreId).ToList();
                CreateRequest.Description = Description_TextBox.Text.Trim();
                await _bookClient.CreateAsync(CreateRequest, _jwtToken);

                _mainWindow.ToHomePage();
            }
        }
        catch
        {
            ShowErrorMessage();
        }
        finally
        {
            AddBook_Button.IsEnabled = true;
        }
    }

    private bool ValidateCreateRequest()
    {
        IErrorable createError = new BookCreateUpdateError
        {
            TitleValidity = Title_TextBox.ValidateValidStringLength(4, 50),
            NumberOfPageValidity = NumOfPage_TextBox.ValidatePositiveInt(),
            PriceValidity= Price_TextBox.ValidatePositiveDouble(),
            DescriptionValidity = Description_TextBox.ValidateHasInput(),
        };

        return createError.IsValid();
    }

    private void ShowErrorMessage()
    {
        CreateError_TextBlock.Visibility = Visibility.Visible;
    }
}
