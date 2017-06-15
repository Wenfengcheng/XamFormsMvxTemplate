using MvvmCross.Plugins.Sqlite;
using MvxForms.Core.Model;
using System.Collections.Generic;

namespace MvxForms.Core.Repository
{
    public class BookRepository : BaseRepository<BookModel>, IBookRepository
    {
        public BookRepository(IMvxSqliteConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public IEnumerable<BookModel> GetBooks()
        {
            return GetAll();
        }

        public bool AddBook(string title, string description)
        {
            return Insert(new BookModel() { Title = title, Description = description }) != -1;
        }
    }
}