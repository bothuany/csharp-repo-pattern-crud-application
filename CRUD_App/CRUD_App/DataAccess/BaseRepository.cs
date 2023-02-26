using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace CRUD_App.DataAccess
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        private readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlConnection");
        }

        public IEnumerable<T> GetAll()
        {
            using var connection = new MySqlConnection(_connectionString);
            var entities = connection.Query<T>("SELECT * FROM mock_data");
            return entities;
        }

        public T GetById(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var entity = connection.QuerySingleOrDefault<T>("SELECT * FROM mock_data WHERE Id = @id", new { id });
            return entity;
        }

        public void Insert(T entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute("INSERT INTO mock_data (id, first_name, last_name, email, gender) VALUES (@Id, @first_name, @last_name, @email, @gender)", entity);
        }

        public void Update(T entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute("UPDATE mock_data SET first_name = @first_name, last_name = @last_name, email = @email, gender = @gender WHERE Id = @Id", entity);
        }

        public void Delete(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute("DELETE FROM mock_data WHERE Id = @id", new { id });
        }
    }
}
