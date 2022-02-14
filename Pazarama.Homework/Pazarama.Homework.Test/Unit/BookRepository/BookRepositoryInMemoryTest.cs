using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pazarama.Homework.Core.Entity;
using Pazarama.Homework.Data;
using Xunit;

namespace Pazarama.Homework.Test.Unit
{
    public class BookRepositoryInMemoryTest
    {
        [Fact]
        public void BookRepository_FindBook_ReturnRightRecord()
        {
            //Arrange
            var helper = new TestHelper();
            var result = helper.GetInMemoryDataRepository();
            var BookRepository = result.Item1.BookRepository;
            var insertedBook = BookRepository.Insert(new Book()
            {
                Id = 1000,
                Title = "Title",
                ImageUrl = ".",
                Description = "Desc"
            }).Result;
            //Act
            var foundBook = BookRepository.Find(1000).Result;
            //Assert
            Assert.NotNull(foundBook);
            Assert.Equal(insertedBook.Id,foundBook.Id);
            Assert.Equal(insertedBook.Title,foundBook.Title);
            Assert.Equal(insertedBook.Description,foundBook.Description);
            Assert.Equal(insertedBook.ImageUrl,foundBook.ImageUrl);
        }

        [Fact]
        public void BookRepository_FindBook_ReturnNullRecord()
        {
            //Arrange
            var helper = new TestHelper();
            var result = helper.GetInMemoryDataRepository();
            var BookRepository = result.Item1.BookRepository;
            //Act
            var foundBook = BookRepository.Find(1000).Result;
            //Assert
            Assert.Null(foundBook);
        }
    }
}