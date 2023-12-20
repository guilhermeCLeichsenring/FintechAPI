using FintechApi.Repositoy.Interfaces;
using FintechAPI.Context;
using FintechAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace FintechApi.Repositoy
{
    public class TransactionRepository : BaseRepository ,ITransactionRepository
    {
        

        private readonly DataBaseContext _dbContext;

        public TransactionRepository(DataBaseContext context) : base(context)
        {
            _dbContext = context;
        }


       
        public TransactionModel GetTransactionById(int id)
        {
            return _dbContext.Transactions.AsNoTracking()
                .Where(t => t.Id == id )
                .Include(t => t.Bank).Include(t => t.Bank)
                .FirstOrDefault()!;
        }

        public IEnumerable<TransactionModel> GetAllTransactionsByUserId(int userId)
        {
            return _dbContext.Transactions.AsNoTracking()
                .Where(t => t.UserId == userId)
                .Include(t => t.Bank).Include(t => t.Bank)
                .ToList();
        }

        public IEnumerable<TransactionModel> GetAllExpends(int userId)
        {
            return _dbContext.Transactions.AsNoTracking()
                .Where(t => t.Type == false && t.UserId == userId)
                .Include(t => t.Bank).Include(t => t.Bank)
                .ToList();
        }

        public IEnumerable<TransactionModel> GetAllReceipts(int userId)
        {
            return _dbContext.Transactions.AsNoTracking()
                .Where(t => t.Type == true && t.UserId == userId)
                .Include(t => t.Bank).Include(t => t.Bank)
                .ToList();            
        }

        public IEnumerable<TransactionModel> GetTransactionsByIdCategory(int categoryId)
        {
            return _dbContext.Transactions.AsNoTracking().
                Where(t => t.CategoryId == categoryId)
                .Include(t => t.Bank).Include(t => t.Category)
                .ToList();


        }


        // Operations

        public double GetExpendsSum(int userId)
        {
            double totalExpends = _dbContext.Transactions.AsNoTracking().Where(t => t.Type == false && t.UserId == userId).Sum(t => t.Value);

            return totalExpends;
    
        }

        public double GetReceiptsSum(int userId)
        {
            double totalReceipts = _dbContext.Transactions.AsNoTracking().Where(t => t.Type == true && t.UserId == userId).Sum(t => t.Value);

            return totalReceipts;
        }

        public double GetAllTransactionSum(int userId)
        {
            double totalReceipts = GetReceiptsSum(userId);

            double totalExpend = GetExpendsSum(userId);

            double total = totalReceipts - totalExpend;

            return total;
        }

        
        
    }
}
