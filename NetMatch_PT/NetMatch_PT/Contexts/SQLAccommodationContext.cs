using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;
using NetMatch_PT.Contexts.Parsers;

namespace NetMatch_PT.Contexts
{
    public class SQLAccommodationContext : SQLBaseContext, IAccommodationContext
    {
        private readonly string _connectionString;

        public SQLAccommodationContext(IConfiguration configuration) : base(configuration)
        {
        }
        public Accommodation GetById(int id)
        {
            try
            {
                string sql = "SELECT Title, Description, Price, Image WHERE AccommodationID = @AccommodationID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string,string>("AccommodationID", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                Accommodation a = DataSetParser.DataSetToAccommodation(results, 0);
                return a;
            }
            catch
            {
                return null;
            }
            
        }

        public List<Accommodation> GetAll()
        {
            List<Accommodation> accommodationList = new List<Accommodation>();
            try
            {
                string sql = "SELECT AccommodationID, Title, Description, Price, Image";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {

                };

                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Accommodation a = DataSetParser.DataSetToAccommodation(results, x);
                    accommodationList.Add(a);
                }
                return accommodationList;
            }
            catch
            {
                throw;
            }
        }
    }
}
