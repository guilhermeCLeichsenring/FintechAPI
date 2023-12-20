using FintechApi.Models;
using FintechAPI.Models;

namespace FintechApi.Repositoy.Interfaces
{
    public interface IUserRepository
    {

        public IEnumerable<UserModel> GetAllUsers();

        public UserModel GetUserById(int userId);

        public UserModel GetUserByEmail(string email);
    }
}
