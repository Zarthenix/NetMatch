using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetMatch_PT.Containers.Interfaces;
using NetMatch_PT.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Containers
{
    public class UserContainer : IUserContainer
    {
        private List<User> users;
        private readonly string _connectionString;
        public IReadOnlyList<User> Users => users;

        public  UserContainer(IConfiguration configuration)
        {
            users = new List<User>();
            _connectionString = "Server=mssql.fhict.local;Database=dbi407655_netmatch;User Id=dbi407655_netmatch;Password=Netmatch;";
        }

        public void Create(string email, string password)
        {

            User user = new User()
            {
                Email = email,
                Password = password
            };

            user.HashPassword();

            users.Add(user);

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string q = "INSERT INTO dbo.Users (Email, Password) VALUES (@Email, @Password)";
            SqlCommand command = new SqlCommand(q);

            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Prepare();

            command.ExecuteNonQuery();

            q = "SELECT Id FROM dbo.Users WHERE Email = @Email";
            command = new SqlCommand(q);

            command.Parameters.AddWithValue("@Email", user.Email);
            command.Prepare();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            user.Id = dt.Rows[0].Field<int>("Id");

            connection.Close();
            
        }

        public void Delete(User user)
        {
            users.Remove(user);

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
                string q = "DELETE FROM dbo.Users WHERE Id = @Id";
                SqlCommand command = new SqlCommand(q);

                command.Parameters.AddWithValue("@Id", user.Id);
                command.Prepare();

                command.ExecuteNonQuery();
                connection.Close();
            
        }

        public void GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string q = "SELECT * FROM dbo.Users";
                SqlCommand command = new SqlCommand(q);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                users.Clear();
                foreach(DataRow row in dt.Rows)
                {
                    User user = new User()
                    {
                        Id = row.Field<int>("Id"),
                        Email = row.Field<string>("Email"),
                        Password = row.Field<string>("Password")
                    };

                    users.Add(user);
                }

            connection.Close();
            }
        }
    }

