using FintechApi.Models;
using FintechApi.Models.Dtos;
using FintechApi.Repositoy;
using FintechAPI.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FintechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : Controller
    {
        private readonly BankRepository _bankRepository;

        public DataBaseContext _dbContext;

        public BankController(DataBaseContext context)
        {
            _bankRepository = new BankRepository(context);
            _dbContext = context;

        }


        [HttpGet]
        public ActionResult<IList<BankModel>> GetAll()
        {
            
            var banks = _bankRepository.GetAllBanks();
                //.Select(p => p.AsDto());

            try
            {
                //var banks = _dbContext.Banks.ToList();

                if (banks != null)
                {
                    return Ok(banks);
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
        public ActionResult<BankModel> GetOne([FromRoute] int id)
        {
            var Bank = _bankRepository.GetBankById(id);

            try
            {
                if (Bank != null)
                {
                    return Ok(Bank);
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
        private ActionResult<BankModel> Post([FromBody] CreateBankDto bankDto)
        {              
            BankModel model = new BankModel()
            {
                Value = bankDto.Value,
                Label = bankDto.Label
               
            };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _bankRepository.Add(model);
                _dbContext.SaveChanges();
                var location = new Uri(Request.GetEncodedUrl() + "/" + model.Id);

                return Created(location, model);


            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't insert this Bank. More details: {error.Message}" });
            }
        }

        
        [HttpPost("postmany")]
        private ActionResult<IEnumerable<BankModel>> PostMany([FromBody] List<CreateBankDto> banksDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                List<BankModel> newModels = new List<BankModel>();

                foreach (var bankDto in banksDto)
                {
                    BankModel model = new BankModel()
                    {
                        Value = bankDto.Value,
                        Label = bankDto.Label
                    };

                    newModels.Add(model);

                    _bankRepository.Add(model);
                }

                _dbContext.SaveChanges();


                var locations = newModels.Select(model => new Uri(Request.GetEncodedUrl() + "/" + model.Id)).ToList();

                return Created(locations.First(), newModels);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't insert these Banks. More details: {error.Message}" });
            }
        }




    

        [HttpDelete("{id:int}")]
        private ActionResult Delete([FromRoute] int id)
        {
            try
            {
                var idModel = _bankRepository.GetBankById(id);

                if (idModel != null)
                {
                    _bankRepository.Remove(idModel);
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
        public ActionResult Put([FromRoute] int id, [FromBody] UpdateBankDto bankDto)
        {

            var model = _bankRepository.GetBankById(id);



            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (model is null)
            {
                return NotFound();
            }

            model.Label = bankDto.Label;
            model.Value = bankDto.Value;

            try
            {
                //_bankRepository.Update(model);
                _dbContext.Banks.Update(model);
                _dbContext.SaveChanges();

                return NoContent();

            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't update this Bank. More details: {error.Message}" });
            }

        }



       

    }
}
