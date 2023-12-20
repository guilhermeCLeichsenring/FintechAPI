using FintechApi.Repositoy.Interfaces;
using FintechAPI.Context;
using FintechAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace FintechApi.Repositoy
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly DataBaseContext _dbContext;

        public UserRepository(DataBaseContext context) : base(context)
        {
            _dbContext = context;

        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            var users = _dbContext.Users.AsNoTracking().ToList();

            return users;
        }

        public UserModel GetUserByEmail(string email)
        {
            var user = _dbContext.Users.AsNoTracking().Where(x => x.Email == email).FirstOrDefault();
            return user;
        }

        public UserModel GetUserById(int userId)
        {
            var user = _dbContext.Users.AsNoTracking().Where(b => b.Id == userId).Include(u => u.Transactions).ThenInclude(t => t.Category).FirstOrDefault();

            return user;
        }

    }
}
