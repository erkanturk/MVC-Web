using _17_AdoNetExample.DbService.Abstract;
using _17_AdoNetExample.Models;
using Microsoft.Data.SqlClient;

namespace _17_AdoNetExample.DbService.Concrete
{
    public class DbService : IDbService
    {
        private readonly string _connectionString;

        public DbService(IConfiguration configuration)
        {
            _connectionString=configuration.GetConnectionString("DefaultConnection");//appsettings.json dosyasındaki connection stringi alır
        }
        public void ExecuteNonQuery(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, connection))
                {
                    if (parameters!=null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> ExecuteReader(string query)
        {
            var results = new List<Student>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var model = new Student()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Age = Convert.ToInt32(reader["Age"]),
                            };
                            results.Add(model);
                        }
                    }
                }
            }
            return results;
        }

        public object ExecuteScalar(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var commend = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return commend.ExecuteScalar();
                }
            }
        }
    }
}
