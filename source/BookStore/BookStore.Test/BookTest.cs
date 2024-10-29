using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookStore.BAL;
using BookStore.Controllers;
using BookStore.Model;
using BookStore.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BookStore.Test
{
    [TestClass]
    public class BookTest
    {
        private  readonly BookController bookController;
        private Mock<IBookService> _mockservice;
        private IBooksRepository _booksRepository;
        [TestInitialize]
        [Fact]
        public void SetUP()
        {

            _mockservice = new Mock<IBookService>();
            _booksRepository = new BookRepository(_mockservice.Object);

        }
        [TestMethod]
        [Fact]
        public async Task GetBookOwnersByAgeGroup()
        {
            // arrange
            var mockData = new List<Owner>
            {

                new Owner { Name="Jane",Age=30,Books= new List<Book>{ new Book { Name="Book1",Type="HardCover"},new Book { Name="Book2",Type="PaperCover"} } },
                new Owner { Name="Ankita",Age=10,Books= new List<Book>{ new Book { Name="Book3",Type="HardCover"},new Book { Name="Book4",Type="PaperCover"} } },

            };
            _mockservice.Setup(repo => repo.GetData()).ReturnsAsync(mockData);
            // Act
            var result = await _booksRepository.GetBooksOwnersByAgeGroup() ;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Above18.Count);
            Assert.AreEqual("Book1", result.Above18.First().Books.First().Name);
            Assert.AreEqual(1, result.Below18.Count);
            Assert.AreEqual("Book3", result.Below18.First().Books.First().Name);
        }
        [TestMethod]
        [Fact]
        public async Task GetBookOwnersByAgeGroupEmptyList()
        {
            //Arrange
            _mockservice.Setup(repo => repo.GetData()).ReturnsAsync(new List<Owner>());
            //Act
            var result = await _booksRepository.GetBooksOwnersByAgeGroup();

            //Assert
            Assert.AreEqual(0, result.Below18.Count);
            Assert.AreEqual(0, result.Above18.Count);


        }
        [TestMethod]
        [Fact]
        public async Task GetBookOwnersByAgeGroupNull()
        {
            //Arrange
            _mockservice.Setup(repo => repo.GetData()).ReturnsAsync(( List<Owner>)null);

            // Act
            var result = await _booksRepository.GetBooksOwnersByAgeGroup();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Below18.Count);
            Assert.AreEqual(0, result.Above18.Count);

        }
    }
}
