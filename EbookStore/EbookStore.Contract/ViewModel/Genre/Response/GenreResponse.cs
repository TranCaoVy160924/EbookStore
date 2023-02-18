using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Genre.Response;
public class GenreResponse
{
    public int GenreId { get; set; }
    public string Name { get; set; }
    public bool IsChecked { get; set; } = false;
}
