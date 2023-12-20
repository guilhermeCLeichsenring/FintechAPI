namespace FintechApi.Models.Dtos
{
    public class TransactionDto
    {
        public double Value { get; set; }

        public string Description { get; set; }

        public int userId { get; set; }

        public int CategoryId { get; set; }

        public int BankId { get; set; }


    }

    public class CreateTransactionDto
    {
        public double Value { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public int CategoryId {  get; set; }   

        public int BankId { get; set; }
   

    }

    public class UpdateTransactionDto
    {
        public double Value { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int BankId { get; set; }


    }
}
