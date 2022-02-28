using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Access;
using WebApi.Models;

namespace WebApi.Business.Logic
{
    public class Client
    {
        public static IEnumerable<ClientModel> ListClients()
        {
            try
            {
                return ClientDA.ListClients();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int InsertClients(ClientModel clientModel)
        {
            try
            {
                return ClientDA.InsertClients(clientModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateClients(int id, ClientModel clientModel)
        {
            try
            {
                return ClientDA.UpdateClients(id, clientModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteClients(int id)
        {
            try
            {
                return ClientDA.DeleteClients(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteClientsLogic(int id)
        {
            try
            {
                return ClientDA.DeleteClientsLogic(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
