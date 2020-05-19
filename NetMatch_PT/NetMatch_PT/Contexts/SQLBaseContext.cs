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
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = connection.CreateCommand();

                command.Parameters.AddRange(GetParameters(parameters));
                command.CommandText = sql;

                adapter.SelectCommand = command;

                connection.Open();
                adapter.Fill(data);
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
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = connection.CreateCommand();

                command.Parameters.AddRange(GetParameters(parameters));
                command.CommandText = sql;

                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        private SqlParameter[] GetParameters(List<KeyValuePair<string, string>> parameters)
        {
            SqlParameter[] retVal = new SqlParameter[parameters.Count];
            foreach (KeyValuePair<string, string> kvp in parameters)
            {
                SqlParameter param = new SqlParameter
                {
                    ParameterName = kvp.Key,
                    Value = kvp.Value
                };
                retVal[parameters.IndexOf(kvp)] = param;
            }
            return retVal;
        }

    }
}
