using FintechAPI.Models;

namespace FintechApi.Repositoy.Interfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<CategoryModel> GetAllCategories(int userId);

        public CategoryModel GetCategoryById(int category);

        public IEnumerable<CategoryModel> GetAllCategoryExpends(int userId);

        public IEnumerable<CategoryModel> GetAllCategoryReceipts(int userId);

    }
}
