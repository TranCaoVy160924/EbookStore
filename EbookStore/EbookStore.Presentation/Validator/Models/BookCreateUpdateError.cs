using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Presentation.Validator.Models;
public class BookCreateUpdateError: IErrorable
{
    public bool TitleValidity { get; set; }
    public bool NumberOfPageValidity { get; set; }
    public bool PriceValidity { get; set; }
    public bool DescriptionValidity { get; set; }

    public bool IsValid()
    {
        if (!TitleValidity ||
            !NumberOfPageValidity ||
            !PriceValidity ||
            !DescriptionValidity)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
