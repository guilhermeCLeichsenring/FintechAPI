using FintechAPI.Context;
using FintechApi.Controllers;
using FintechApi.Repositoy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FintechApi.Models;

namespace FintechApi.Test.Controller
{
    public class BankControllerTest
    {
        [Fact(Skip = "In development")]
        public void BankController_GetAll_ReturnsOkResult()
        {
            // Arrange            

            var bankRepositoryMock = new Mock<BankRepository>();
            bankRepositoryMock.Setup(repo => repo.GetAllBanks()).Returns(new List<BankModel>());


            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new BankController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact(Skip = "In development")]
        public void BankController_GetOne_WithValidId_ReturnsOkResult()
        {
            // Arrange
            
            var bankId = 987;
            var bankModel = new BankModel
            {
                Id = bankId,
                Value = "456",
                Label = "banco-central"
            };

            var bankRepositoryMock = new Mock<BankRepository>();
            bankRepositoryMock.Setup(repo => repo.GetBankById(bankId)).Returns(bankModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new BankController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetOne(bankId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
