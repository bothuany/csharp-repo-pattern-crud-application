using CRUD_App.DataAccess;
using Microsoft.Extensions.Configuration;

namespace CRUD_App.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }

        override
        public string ToString()
        {
            return $"Id: {Id}, " +
                $"First Name: {first_name}, " +
                $"Last Name: {last_name}" +
                $"Email: {email} " +
                $"Gender: {gender}";

        }
    }

    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }
    }
}
