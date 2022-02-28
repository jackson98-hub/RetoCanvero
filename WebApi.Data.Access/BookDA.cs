using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data.Access
{
    public class BookDA
    {
        public static IEnumerable<BookModel> ListBooks()
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            List<BookModel> resulBooks = new List<BookModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_SELECCIONAR_LIBRO", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();

                while (rdr.Read())
                {
                    var book = new BookModel
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        Titulo = rdr["titulo"].ToString(),
                        Autor = rdr["autor"].ToString(),
                        Paginas = Convert.ToInt32(rdr["paginas"])
                    };
                    
                    resulBooks.Add(book);
                }
                return resulBooks;
            }
        }

        public static int InsertBooks(BookModel bookModel)
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            int result;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_INSERTAR_LIBRO", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@titulo", SqlDbType.VarChar, 100).Value = bookModel.Titulo;
                com.Parameters.Add("@autor", SqlDbType.VarChar, 100).Value = bookModel.Autor;
                com.Parameters.Add("@paginas", SqlDbType.Int, 5).Value = bookModel.Paginas;

                com.Parameters.Add("@id", SqlDbType.Int, 5).Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                result = Convert.ToInt32(com.Parameters["@id"].Value);
            }

            return result;
        }

        public static int UpdateBooks(int id, BookModel bookModel)
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            int result;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_ACTUALIZAR_LIBRO", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@titulo", SqlDbType.VarChar, 100).Value = bookModel.Titulo;
                com.Parameters.Add("@autor", SqlDbType.VarChar, 100).Value = bookModel.Autor;
                com.Parameters.Add("@paginas", SqlDbType.Int, 5).Value = bookModel.Paginas;

                com.Parameters.Add("@id", SqlDbType.Int, 5).Value = id;

                result = com.ExecuteNonQuery();
            }
            return result;
        }

        public static int DeleteBooks(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            int result;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_ELIMINAR_LIBRO", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@id", SqlDbType.Int, 5).Value = id;

                result = com.ExecuteNonQuery();
            }
            return result;
        }

        public static int DeleteBooksLogic(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            int result;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_ELIMINAR_LOGICO_LIBRO", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@id", SqlDbType.Int, 5).Value = id;

                result = com.ExecuteNonQuery();
            }
            return result;
        }
    }
}
