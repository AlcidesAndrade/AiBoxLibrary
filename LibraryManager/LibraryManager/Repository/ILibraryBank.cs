using LibraryManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Repository
{
    public interface ILibraryBank
    {
        int Add(Book book);
        List<Book> GetBooks();
        Book Get(int id);
        int Edit(Book book);
        int Delete(int id);
    }
}
