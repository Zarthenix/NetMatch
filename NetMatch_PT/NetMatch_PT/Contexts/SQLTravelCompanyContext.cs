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

namespace NetMatch_PT.Contexts
{
    public class SQLTravelCompanyContext : SQLBaseContext, ITravelCompanyContext
    {
        public SQLTravelCompanyContext(IConfiguration configuration) : base(configuration)
        {
        }
        public List<TravelCompany> GetAll()
        {
            List<TravelCompany> tcList = new List<TravelCompany>();
            try
            {
                string sql = "SELECT TravelCompanyId, FirstName, LastName, BirthDate";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {

                };
                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    TravelCompany tc = DataSetParser.DataSetToTravelCompany(results, x);
                    tcList.Add(tc);
                }
                return tcList;
            }
            catch
            {
                return null;
            }
        }

        public TravelCompany GetById(int id)
        {
            try
            {
                string sql = "SELECT FirstName, LastName, BirthDate WHERE TravelCompanyId = @TravelCompanyId ";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("TravelCompanyId", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                TravelCompany tc = DataSetParser.DataSetToTravelCompany(results, 0);
                return tc;
            }
            catch
            {
                return null;
            }
        }


        public long Insert(TravelCompany tc)
        {
            try
            {
                string sql = "INSERT INTO TravelCompany(FirstName, LastName, BirthDate) VALUES (@FirstName, @LastName, @BirthDate)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("FirstName", tc.FirstName),
                    new KeyValuePair<string, string>("LastName", tc.LastName),
                    new KeyValuePair<string, string>("BirthDate", tc.BirthDate.ToString())
                };
                long results = ExecuteInsert(sql, parameters);
                return results;
            }
            catch
            {
                throw;
            }

        }
    }
}
