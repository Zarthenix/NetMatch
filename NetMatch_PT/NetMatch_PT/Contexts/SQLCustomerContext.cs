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
    public class SQLCustomerContext : SQLBaseContext, ICustomerContext
    {
        public SQLCustomerContext(IConfiguration configuration) : base(configuration)
        {
        }
        public List<Customer> GetAll()
        {
            List<Customer> CustomerList = new List<Customer>();
            try
            {
                string sql = "SELECT CustomerId, FirstName, LastName, Address, Woonplaats, Postcode, Email, GeboorteDatum, Telefoonnummer";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {

                };
                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Customer c = DataSetParser.DataSetToCustomer(results, x);
                    CustomerList.Add(c);
                }
                return CustomerList;
            }
            catch
            {
                return null;
            }

        }

        public Customer GetById(int id)
        {
            try
            {
                string sql = "SELECT Firstname, Lastname, Address, Woonplaats, Postcode, Email, Geboortedatum, Telefoonnummer WHERE CustomerID = @CustomerID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string,string>("CustomerID", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                Customer c = DataSetParser.DataSetToCustomer(results, 0);
                return c;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Customer c)
        {
            try
            {
                string sql = "UPDATE Customer SET Firstname = @firstname, Lastname = @lastname, Address = @address, Woonplaats = @woonplaats, Postcode = @postcode, Email = @email, Geboortedatum = @geboortedatum, Telefoonnummer = @telefoonnummer";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("firstname", c.FirstName),
                    new KeyValuePair<string, string>("lastname", c.LastName),
                    new KeyValuePair<string, string>("address", c.Address),
                    new KeyValuePair<string, string>("woonplaats", c.Woonplaats),
                    new KeyValuePair<string, string>("postcode", c.Postcode),
                    new KeyValuePair<string, string>("email", c.Email),
                    new KeyValuePair<string, string>("geboortedatum", c.Geboortedatum.ToString()),
                    new KeyValuePair<string, string>("telefoonnummer", c.Telefoonnummer)
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
