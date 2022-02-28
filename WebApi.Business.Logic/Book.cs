using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Access;
using WebApi.Models;

namespace WebApi.Data.Business
{
    public class Book
    {
        public static IEnumerable<BookModel> ListBooks()
        {
            try
            {
                return BookDA.ListBooks();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int InsertBooks(BookModel bookModel)
        {
            try
            {
                return BookDA.InsertBooks(bookModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateBooks(int id, BookModel bookModel)
        {
            try
            {
                return BookDA.UpdateBooks(id, bookModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteBooks(int id)
        {
            try
            {
                return BookDA.DeleteBooks(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteBooksLogic(int id)
        {
            try
            {
                return BookDA.DeleteBooksLogic(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}