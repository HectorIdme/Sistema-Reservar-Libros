using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceModel.Dispatcher;
using System.Web.Script.Serialization;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        /*
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        */


        public string ValidateUser(User user1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Correo", user1.email);
            cmd.Parameters.AddWithValue("@Clave", user1.password);
            /*
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Close();
            DataSet ds = new DataSet();
            da.Fill(ds, "Users");
            return ds;
            */
            string result = cmd.ExecuteScalar().ToString();
            con.Close();

            return result;
        }

        public string ListBooks()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ListBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                var row = new Dictionary<string, object>();
                for(var i =0; i< reader.FieldCount; i++)
                {
                    row.Add(reader.GetName(i), reader[i]);
                }
                rows.Add(row);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonResult = serializer.Serialize(rows);
            return jsonResult;
        }


        public string SearchBook(string letter)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SearchBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Letra", letter);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                var row = new Dictionary<string, object>();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader.GetName(i), reader[i]);
                }
                rows.Add(row);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonResult = serializer.Serialize(rows);
            return jsonResult;
        }

    }
}
