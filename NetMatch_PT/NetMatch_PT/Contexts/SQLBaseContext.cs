using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace NetMatch_PT.Contexts
{
    public abstract class SQLBaseContext
    {
        private readonly string _connectionString;
        public SQLBaseContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DataSet ExecuteSql(string sql, List<KeyValuePair<string, string>> parameters)
        {
            DataSet data = new DataSet();
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlDataAdapter Adapter = new SqlDataAdapter();
                SqlCommand command = connection.CreateCommand();

                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@" + kvp.Key,
                        Value = kvp.Value
                    };
                    command.Parameters.Add(param);
                }

                command.CommandText = sql;
                Adapter.SelectCommand = command;

                connection.Open();
                Adapter.Fill(data);
                connection.Close();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int ExecuteInsert(string sql, List<KeyValuePair<string, string>> parameters)
        {
            int id = new int();
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = connection.CreateCommand();

                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@" + kvp.Key,
                        Value = kvp.Value
                    };
                    command.Parameters.Add(param);
                }
                command.CommandText = sql;

                connection.Open();
                id = (int)command.ExecuteScalar();
                connection.Close();

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
