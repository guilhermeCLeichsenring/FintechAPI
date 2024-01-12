using FintechAPI.Context;
using FintechApi.Controllers;
using FintechApi.Models.Dtos;
using FintechAPI.Models;
using FintechApi.Repositoy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FintechAPI.Controllers;

namespace FintechApi.Test.Controller
{
    public class TransactionControllerTest
    {

        public UserModel UserMock()
        {
            return new UserModel()
            {
                Id = 789,
                Name = "John Doe",
                Email = "jhon@email.com",
                Password = "5244345",
                PhoneNumber = "1234567890",
                Created = DateTime.Now
            };
        }


        [Fact(Skip = "In development")]
        public void TransactionController_GetAll_ReturnsOkResult()
        {
            // Arrange

            var user = UserMock();
            var userId = user.Id;

            var transactionRepositoryMock = new Mock<TransactionRepository>();
            transactionRepositoryMock.Setup(repo => repo.GetAllTransactionsByUserId(userId)).Returns(new List<TransactionModel>());


            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetAll(userId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact(Skip = "In development")]
        public void TransactionController_GetAllReceipts_ReturnsOkResult()
        {
            // Arrange

            var user = UserMock();
            var userId = user.Id;

            var transactionRepositoryMock = new Mock<TransactionRepository>();
            transactionRepositoryMock.Setup(repo => repo.GetAllReceipts(userId)).Returns(new List<TransactionModel>());


            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetAllReceipts(userId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact(Skip = "In development")]
        public void TransactionController_GetAllExpends_ReturnsOkResult()
        {
            // Arrange

            var user = UserMock();
            var userId = user.Id;

            var transactionRepositoryMock = new Mock<TransactionRepository>();
            transactionRepositoryMock.Setup(repo => repo.GetAllExpends(userId)).Returns(new List<TransactionModel>());


            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetAllExpends(userId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact(Skip = "In development")]
        public void TransactionController_GetAllByCategory_ReturnsOkResult()
        {
            // Arrange

            var categoryId = 45354;

            var transactionRepositoryMock = new Mock<TransactionRepository>();
            transactionRepositoryMock.Setup(repo => repo.GetTransactionsByIdCategory(categoryId)).Returns(new List<TransactionModel>());


            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetAllByCategory(categoryId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact(Skip = "In development")]
        public void TransactionController_GetOne_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var user = UserMock();
            var userId = user.Id;

            var transactionId = 987;
            var TransactionModel = new TransactionModel
            {
                Id = transactionId,
                Value = 576.87,
                Description = "Test",
                Type = true,
                Created = DateTime.Now,
                UserId = userId,
                CategoryId = 54,
                BankId = 1,
                
            };

            var transactionRepositoryMock = new Mock<TransactionRepository>();
            transactionRepositoryMock.Setup(repo => repo.GetTransactionById(transactionId)).Returns(TransactionModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetOne(userId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void TransactionController_PostReceipts_WithValidDto_ReturnsCreatedResult()
        {
            // Arrange
            var user = UserMock();
            var userId = user.Id;

            var createTransactionDto = new CreateTransactionDto
            {
                Value = 1,
                Description = "Test",
                UserId = userId,
                CategoryId = 1,
                BankId = 1,

            };

            var transactionId = 987;
            var TransactionModel = new TransactionModel()
            {
                Id = transactionId,
                Type = true,
                Value = createTransactionDto.Value,
                Description= createTransactionDto.Description,
                CategoryId = createTransactionDto.CategoryId,
                BankId = createTransactionDto.BankId,
                UserId = user.Id,
                Created = DateTime.Now
            };

            var transactionRepositoryMock = new Mock<TransactionRepository>();
            transactionRepositoryMock.Setup(repo => repo.Add(TransactionModel));

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);

            // Act
            var result = controller.PostReceipt(createTransactionDto);

            // Assert
            Assert.IsType<CreatedResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void TransactionController_PostExpends_WithValidDto_ReturnsCreatedResult()
        {
            // Arrange
            var user = UserMock();
            var userId = user.Id;
            
            var createTransactionDto = new CreateTransactionDto
            {
                Value = 1,
                Description = "Test",
                UserId = userId,
                CategoryId = 1,
                BankId = 1,

            };

            var transactionId = 987;
            var TransactionModel = new TransactionModel()
            {
                Id = transactionId,
                Type = false,
                Value = createTransactionDto.Value,
                Description = createTransactionDto.Description,
                CategoryId = createTransactionDto.CategoryId,
                BankId = createTransactionDto.BankId,
                UserId = user.Id,
                Created = DateTime.Now
            };

            var transactionRepositoryMock = new Mock<TransactionRepository>();
            transactionRepositoryMock.Setup(repo => repo.Add(TransactionModel));

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);

            // Act
            var result = controller.PostExpend(createTransactionDto);

            // Assert
            Assert.IsType<CreatedResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void TransactionController_Delete_WithValidId_ReturnsNoContent()
        {
            // Arrange
            var user = UserMock();
            var userId = user.Id;

            var transactionId = 987;
            var TransactionModel = new TransactionModel
            {
                Id = transactionId,
                Value = 576.87,
                Description = "Test",
                Type = true,
                Created = DateTime.Now,
                UserId = userId,
                CategoryId = 54,
                BankId = 1,

            };
            var transactionRepositoryMock = new Mock<TransactionRepository>();
            transactionRepositoryMock.Setup(repo => repo.GetTransactionById(transactionId)).Returns(TransactionModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);

            // Act
            var result = controller.Delete(transactionId);

            // Assert
            Assert.IsType<NoContentResult>(result);

        }

        [Fact(Skip = "In development")]
        public void TransactionController_Put_WithValidId_ReturnsNoContent()
        {
            // Arrange

            var user = UserMock();
            var userId = user.Id;

            var updateTransactionDto = new UpdateTransactionDto
            {
                Value = 3445,
                Description = "TestUpdate",
                BankId= 1,
                CategoryId= 1,
            };

            var transactionId = 987;
            var TransactionModel = new TransactionModel()
            {
                Id = transactionId,
                Type = false,
                Value = updateTransactionDto.Value,
                Description = updateTransactionDto.Description,
                CategoryId = updateTransactionDto.BankId,
                BankId = updateTransactionDto.BankId,
                UserId = user.Id,
                Created = DateTime.Now
            };

            var transactionRepositoryMock = new Mock<TransactionRepository>();
            transactionRepositoryMock.Setup(repo => repo.GetTransactionById(transactionId)).Returns(TransactionModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);

            // Act
            var result = controller.Put(userId, updateTransactionDto);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        //Operations

        [Fact(Skip = "In development")]
        public void GetTotalReceipts_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new TransactionController(dataBaseContextMock.Object);
            int userId = 1;

            // Act
            var result = controller.GetTotalReceipts(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void GetTotalReceipts_ReturnsNotFound_WhenReceiptsSumIsNull()
        {
            // Arrange
            var dataBaseContextMock = new Mock<DataBaseContext>();
            var transactionRepositoryMock = new Mock<TransactionRepository>();
            dataBaseContextMock.Setup(d => d.Users.Find(It.IsAny<int>())).Returns(new UserModel());
            transactionRepositoryMock.Setup(repo => repo.GetReceiptsSum(It.IsAny<int>()));

            var controller = new TransactionController(dataBaseContextMock.Object);
            int userId = 1;

            // Act
            var result = controller.GetTotalReceipts(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void GetTotalExpends_ReturnsNotFound_WhenReceiptsSumIsNull()
        {
            // Arrange
            double? sum;

            var dataBaseContextMock = new Mock<DataBaseContext>();
            var transactionRepositoryMock = new Mock<TransactionRepository>();
            dataBaseContextMock.Setup(d => d.Users.Find(It.IsAny<int>())).Returns(new UserModel());
            transactionRepositoryMock.Setup(repo => repo.GetReceiptsSum(It.IsAny<int>()));

            var controller = new TransactionController(dataBaseContextMock.Object);
            int userId = 1;

            // Act
            var result = controller.GetTotalReceipts(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

    }
}
