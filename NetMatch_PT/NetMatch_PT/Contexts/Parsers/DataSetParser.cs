﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;
using System.Data;
using Microsoft.CodeAnalysis.CSharp;
using NetMatch_PT.Models.Enums;
using System.Globalization;

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
                Image = (byte[])set.Tables[0].Rows[rowIndex][3],
                Country = (Countries)Convert.ToInt32(set.Tables[0].Rows[rowIndex][4])
            };
        }

        public static AccommodationPrices DataSetToAccommodationPrices(DataSet set, int rowIndex)
        {
            return new AccommodationPrices()
            {
                Date = Convert.ToDateTime(set.Tables[0].Rows[rowIndex][0]),
                //Date = DateTime.ParseExact((string)set.Tables[0].Rows[rowIndex][0], "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture),
                Price = (decimal) set.Tables[0].Rows[rowIndex][1]
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
        public static Travel DataSetToTravel(DataSet set, int rowIndex)
        {
            return new Travel((int)set.Tables[0].Rows[rowIndex][0])
            {
                ReisagentID = (int)set.Tables[0].Rows[rowIndex][1],
                AccomodationID = (int)set.Tables[0].Rows[rowIndex][2],
                CustomerID = (int)set.Tables[0].Rows[rowIndex][3],
                Discount = (bool)set.Tables[0].Rows[rowIndex][4],
                DepartureDate = (DateTime)set.Tables[0].Rows[rowIndex][5],
                Transport = (string)set.Tables[0].Rows[rowIndex][6],
                Price = (decimal)set.Tables[0].Rows[rowIndex][7]
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
        public static TravelCompany DataSetToTravelCompany(DataSet set, int rowIndex)
        {
            return new TravelCompany((int)set.Tables[0].Rows[rowIndex][0])
            {
                FirstName = (string)set.Tables[0].Rows[rowIndex][1],
                LastName = (string)set.Tables[0].Rows[rowIndex][2],
                BirthDate = (DateTime)set.Tables[0].Rows[rowIndex][3]
            };
        }
    }
}
