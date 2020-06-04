using Microsoft.Extensions.Configuration;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Contexts.Parsers;
using NetMatch_PT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Contexts
{
    public class SQLBoekingContext : SQLBaseContext , IBoekingContext
    {

        public SQLBoekingContext(IConfiguration configuration) : base(configuration)
        {

        }

        public List<Boeking> GetAll()
        {
            throw new NotImplementedException();
        }

        public Travel GetTravelbyId(int id)
        {
            throw new NotImplementedException();
        }

        public long insert(Boeking b)
        {
            try
            {
                string sql = "INSERT INTO BookedTrips(TravelId, Datum, Voornaam, Achternaam, VoornaamReisgezel, AchternaamReisgezel) VALUES (@travelId, @datum, @voornaam, @achternaam, @voornaamreisgezel, @achternaamreisgezel)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("@travelId", b.TravelId.ToString()),
                    new KeyValuePair<string, string>("@datum", b.Datum.ToLongDateString()),
                    new KeyValuePair<string, string>("@voornaam", b.Voornaam.ToString()),
                    new KeyValuePair<string, string>("@achternaam", b.Achternaam.ToString()),
                    new KeyValuePair<string, string>("@voornaamreisgezel", b.VoornaamReisgezel.ToString()),
                    new KeyValuePair<string, string>("@achternaamreisgezel", b.AchternaamReisgezel.ToString())
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
