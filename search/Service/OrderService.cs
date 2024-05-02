using Microsoft.Data.SqlClient;
using search.Models;
using System.Net;
using System.Xml.Linq;

namespace search.Service
{
    public class OrderService
    {
        private readonly string connectionString = "Data Source=DESKTOP-KOOA4LH\\SQLEXPRESS;Initial Catalog=pruebaOrden;Integrated Security=True";

        public List<string> GetPartnum()
        {
            List<string> folios = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT folio FROM ordenHed";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string folio = reader["folio"].ToString();
                    folios.Add(folio);
                }
                reader.Close();
            }
            return folios;
        }
        public List<OrderHedModel> GetDetailsOrder(string folio)
        {
            Console.WriteLine("Selected Folio Details: " + folio);
            List<OrderHedModel> details = new List<OrderHedModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //(folio == null ? "" : folio)
                string query = "SELECT ordenDtl.folio, fecha,direccion,Producto,cantidad,descripcion,tipo FROM ordenHed INNER JOIN ordenDtl ON ordenHed.folio = ordenDtl.folio WHERE ordenDtl.folio = @folio;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@folio", "FOL001");

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    OrderHedModel detail = new OrderHedModel
                    {
                        Folio = reader["folio"].ToString(),
                        Fecha = reader["fecha"].ToString(),
                        Direccion = reader["direccion"].ToString(),
                        Producto = reader["Producto"].ToString(),
                        Cantidad = reader["cantidad"].ToString(),
                        Descripcion = reader["descripcion"].ToString(),
                        Tipo = reader["tipo"].ToString()
                    };

                    details.Add(detail);
                }
                reader.Close();
            }
            return details;
        }

    }
}
