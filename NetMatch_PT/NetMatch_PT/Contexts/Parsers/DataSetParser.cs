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
    }
}
