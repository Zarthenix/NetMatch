using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;

namespace NetMatch_PT.Contexts
{
    public class SQLAccomodationContext : IAccommodationContext
    {
        private readonly string _connectionString;

        public SQLAccomodationContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public Accommodation Detail(int id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Accommodatie] WHERE [AccommodatieID] = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Accommodation(id, reader["Titel"].ToString(),
                                Convert.ToDateTime(reader["Datum"]), (decimal) reader["Prijs"],
                                (byte[]) reader["Afbeelding"], reader["Beschrijving"].ToString());
                        }
                    }

                    connection.Close();
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }
    }
}
