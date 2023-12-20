namespace FintechApi.Models.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
    }

    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateCategoryDto
    {
        public string Name { get; set; }
    }
}
