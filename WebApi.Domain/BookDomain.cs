using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Business;
using WebApi.Models;

namespace WebApi.Domain
{
    public class BookDomain
    {
        public IEnumerable<BookModel> ListBooks()
        {
            try
            {
                return Book.ListBooks();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int InsertBooks(BookModel bookModel)
        {
            try
            {
                return Book.InsertBooks(bookModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int UpdateBooks(int id, BookModel bookModel)
        {
            try
            {
                return Book.UpdateBooks(id, bookModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DeleteBooks(int id)
        {
            try
            {
                return Book.DeleteBooks(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DeleteBooksLogic(int id)
        {
            try
            {
                return Book.DeleteBooksLogic(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
