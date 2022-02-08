using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace primaWebApp.Pages
{
    public class RISPOSTAModel : PageModel
    {
        public string TestoUtente { get; set; }
        public string NomeUtente { get; set; }
        public string CognomeUtente { get; set; }
        public string queryDatabase { get; set; }
        public void OnGet(string testo,string nome,string cognome)
        {
            TestoUtente = testo;
            NomeUtente = nome;
            CognomeUtente = cognome;
        }
        public string query()
        {
            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();

                    String sql = "SELECT LastName, FirstName FROM Employees";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                                queryDatabase += "Nome:"+reader.GetString(0)+" Cognome:" +reader.GetString(1)+ "\r\n";
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return queryDatabase;
        }

    }
}
