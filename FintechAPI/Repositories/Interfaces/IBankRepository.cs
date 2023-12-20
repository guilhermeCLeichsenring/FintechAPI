using FintechApi.Models;

namespace FintechApi.Repositoy.Interfaces
{
    public interface IBankRepository
    {
        public IEnumerable<BankModel>  GetAllBanks();

        public BankModel GetBankById(int bankId);

    }
}
