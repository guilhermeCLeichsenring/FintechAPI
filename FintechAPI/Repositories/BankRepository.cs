using FintechApi.Models;
using FintechApi.Repositoy.Interfaces;
using FintechAPI.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FintechApi.Repositoy
{
    public class BankRepository : BaseRepository, IBankRepository
    {
        private readonly DataBaseContext _dbContext;

        public BankRepository(DataBaseContext context) : base(context)
        {
            _dbContext = context;
            
        }

        public IEnumerable<BankModel> GetAllBanks()
        {
            var banks = _dbContext.Banks.AsNoTracking().ToList();

            return banks;
        }

        public BankModel GetBankById(int bankId)
        {
            var bank = _dbContext.Banks.AsNoTracking().Where(b => b.Id == bankId).FirstOrDefault();

            return bank;
        }

    }
}
