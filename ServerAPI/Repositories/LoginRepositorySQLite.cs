using System;
using Core.Model;
using Microsoft.Data.Sqlite;

namespace ServerAPI.Repositories
{
    public class LoginRepositorySQLite : ILoginRepository
    {
        private const string connectionString = @"Data Source=Data/logindb.db";

        private Role[]? roles = null;


        private User[] GetAll()
        {
            var result = new List<User>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                roles = LoadRoles(connection);
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM User";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var username = reader.GetString(1);
                        var password = reader.GetString(2);
                        var email = reader.GetString(3);
                      
                        var roleId = reader.GetInt32(4);

                        var user = new User
                        {
                            Id = id,
                            UserName = username,
                            Password = password,
                            Email = email,
                            Role = roles.Where(r => r.Id == roleId).Single<Role>()
                        };
                        result.Add(user);
                    }
                }
            }
            return result.ToArray();
        }

        private Role[] LoadRoles(SqliteConnection connection) {
            var res = new List<Role>();
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Role";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);

                    var role = new Role
                    {
                        Id = id,
                        Name = name
                    };
                    res.Add(role);
                }
            }
            return res.ToArray();
        }

        public bool Verify(string userName, string password)
        {
            var theUser = GetAll().Where( u => u.UserName.Equals(userName,StringComparison.OrdinalIgnoreCase) &&
                                               u.Password.Equals(password));

            return (theUser != null && theUser.Count() == 1);
        }

        public User GetUserByUserName(string username)
        {
            var theUser = GetAll().Where(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));

            return theUser.Single<User>();
        }
    }
}

