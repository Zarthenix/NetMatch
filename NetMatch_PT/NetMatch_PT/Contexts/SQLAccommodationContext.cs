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
using NetMatch_PT.Models.Enums;
using NetMatch_PT.ViewModels;

namespace NetMatch_PT.Contexts
{
    public class SQLAccommodationContext : SQLBaseContext, IAccommodationContext
    {

        public SQLAccommodationContext(IConfiguration configuration) : base(configuration)
        {
        }
        public Accommodation GetById(int id)
        {
            try
            {
                string sql = "SELECT AccommodationID, Title, [Description], [Image], [Country] FROM [Accommodation] WHERE AccommodationID = @AccommodationID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string,string>("@AccommodationID", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                Accommodation a = DataSetParser.DataSetToAccommodation(results, 0);
                
                return GetAccommodationPrices(a);
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
                string sql = "SELECT AccommodationID, Title, Description, Image, Country FROM [Accommodation]";

                DataSet results = ExecuteSql(sql, new List<KeyValuePair<string, string>>());

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Accommodation a = DataSetParser.DataSetToAccommodation(results, x);
                    accommodationList.Add(GetAccommodationPrices(a));
                }
                return accommodationList;
            }
            catch
            {
                throw;
            }
        }

        public List<Accommodation> Search(string searchTerm)
        {
            List<Accommodation> accommodationList = new List<Accommodation>();

            searchTerm = CustomFormat(searchTerm);
            try
            {
                string sql = "SELECT [AccommodationID], [Title], [Description], [Image], [Country] FROM Accommodation WHERE [Title] LIKE @SearchTerm OR [Description] LIKE @SearchTerm";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("@SearchTerm", "%" + searchTerm + "%")
                };

                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Accommodation a = DataSetParser.DataSetToAccommodation(results, x);
                    accommodationList.Add(GetAccommodationPrices(a));
                }

                return accommodationList;
            }
            catch
            {
                throw;
            }
        }

        private static string CustomFormat(string input)
        {
            input = input.Replace(@"\", @"\\");
            input = input.Replace(@"%", @"\%");
            input = input.Replace(@"[", @"\[");
            input = input.Replace(@"]", @"\]");
            input = input.Replace(@"_", @"\_");
            return input;
        }

        public List<Accommodation> QuickSearch(SearchVm sm)
        {
            List<Accommodation> result = new List<Accommodation>();

            if (!string.IsNullOrEmpty(sm.Search)) sm.Search = CustomFormat(sm.Search);

            string sql =
                "SELECT [AccommodationId], [Title], [Description], [Image], " +
                "[Country] FROM [Accommodation] " +
                "WHERE ([Title] LIKE '@search' OR [Description] LIKE @search) AND [Country] = @country";

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("@search", "%" + sm.Search + "%"),
                new KeyValuePair<string, string>("@country", Convert.ToInt32(sm.Country).ToString())
            };


            DataSet results = ExecuteSql(sql, parameters);

            for (int x = 0; x < results.Tables[0].Rows.Count; x++)
            {
                Accommodation a = DataSetParser.DataSetToAccommodation(results, x);
                result.Add(GetAccommodationPrices(a));
            }

            if (sm.TravelType == TravelTypes.Zomer)
            {
                result = result.Where(n => n.DatePrices.Count(m => m.Date.Month >= 3 || m.Date.Month <= 9) != 0).ToList();
            }
            else if (sm.TravelType == TravelTypes.Winter)
            {
                result = result.Where(n => n.DatePrices.Count(m => m.Date.Month <= 2 || m.Date.Month >= 10) != 0)
                    .ToList();
            }
            
            if (sm.Month != null)
            {
                result = result.Where(n => n.DatePrices.Count(m => m.Date.Month == (int)(Months)sm.Month + 1) != 0).ToList();
            }

            return result;
        }

        private Accommodation GetAccommodationPrices(Accommodation a)
        {
            try
            {
                string sql = "SELECT * FROM [AccommodationPrices] WHERE [AccommodationId] = @ac";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("@ac", a.Id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    a.DatePrices.Add(DataSetParser.DataSetToAccommodationPrices(results, x));
                }

                return a;
            }
            catch
            {
                throw;
            }
        }
    }
}
