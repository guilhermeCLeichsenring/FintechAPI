using FintechApi.Models;
using FintechAPI.Models;

namespace FintechApi.Repositoy.Interfaces
{
    public interface ITransactionRepository
    {

        public TransactionModel GetTransactionById(int id);

        public IEnumerable<TransactionModel> GetAllTransactionsByUserId(int userId);

        public IEnumerable<TransactionModel> GetAllExpends(int userId);

        public IEnumerable<TransactionModel> GetAllReceipts(int userId);

        public IEnumerable<TransactionModel> GetTransactionsByIdCategory(int categoryId);

        public double GetExpendsSum(int userId);

        public double GetReceiptsSum(int userId);

        public double GetAllTransactionSum(int userId);
        
    }
}
