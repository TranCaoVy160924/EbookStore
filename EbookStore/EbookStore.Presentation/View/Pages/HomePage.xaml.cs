using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Genre.Response;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Presentation.RefitClient;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
using static EbookStore.Presentation.RefitClient.RefitExtensions;

namespace EbookStore.Presentation.View.Pages;
/// <summary>
/// Interaction logic for HomePage.xaml
/// </summary>
public partial class HomePage : Page
{
    private readonly MainWindow _mainWindow;
    private readonly IBookClient _bookClient;
    private readonly IGenreClient _genreClient;
    private readonly string _jwtToken;
    private readonly string _originalToken;
    private PaginationHeader PaginationMetadata;
    private bool IsAdmin;

    public List<BookResponse> Data { get; private set; }
    public List<GenreResponse> GenreChoices { get; private set; }

    public HomePage(IBookClient bookClient, IGenreClient genreClient)
    {
        InitializeComponent();
        _mainWindow = Application.Current.MainWindow as MainWindow;
        _bookClient = bookClient;
        _genreClient = genreClient;
        _jwtToken = _mainWindow.JwtToken;
        _originalToken = _mainWindow.OriginalToken;

        StartDate_DatePicker.DisplayDate = DateTime.MinValue;
        EndDate_DatePicker.DisplayDate = DateTime.MaxValue;
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await LoadBookData(new BookQueryRequest());
            await LoadGenreData();
            CheckAuthority();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task LoadBookData(BookQueryRequest queryRequest)
    {
        ApiResponse<List<BookResponse>> response
            = await _bookClient.GetResponseAsync(queryRequest, _jwtToken);
        string headerString = await response.GetPaginationHeader();
        PaginationMetadata = JsonConvert.DeserializeObject<PaginationHeader>(headerString);
        Data = response.ReadResult();
        RefreshList();
    }

    private async Task LoadGenreData()
    {
        GenreChoices = await _genreClient.GetAsync();
        ChooseGenre_ComboBox.ItemsSource = GenreChoices;
        ChooseGenre_ComboBox.Items.Refresh();
    }

    private void RefreshList()
    {
        BookList.ItemsSource = Data;
        BookList.Items.Refresh();

        if (PaginationMetadata.HasNext)
        {
            NextPage_Button.IsEnabled = true;
        }
        else
        {
            NextPage_Button.IsEnabled = false;
        }

        if (PaginationMetadata.HasPrevious)
        {
            PreviousPage_Button.IsEnabled = true;
        }
        else
        {
            PreviousPage_Button.IsEnabled = false;
        }
    }

    private async void Search_Button_Click(object sender, RoutedEventArgs e)
    {
        await LoadBookData(GetQueryRequest());
    }

    private BookQueryRequest GetQueryRequest()
    {
        BookQueryRequest queryRequest = new BookQueryRequest();
        if (!String.IsNullOrEmpty(Title_TextBox.Text))
        {
            queryRequest.Title = Title_TextBox.Text;
        }
        if (StartDate_DatePicker.DisplayDate != DateTime.MinValue)
        {
            queryRequest.StartReleaseDate = StartDate_DatePicker.DisplayDate;
        }
        if (EndDate_DatePicker.DisplayDate != DateTime.MaxValue)
        {
            queryRequest.EndReleaseDate = EndDate_DatePicker.DisplayDate;
        }
        queryRequest.Genres.AddRange(GenreChoices.Where(g => g.IsChecked).Select(g => g.GenreId));

        return queryRequest;
    }

    private async void NextPage_Button_Click(object sender, RoutedEventArgs e)
    {
        BookQueryRequest queryRequest = GetQueryRequest();
        queryRequest.PageNumber = PaginationMetadata.CurrentPage + 1;
        await LoadBookData(queryRequest);
    }

    private async void PreviousPage_Button_Click(object sender, RoutedEventArgs e)
    {
        BookQueryRequest queryRequest = GetQueryRequest();
        queryRequest.PageNumber = PaginationMetadata.CurrentPage - 1;
        await LoadBookData(queryRequest);
    }

    private void AddBook_Button_Click(object sender, RoutedEventArgs e)
    {
        if (IsAdmin)
        {
            _mainWindow.ToBookCreatePage();
        }
    }

    private async void Edit_Button_Click(object sender, RoutedEventArgs e)
    {
        if (IsAdmin)
        {
            Button button = (Button)sender;
            BookResponse book = button.DataContext as BookResponse;

            try
            {
                await _mainWindow.ToBookUpdatePage(book.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private async void Delete_Button_Click(object sender, RoutedEventArgs e)
    {
        if (IsAdmin)
        {
            Button button = (Button)sender;
            BookResponse book = button.DataContext as BookResponse;

            ConfirmDeletionWindow confirmDelete = new ConfirmDeletionWindow();
            if (confirmDelete.ShowDialog() == true)
            {
                try
                {
                    await _bookClient.DeleteAsync(book.Id, _jwtToken);
                    await LoadBookData(new BookQueryRequest());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    private void CheckAuthority()
    {
        JwtSecurityToken secureToken;
        var handler = new JwtSecurityTokenHandler();
        secureToken = handler.ReadJwtToken(_originalToken); 
        if (secureToken.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value == "Admin")
        {
            IsAdmin = true;
        }
        else
        {
            IsAdmin = false;
        }

        string username = secureToken.Claims.Where(c => c.Type == ClaimTypes.Name).SingleOrDefault().Value;
        UserDisplay_TextBlock.Text = username + " - " + (IsAdmin ? "Admin" : "User");
    }
}
