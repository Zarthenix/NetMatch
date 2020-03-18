using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;
using System.Data;

namespace NetMatch_PT.Contexts.Parsers
{
    public class DataSetParser
    {
        public static Accommodation DataSetToAccommodation(DataSet set, int rowIndex)
        {
            return new Accommodation((int)set.Tables[0].Rows[rowIndex][0])
            {
                
                Title = (string)set.Tables[0].Rows[rowIndex][1],
                Description = (string)set.Tables[0].Rows[rowIndex][2],
                Price = (decimal)set.Tables[0].Rows[rowIndex][3],
                Image = (byte[])set.Tables[0].Rows[rowIndex][4]
            };
        }
        public static Customer DataSetToCustomer(DataSet set, int rowIndex)
        {
            return new Customer((int)set.Tables[0].Rows[rowIndex][0])
            {
                FirstName = (string)set.Tables[0].Rows[rowIndex][1],
                LastName = (string)set.Tables[0].Rows[rowIndex][2],
                Address = (string)set.Tables[0].Rows[rowIndex][3],
                Woonplaats = (string)set.Tables[0].Rows[rowIndex][4],
                Postcode = (string)set.Tables[0].Rows[rowIndex][5],
                Email = (string)set.Tables[0].Rows[rowIndex][6],
                Geboortedatum = (DateTime)set.Tables[0].Rows[rowIndex][7],
                Telefoonnummer = (string)set.Tables[0].Rows[rowIndex][8]
            };
        }
        public static TravelAgent DataSetToTravelAgent(DataSet set, int rowIndex)
        {
            return new TravelAgent((int)set.Tables[0].Rows[rowIndex][0])
            {
                Email = (string)set.Tables[0].Rows[rowIndex][1],
                Password = (string)set.Tables[0].Rows[rowIndex][2]
            };
        }
    }
}
