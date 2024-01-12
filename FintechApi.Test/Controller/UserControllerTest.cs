using FintechApi.Controllers;
using FintechApi.Models.Dtos;
using FintechApi.Repositoy;
using FintechAPI.Context;
using FintechAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechApi.Test.Controller
{
    public class UserControllerTest
    {
        [Fact(Skip = "In development")]
        public void UserController_GetAll_ReturnsOkResult()
        {
            // Arrange
            var userRepositoryMock = new Mock<UserRepository>();
            userRepositoryMock.Setup(repo => repo.GetAllUsers()).Returns(new List<UserModel>());


            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new UserController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact(Skip = "In development")]
        public void UserController_GetOne_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var userId = 987;
            var userModel = new UserModel {
                Id = userId,
                Name = "John Doe",
                Email = "jhon@email.com",
                Password = "5244345",
                PhoneNumber = "1234567890",
                Created = DateTime.Now
            };

            var userRepositoryMock = new Mock<UserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserById(userId)).Returns(userModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new UserController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetOne(userId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void UserController_Post_WithValidDto_ReturnsCreatedResult()
        {
            // Arrange
            var createUserDto = new CreateUserDto {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                PhoneNumber = "123456789" };

            var userRepositoryMock = new Mock<UserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByEmail(createUserDto.Email)).Returns((UserModel)null);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new UserController(dataBaseContextMock.Object);

            // Act
            var result = controller.Post(createUserDto);

            // Assert
            Assert.IsType<CreatedResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void UserController_Delete_WithValidId_ReturnsNoContent()
        {
            // Arrange
            var userId = 987;
            var userModel = new UserModel
            {
                Id = userId,
                Name = "John Doe",
                Email = "jhon@email.com",
                Password = "5244345",
                PhoneNumber = "1234567890",
                Created = DateTime.Now
            };
            var userRepositoryMock = new Mock<UserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserById(userId)).Returns(userModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new UserController(dataBaseContextMock.Object);

            // Act
            var result = controller.Delete(userId);

            // Assert
            Assert.IsType<NoContentResult>(result);

        }

        [Fact(Skip = "In development")]
        public void UserController_Put_WithValidId_ReturnsNoContent()
        {
            // Arrange

            var userId = 987;
            var userModel = new UserModel
            {
                Id = userId,
                Name = "John Doe",
                Email = "jhon@email.com",
                Password = "5244345",
                PhoneNumber = "1234567890",
                Created = DateTime.Now
            };

            var updateUserDto = new UpdateUserDto
            {
                Name = "John Dauiersd",
                Email = "john.doe@example.com",
                PhoneNumber = "123456789"
            };

            var userRepositoryMock = new Mock<UserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserById(userId)).Returns(userModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new UserController(dataBaseContextMock.Object);

            // Act
            var result = controller.Put(userId, updateUserDto);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact(Skip = "In development")]
        public void UserController_PutPassword_WithValidId_ReturnsNoContent()
        {
            // Arrange

            var userId = 987;
            var userModel = new UserModel
            {
                Id = userId,
                Name = "John Doe",
                Email = "jhon@email.com",
                Password = "5244345",
                PhoneNumber = "1234567890",
                Created = DateTime.Now
            };

            var updatePasswordUserDto = new UpdatePasswordUserDto
            {
                Password = "5767576756"
            };

            var userRepositoryMock = new Mock<UserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserById(userId)).Returns(userModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new UserController(dataBaseContextMock.Object);

            // Act
            var result = controller.PutPassword(userId, updatePasswordUserDto);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

    }
}   



