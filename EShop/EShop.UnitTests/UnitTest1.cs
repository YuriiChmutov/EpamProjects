using System;
using System.Collections.Generic;
using System.Collections;
using EShop.DAL.Repositories;
using EShop.WEB.Controllers;
using EShop.WEB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using EShop.DAL.Entities;

namespace EShop.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<ProductRepository> mock = new Mock<ProductRepository>();
            mock.Setup(m => m.GetAll().ToArray()).Returns(new Product[] {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"},
            new Product {ProductId = 3, Name = "P3"},
            new Product {ProductId = 4, Name = "P4"},
            new Product {ProductId = 5, Name = "P5"}
            });
            // create a controller and make the page size 3 items
            ProductController controller = new ProductController();
            controller.PageSize = 3;
            // Act
            IndexViewModel result
            = (IndexViewModel)controller.Index(null, 2).Model;
            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        //    [TestMethod]
        //    public void Can_Send_Pagination_View_Model()
        //    {
        //        // Arrange
        //        Mock<EFUnitOfWork> mock = new Mock<EFUnitOfWork>();
        //        mock.Setup(m => m.Products.GetAll()).Returns(new Product[] {
        //        new Product {ProductId = 1, Name = "P1"},
        //        new Product {ProductId = 2, Name = "P2"},
        //        new Product {ProductId = 3, Name = "P3"},
        //        new Product {ProductId = 4, Name = "P4"},
        //        new Product {ProductId = 5, Name = "P5"}
        //        });
        //        // Arrange
        //        ProductController controller = new ProductController();
        //        controller.PageSize = 3;
        //        // Act
        //        IndexViewModel result
        //        = (IndexViewModel)controller.Index(null, 2).Model;
        //        // Assert
        //        PageInfo pageInfo = result.PageInfo;
        //        Assert.AreEqual(pageInfo.CurrentPage, 2);
        //        Assert.AreEqual(pageInfo.ItemsPerPage, 3);
        //        Assert.AreEqual(pageInfo.TotalItems, 5);
        //        Assert.AreEqual(pageInfo.TotalPages, 2);
        //    }

        //    //[TestMethod]
        //    //public void Can_Filter_Products()
        //    //{
        //    //    // Arrange
        //    //    // - create the mock repository
        //    //    Mock<EFUnitOfWork> mock = new Mock<EFUnitOfWork>();
        //    //    mock.Setup(m => m.Products.GetAll()).Returns(new Product[] {
        //    //    new Product {ProductId = 1, Name = "P1", CategoryId = 1},
        //    //    new Product {ProductId = 2, Name = "P2", CategoryId = 1},
        //    //    new Product {ProductId = 3, Name = "P3", CategoryId = 2},
        //    //    new Product {ProductId = 4, Name = "P4", CategoryId = 2},
        //    //    new Product {ProductId = 5, Name = "P5", CategoryId = 3}
        //    //    });
        //    //    // Arrange - create a controller and make the page size 3 items
        //    //    ProductController controller = new ProductController();
        //    //    controller.PageSize = 3;
        //    //    // Action
        //    //    Product[] result = ((IndexViewModel)controller.Index("Cat2", 1).Model)
        //    //    .Products.ToArray();
        //    //    // Assert
        //    //    Assert.AreEqual(result.Length, 2);
        //    //    Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
        //    //    Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "Cat2");
        //    //}


        //}
    }
}
