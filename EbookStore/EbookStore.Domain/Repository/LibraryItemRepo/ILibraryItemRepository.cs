using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.LibraryItemRepo;
public interface ILibraryItemRepository
{
    Task AddBookToLibrarylistAsync(int bookId, Guid userId);
}
