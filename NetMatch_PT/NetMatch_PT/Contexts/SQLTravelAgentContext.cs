using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;
using NetMatch_PT.Contexts.Parsers;
using NetMatch_PT.Contexts.IContext;

namespace NetMatch_PT.Contexts.IContext
{
    public class SQLTravelAgentContext : SQLBaseContext, ITravelAgentContext
    {
        public SQLTravelAgentContext(IConfiguration configuration) : base(configuration)
        { 
        }
        public List<TravelAgent> GetAll()
        {
            List<TravelAgent> TravelAgentList = new List<TravelAgent>();
            try
            {
                string sql = "SELECT TravelAgentId, Email, Password FROM TravelAgent";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {

                };
                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    TravelAgent ta = DataSetParser.DataSetToTravelAgent(results, x);
                    TravelAgentList.Add(ta);
                }
                return TravelAgentList;
            }
            catch
            {
                return null;
            }
        }

        public TravelAgent GetById(int id)
        {
            try
            {
                string sql = "SELECT Email, Password FROM TravelAgent WHERE TravelAgentId = @TravelAgentId";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("TravelAgentId", id.ToString())
                };
                DataSet results = ExecuteSql(sql, parameters);
                TravelAgent ta = DataSetParser.DataSetToTravelAgent(results, 0);
                return ta;
            }
            catch
            {
                return null;
            }
        }
    }
}
