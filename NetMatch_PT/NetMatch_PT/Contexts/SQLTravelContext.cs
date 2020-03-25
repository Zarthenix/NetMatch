using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;
using NetMatch_PT.Contexts.Parsers;
using NetMatch_PT.Contexts.IContext;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace NetMatch_PT.Contexts
{
    public class SQLTravelContext: SQLBaseContext, ITravelContext
    {
        public SQLTravelContext(IConfiguration configuration) : base(configuration)
        {
        }
        public List<Travel> GetAll()
        {
            List<Travel> TravelList = new List<Travel>();
            try
            {
                string sql = "SELECT TravelId, ReisagentID, AccomodationID, CustomerID, Discount, DepartureDate, Insurance, Transport, price";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {

                };
                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Travel c = DataSetParser.DataSetToTravel(results, x);
                    TravelList.Add(c);
                }
                return TravelList;
            }
            catch
            {
                return null;
            }

        }

        public Travel GetById(int id)
        {
            try
            {
                string sql = "SELECT ReisagentID, AccomodationID, CustomerID, Discount, DepartureDate, Insurance, Transport, price WHERE TravelID = @TravelID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string,string>("TravelID", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                Travel c = DataSetParser.DataSetToTravel(results, 0);
                return c;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Travel c)
        {
            try
            {
                string sql = "UPDATE Travel SET ReisagentID = @ReisagentID, AccomodationID = @AccomodationID, CustomerID = @CustomerID, Discount = @Discount, DepartureDate = @DepartureDate, Insurance = @Insurance, Transport = @Transport, Price = @Price";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ReisagentID", c.ReisagentID.ToString()),
                    new KeyValuePair<string, string>("AccomodationID", c.AccomodationID.ToString()),
                    new KeyValuePair<string, string>("CustomerID", c.CustomerID.ToString()),
                    new KeyValuePair<string, string>("Discount", c.Discount.ToString()),
                    new KeyValuePair<string, string>("DepartureDate", c.DepartureDate.ToString()),
                    new KeyValuePair<string, string>("Insurance", c.Insurance),
                    new KeyValuePair<string, string>("Transport", c.Transport),
                    new KeyValuePair<string, string>("Price", c.Price.ToString())
                };
                ExecuteSql(sql, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
