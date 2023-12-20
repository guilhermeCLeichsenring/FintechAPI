using FintechApi.Models;
using FintechAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FintechAPI.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<TransactionModel> Transactions { get; set; }

        public DbSet<CategoryModel> Categorys { get; set; }

        public DbSet<BankModel> Banks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
