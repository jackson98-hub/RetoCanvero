using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Domain;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BookController : ApiController
    {
        readonly BookDomain bookDomain = new BookDomain();

        [ResponseType(typeof(IEnumerable<BookModel>))]
        public IEnumerable<BookModel> Get()
        {
            return bookDomain.ListBooks().ToArray();
        }

        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage httpMsg = null;
            var usuario = bookDomain.ListBooks().ToArray().FirstOrDefault((p) => p.Id == id);
            if (usuario == null)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "El Id (" + id.ToString() + ") no se encuentra registrado");
            }
            else
            {
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, usuario);
            }
            return httpMsg;
        }

        public IEnumerable<BookModel> Get(int row, string p)
        {
            return bookDomain.ListBooks().Take(row).ToArray();
        }

        public HttpResponseMessage Post([FromBody] BookModel bookModel)
        {
            HttpResponseMessage httpMsg = null;
            try
            {
                BookModel book = new BookModel();
                book.Titulo = bookModel.Titulo;
                book.Autor = bookModel.Autor;
                book.Paginas = bookModel.Paginas;

                int result = bookDomain.InsertBooks(book);
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, book);

                if (httpMsg.IsSuccessStatusCode)
                {
                    httpMsg = Get(result);
                }
                else
                {
                    httpMsg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ocurrio problemas al ingresar el registro");
                }
                return httpMsg;
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpMsg;
        }

        public HttpResponseMessage Put(int id, [FromBody] BookModel bookModel)
        {
            HttpResponseMessage httpMsg = null;
            try
            {
                BookModel book = new BookModel();
                book.Titulo = bookModel.Titulo;
                book.Autor = bookModel.Autor;
                book.Paginas = bookModel.Paginas;
                book.Id = id;

                bookDomain.UpdateBooks(id, book);

                httpMsg = Request.CreateResponse(HttpStatusCode.OK, book);

                return httpMsg;
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return httpMsg;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage httpMsg = null;
            try
            {
                BookModel book = new BookModel();
                book.Id = id;

                bookDomain.DeleteBooks(id);
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, book);

                return httpMsg;
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpMsg;
        }

        public HttpResponseMessage Delete(int id, int l)
        {
            HttpResponseMessage httpMsg = null;
            try
            {
                BookModel book = new BookModel();
                book.Id = id;

                bookDomain.DeleteBooksLogic(id);
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, book);

                return httpMsg;
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpMsg;
        }
    }
}
