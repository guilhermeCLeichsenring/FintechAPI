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

namespace FintechApi.Test.Controller
{
    public class CategoryControllerTest
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
        public void CategoryController_GetAll_ReturnsOkResult()
        {
            // Arrange

            var user = UserMock();
            var userId = user.Id;

            var categoryRepositoryMock = new Mock<CategoryRepository>();
            categoryRepositoryMock.Setup(repo => repo.GetAllCategories(userId)).Returns(new List<CategoryModel>());


            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new CategoryController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetAll(userId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact(Skip = "In development")]
        public void CategoryController_GetOne_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var user = UserMock();
            var userId = user.Id;

            var categoryId = 987;
            var categoryModel = new CategoryModel
            {
                Id = categoryId,
                Name = "salary",
                Type = true,
                Created = DateTime.Now
            };

            var categoryRepositoryMock = new Mock<CategoryRepository>();
            categoryRepositoryMock.Setup(repo => repo.GetCategoryById(categoryId)).Returns(categoryModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new CategoryController(dataBaseContextMock.Object);

            // Act
            var result = controller.GetOne(userId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void CategoryController_PostReceipts_WithValidDto_ReturnsCreatedResult()
        {
            // Arrange
            var user = UserMock();
            var userId = user.Id;

            var createCategoryDto = new CreateCategoryDto
            {
                Name = "salary",
                UserId = userId,
            };

            var categoryId = 987;
            var categoryModel = new CategoryModel()
            {
                Id = categoryId,
                Type = true,
                Name = createCategoryDto.Name,
                UserId = user.Id,
                Created = DateTime.Now
            };

            var categoryRepositoryMock = new Mock<CategoryRepository>();
            categoryRepositoryMock.Setup(repo => repo.Add(categoryModel));

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new CategoryController(dataBaseContextMock.Object);

            // Act
            var result = controller.PostCategoryReceipt(createCategoryDto);

            // Assert
            Assert.IsType<CreatedResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void CategoryController_PostExpends_WithValidDto_ReturnsCreatedResult()
        {
            // Arrange
            var user = UserMock();
            var userId = user.Id;

            var createCategoryDto = new CreateCategoryDto
            {
                Name = "rent",
                UserId = userId,
            };

            var categoryId = 987;
            var categoryModel = new CategoryModel()
            {
                Id = categoryId,
                Type = false,
                Name = createCategoryDto.Name,
                UserId = user.Id,
                Created = DateTime.Now
            };

            var categoryRepositoryMock = new Mock<CategoryRepository>();
            categoryRepositoryMock.Setup(repo => repo.Add(categoryModel));

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new CategoryController(dataBaseContextMock.Object);

            // Act
            var result = controller.PostCategoryExpend(createCategoryDto);

            // Assert
            Assert.IsType<CreatedResult>(result.Result);
        }

        [Fact(Skip = "In development")]
        public void CategoryController_Delete_WithValidId_ReturnsNoContent()
        {
            // Arrange
            var user = UserMock();
            var userId = user.Id;

            var categoryId = 987;
            var categoryModel = new CategoryModel
            {
                Id = categoryId,
                Name = "salary",
                Type = true,
                Created = DateTime.Now
            };
            var categoryRepositoryMock = new Mock<CategoryRepository>();
            categoryRepositoryMock.Setup(repo => repo.GetCategoryById(categoryId)).Returns(categoryModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new CategoryController(dataBaseContextMock.Object);

            // Act
            var result = controller.Delete(categoryId);

            // Assert
            Assert.IsType<NoContentResult>(result);

        }

        [Fact(Skip = "In development")]
        public void CategoryController_Put_WithValidId_ReturnsNoContent()
        {
            // Arrange

            var user = UserMock();
            var userId = user.Id;

            var updateCategoryDto = new UpdateCategoryDto
            {
                Name = "salary",                
            };

            var categoryId = 987;
            var categoryModel = new CategoryModel()
            {
                Id = categoryId,
                Type = true,
                Name = updateCategoryDto.Name,
                UserId = user.Id,
                Created = DateTime.Now
            };

            var categoryRepositoryMock = new Mock<CategoryRepository>();
            categoryRepositoryMock.Setup(repo => repo.GetCategoryById(categoryId)).Returns(categoryModel);

            var dataBaseContextMock = new Mock<DataBaseContext>();

            var controller = new CategoryController(dataBaseContextMock.Object);

            // Act
            var result = controller.Put(userId, updateCategoryDto);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        
    }
}
