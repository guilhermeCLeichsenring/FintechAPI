using FintechApi.Repositoy.Interfaces;
using FintechAPI.Context;
using FintechAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FintechApi.Repositoy
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        private readonly DataBaseContext _dbContext;

        public CategoryRepository(DataBaseContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<CategoryModel> GetAllCategories(int userId)
        {   
            var categorys = _dbContext.Categorys.AsNoTracking().Where(b => b.UserId == userId).ToList();

            return categorys;
        }

        public CategoryModel GetCategoryById(int categoryId)
        {
            var category = _dbContext.Categorys.AsNoTracking().Where(b => b.Id == categoryId).FirstOrDefault();

            return category;
        }

        public IEnumerable<CategoryModel> GetAllCategoryExpends(int userId)
        {
            return _dbContext.Categorys.AsNoTracking()
                .Where(c => c.Type == false && c.UserId == userId)
                .ToList();
        }

        public IEnumerable<CategoryModel> GetAllCategoryReceipts(int userId)
        {
            return _dbContext.Categorys.AsNoTracking()
                  .Where(c => c.Type == true && c.UserId == userId)
                  .ToList();
        }

        
    }

}
