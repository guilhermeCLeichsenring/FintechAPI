using FintechApi.Models.Dtos;
using FintechApi.Repositoy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using FintechAPI.Context;
using FintechAPI.Models;

namespace FintechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;

        public DataBaseContext _dbContext;

        public CategoryController(DataBaseContext context)
        {
            _categoryRepository = new CategoryRepository(context);
            _dbContext = context;

        }


        [HttpGet]
        public ActionResult<IList<CategoryModel>> GetAll(int userId)
        {

            var categorys = _categoryRepository.GetAllCategories(userId);
            //.Select(p => p.AsDto());

            try
            {
               
                if (categorys != null)
                {
                    return Ok(categorys);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<CategoryModel> GetOne([FromRoute] int id)
        {
            var category = _categoryRepository.GetCategoryById(id);

            try
            {
                if (category != null)
                {
                    return Ok(category);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("receipts")]
        public ActionResult<IList<CategoryModel>> GetAllCategoryReceipts(int userId)
        {

            var categorys = _categoryRepository.GetAllCategoryReceipts(userId);
            //.Select(p => p.AsDto());

            try
            {

                if (categorys != null)
                {
                    return Ok(categorys);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("expend")]
        public ActionResult<IList<CategoryModel>> GetAllCategoryExpends(int userId)
        {

            var categorys = _categoryRepository.GetAllCategoryExpends(userId);
            //.Select(p => p.AsDto());

            try
            {

                if (categorys != null)
                {
                    return Ok(categorys);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("receipt")]
        public ActionResult<CategoryModel> PostCategoryReceipt([FromBody] CreateCategoryDto categoryDto)
        {
            UserModel? user = _dbContext.Users.Find(categoryDto.UserId);

            if (user == null || user.Id != categoryDto.UserId)
            {
                return NotFound();
            }

            CategoryModel model = new CategoryModel()
            {
                Type = true,
                Name = categoryDto.Name,
                UserId = user.Id,
                Created = DateTime.Now

            };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _categoryRepository.Add(model);
                _dbContext.SaveChanges();
                var location = new Uri(Request.GetEncodedUrl() + "/" + model.Id);

                return Created(location, model);


            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't insert this Category. More details: {error.Message}" });
            }
        }

        [HttpPost("expend")]
        public ActionResult<CategoryModel> PostCategoryExpend([FromBody] CreateCategoryDto categoryDto)
        {
            UserModel? user = _dbContext.Users.Find(categoryDto.UserId);

            if (user == null || user.Id != categoryDto.UserId)
            {
                return NotFound();
            }

            CategoryModel model = new CategoryModel()
            {
                Type = false,
                Name = categoryDto.Name,
                UserId = user.Id,
                Created = DateTime.Now

            };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _categoryRepository.Add(model);
                _dbContext.SaveChanges();
                var location = new Uri(Request.GetEncodedUrl() + "/" + model.Id);

                return Created(location, model);


            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't insert this Category. More details: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                var idModel = _categoryRepository.GetCategoryById(id);

                if (idModel != null)
                {
                    _categoryRepository.Remove(idModel);
                    _dbContext.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put([FromRoute] int id, [FromBody] UpdateCategoryDto CategoryDto)
        {

            var model = _categoryRepository.GetCategoryById(id);



            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (model is null)
            {
                return NotFound();
            }

            model.Name = CategoryDto.Name;
        
            try
            {
                _categoryRepository.Update(model);
                 _dbContext.SaveChanges();

                return NoContent();

            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't update this Category. More details: {error.Message}" });
            }

        }
    }
}

       

        
   