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
    public class ClientController : ApiController
    {
        readonly ClientDomain clientDomain = new ClientDomain();

        [ResponseType(typeof(IEnumerable<ClientModel>))]
        public IEnumerable<ClientModel> Get()
        {
            return clientDomain.ListClients().ToArray();
        }

        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage httpMsg = null;
            var cliente = clientDomain.ListClients().ToArray().FirstOrDefault((p) => p.Id == id);
            if (cliente == null)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "El Id (" + id.ToString() + ") no se encuentra registrado");
            }
            else
            {
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, cliente);
            }
            return httpMsg;
        }

        public IEnumerable<ClientModel> Get(int row, string p)
        {
            return clientDomain.ListClients().Take(row).ToArray();
        }

        public HttpResponseMessage Post([FromBody] ClientModel clientModel)
        {
            HttpResponseMessage httpMsg = null;
            try
            {
                ClientModel client = new ClientModel();
                client.Nombres = clientModel.Nombres;
                client.Apellidos = clientModel.Apellidos;
                client.Dni = clientModel.Dni;

                int result = clientDomain.InsertClients(client);
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, client);

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

        public HttpResponseMessage Put(int id, [FromBody] ClientModel clientModel)
        {
            HttpResponseMessage httpMsg = null;
            try
            {
                ClientModel client = new ClientModel();
                client.Nombres = clientModel.Nombres;
                client.Apellidos = clientModel.Apellidos;
                client.Dni = clientModel.Dni;
                client.Id = id;

                clientDomain.UpdateClients(id, client);

                httpMsg = Request.CreateResponse(HttpStatusCode.OK, client);

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
                ClientModel client = new ClientModel();
                client.Id = id;

                clientDomain.DeleteClients(id);
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, client);

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
                ClientModel client = new ClientModel();
                client.Id = id;

                clientDomain.DeleteClientsLogic(id);
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, client);

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
