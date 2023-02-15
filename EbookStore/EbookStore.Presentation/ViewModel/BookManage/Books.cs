using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Presentation.ViewModel.BookManage;
public class Books: ObservableCollection<BookResponse>
{
}
