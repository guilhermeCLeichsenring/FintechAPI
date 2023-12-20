using FintechApi.Models.Dtos;
using FintechApi.Models;
using FintechApi.Repositoy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using System.Xml.Linq;
using FintechAPI.Models;
using FintechAPI.Context;

namespace FintechApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public DataBaseContext _dbContext;

        public UserController(DataBaseContext context)
        {
            _userRepository = new UserRepository(context);
            _dbContext = context;

        }


        [HttpGet]
        public ActionResult<IList<UserModel>> GetAll()
        {

            var users = _userRepository.GetAllUsers();
            //.Select(p => p.AsDto());

            try
            {

                if (users != null)
                {
                    return Ok(users);
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
        public ActionResult<UserModel> GetOne([FromRoute] int id)
        {
            var user = _userRepository.GetUserById(id);

            try
            {
                if (user != null)
                {
                    return Ok(user);
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


        [HttpPost]
        public ActionResult<UserModel> Post([FromBody] CreateUserDto userDto)
        {
            UserModel existentUser = _userRepository.GetUserByEmail(userDto.Email);

            if (existentUser != null)
            {
                return BadRequest(new {message = $"The email {userDto.Email} it's being used" });
            }

            UserModel model = new UserModel()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                PhoneNumber = userDto.PhoneNumber,               
                Created = DateTime.Now               
            
            };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _dbContext.Users.Add(model);
                _dbContext.SaveChanges();
                var location = new Uri(Request.GetEncodedUrl() + "/" + model.Id);

                return Created(location, model);


            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't insert this User. More details: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                var idModel = _userRepository.GetUserById(id);

                if (idModel != null)
                {
                    _userRepository.Remove(idModel);
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
        public ActionResult Put([FromRoute] int id, [FromBody] UpdateUserDto userDto)
        {

            var model = _userRepository.GetUserById(id);



            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (model is null)
            {
                return NotFound();
            }

            model.Name = userDto.Name;            
            model.Email = userDto.Email;
            model.PhoneNumber = userDto.PhoneNumber;
           
                


            try
            {
                //_UserRepository.Update(model);
                _dbContext.Users.Update(model);
                _dbContext.SaveChanges();

                return NoContent();

            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't update this User. More details: {error.Message}" });
            }

        }

        [HttpPut("change-password/{id:int}")]
        public ActionResult PutPassword([FromRoute] int id, [FromBody] UpdatePasswordUserDto userDto)
        {

            var model = _userRepository.GetUserById(id);



            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (model is null)
            {
                return NotFound();
            }

           model.Password = userDto.Password;


            try
            {
                //_UserRepository.Update(model);
                _dbContext.Users.Update(model);
                _dbContext.SaveChanges();

                return NoContent();

            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't update this User. More details: {error.Message}" });
            }

        }

    }
}
