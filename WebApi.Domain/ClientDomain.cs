using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Business.Logic;
using WebApi.Models;

namespace WebApi.Domain
{
    public class ClientDomain
    {
        public IEnumerable<ClientModel> ListClients()
        {
            try
            {
                return Client.ListClients();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int InsertClients(ClientModel clientModel)
        {
            try
            {
                return Client.InsertClients(clientModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int UpdateClients(int id, ClientModel clientModel)
        {
            try
            {
                return Client.UpdateClients(id, clientModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DeleteClients(int id)
        {
            try
            {
                return Client.DeleteClients(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DeleteClientsLogic(int id)
        {
            try
            {
                return Client.DeleteClientsLogic(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
