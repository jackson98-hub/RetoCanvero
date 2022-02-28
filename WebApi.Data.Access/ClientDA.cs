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
    public class ClientDA
    {
        public static IEnumerable<ClientModel> ListClients()
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            List<ClientModel> resulClients = new List<ClientModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_SELECCIONAR_CLIENTE", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();

                while (rdr.Read())
                {
                    var client = new ClientModel
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        Nombres = rdr["nombres"].ToString(),
                        Apellidos = rdr["apellidos"].ToString(),
                        Dni = rdr["dni"].ToString()
                    };

                    resulClients.Add(client);
                }
                return resulClients;
            }
        }

        public static int InsertClients(ClientModel clientModel)
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            int result;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_INSERTAR_CLIENTE", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@nombres", SqlDbType.VarChar, 100).Value = clientModel.Nombres;
                com.Parameters.Add("@apellidos", SqlDbType.VarChar, 100).Value = clientModel.Apellidos;
                com.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = clientModel.Dni;

                com.Parameters.Add("@id", SqlDbType.Int, 5).Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                result = Convert.ToInt32(com.Parameters["@id"].Value);
            }

            return result;
        }

        public static int UpdateClients(int id, ClientModel clientModel)
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            int result;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_ACTUALIZAR_CLIENTE", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@nombres", SqlDbType.VarChar, 100).Value = clientModel.Nombres;
                com.Parameters.Add("@apellidos", SqlDbType.VarChar, 100).Value = clientModel.Apellidos;
                com.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = clientModel.Dni;
                com.Parameters.Add("@id", SqlDbType.Int, 5).Value = id;

                result = com.ExecuteNonQuery();
            }
            return result;
        }

        public static int DeleteClients(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            int result;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_ELIMINAR_CLIENTE", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@id", SqlDbType.Int, 5).Value = id;

                result = com.ExecuteNonQuery();
            }
            return result;
        }

        public static int DeleteClientsLogic(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["CnBD"].ConnectionString;

            int result;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_ELIMINAR_LOGICO_CLIENTE", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@id", SqlDbType.Int, 5).Value = id;

                result = com.ExecuteNonQuery();
            }
            return result;
        }
    }
}
