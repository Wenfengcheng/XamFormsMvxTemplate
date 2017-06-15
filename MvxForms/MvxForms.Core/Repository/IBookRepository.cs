using MvxForms.Core.Model;
using System.Collections.Generic;

namespace MvxForms.Core.Repository
{
    public interface IBookRepository
    {
        IEnumerable<BookModel> GetBooks();
        bool AddBook(string title, string description);
    }
}