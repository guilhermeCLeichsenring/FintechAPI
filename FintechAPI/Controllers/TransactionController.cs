using FintechApi.Models.Dtos;
using FintechApi.Repositoy;
using FintechAPI.Context;
using FintechAPI.Models;
using FintechAPI.Models.Helper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FintechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly TransactionRepository _transactionRepository;

        public DataBaseContext _dbContext;


        public TransactionController(DataBaseContext context)
        {
            _transactionRepository = new TransactionRepository(context);
            _dbContext = context;

        }


        [HttpGet()]
        public ActionResult<IList<TransactionModel>> GetAll(int userId)
        {

            var transactions = _transactionRepository.GetAllTransactionsByUserId(userId);

            try
            {

                if (transactions != null)
                {
                    return Ok(transactions);
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

        [HttpGet("bycategory")]
        public ActionResult<IList<TransactionModel>> GetAllByCategory(int categoryId)
        {

            var transactions = _transactionRepository.GetTransactionsByIdCategory(categoryId);

            try
            {

                if (transactions != null)
                {
                    return Ok(transactions);
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
        public ActionResult<TransactionModel> GetOne([FromRoute] int id)
        {
            var transaction = _transactionRepository.GetTransactionById(id);

            try
            {
                if (transaction != null)
                {
                    return Ok(transaction);
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
        public ActionResult<IList<TransactionModel>> GetAllReceipts(int userId)
        {

            var transactions = _transactionRepository.GetAllReceipts(userId);

            try
            {

                if (transactions != null)
                {
                    return Ok(transactions);
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

        [HttpGet("expends")]
        public ActionResult<IList<TransactionModel>> GetAllExpends(int userId)
        {

            var transactions = _transactionRepository.GetAllExpends(userId);

            try
            {

                if (transactions != null)
                {
                    return Ok(transactions);
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
        public ActionResult<TransactionModel> PostReceipt([FromBody] CreateTransactionDto transactionDto)
        {

            UserModel? userModel = _dbContext.Users.Find(transactionDto.UserId);


            if (userModel == null || userModel.Id != transactionDto.UserId)
            {
                return NotFound();
            }


            
            TransactionModel model = new TransactionModel
            {
                Type = true,
                Value = transactionDto.Value,
                Description = transactionDto.Description,
                Created = DateTime.Now,
                UserId = transactionDto.UserId,
                CategoryId = transactionDto.CategoryId,
                BankId = transactionDto.BankId,

            };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _transactionRepository.Add(model);
                _dbContext.SaveChanges();
                var location = new Uri(Request.GetEncodedUrl() + "/" + model.Id);

                return Created(location, model);


            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't insert this Transaction. More details: {error.Message}" });
            }
        }

        [HttpPost("expend")]
        public ActionResult<TransactionModel> PostExpend([FromBody] CreateTransactionDto transactionDto)
        {
            var userModel = _dbContext.Users.Find(transactionDto.UserId);

            if (userModel == null)
            {
                return NotFound(userModel);
            }

            TransactionModel model = new TransactionModel()
            {
                Type = false,
                Value = transactionDto.Value,
                Description = transactionDto.Description,
                Created = DateTime.Now,
                UserId = transactionDto.UserId,
                CategoryId = transactionDto.CategoryId,
                BankId = transactionDto.BankId,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _transactionRepository.Add(model);
                _dbContext.SaveChanges();
                var location = new Uri(Request.GetEncodedUrl() + "/" + model.Id);

                return Created(location, model);


            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't insert this Transaction. More details: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                var idModel = _transactionRepository.GetTransactionById(id);

                if (idModel != null)
                {
                    _transactionRepository.Remove(idModel);
                    _dbContext.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception error)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put([FromRoute] int id, [FromBody] UpdateTransactionDto transactionDto)
        {

            var model = _transactionRepository.GetTransactionById(id);


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (model is null)
            {
                return NotFound();
            }

            model.Value = transactionDto.Value;
            model.Description = transactionDto.Description;
            model.BankId = transactionDto.BankId;
            model.CategoryId = transactionDto.CategoryId;

            try
            {
                _transactionRepository.Update(model);
                _dbContext.SaveChanges();

                return NoContent();

            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't update this Transaction. More details: {error.Message}" });
            }

        }

        // operations

        [HttpGet("total-receipts")]
        public ActionResult<SumTotal> GetTotalReceipts(int userId)
        {
            UserModel? userModel = _dbContext.Users.Find(userId);
            if (userModel == null || userModel.Id != userId)
            {
                return NotFound();
            }

            double totalReceipts = _transactionRepository.GetReceiptsSum(userId);

            if (totalReceipts == null) 
            { 
                return NotFound();
            }

            SumTotal result = new SumTotal() { Total = totalReceipts};

            return Ok(result);
        }

        [HttpGet("total-expends")]
        public ActionResult<SumTotal> GetTotalExpends(int userId)
        {
            UserModel? userModel = _dbContext.Users.Find(userId);
            if (userModel == null || userModel.Id != userId)
            {
                return NotFound();
            }

            double totalExpends = _transactionRepository.GetExpendsSum(userId);

            SumTotal result = new SumTotal() { Total = totalExpends };

            return Ok(result);
        }

        [HttpGet("total-transactions")]
        public ActionResult<SumTotal> GetTotalTransactions(int userId)
        {
            UserModel? userModel = _dbContext.Users.Find(userId);
            if (userModel == null || userModel.Id != userId)
            {
                return NotFound();
            }

            double totalTransactions = _transactionRepository.GetAllTransactionSum(userId);

            SumTotal result = new SumTotal() { Total = totalTransactions };

            return Ok(result);
        }

    }
}
