using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pazarama.Homework.Core.Entity;
using Pazarama.Homework.Data;
using Xunit;

namespace Pazarama.Homework.Test.Unit.BookService
{
    public class BookServiceInMemoryTest
    {
        private Services.Services.BookService _bookService;
        private DatabaseContext _context;

        public BookServiceInMemoryTest()
        {

            var helper = new TestHelper();
            var result = helper.GetInMemoryDataRepository();
            _context = result.Item2;
            _bookService = new Services.Services.BookService(result.Item1);

            //seed
            var Categories = new List<Category>()
            {
                new Category { Name = "cat1" },
                new Category { Name = "cat2" },
                new Category { Name = "cat3" },
            };
            var Books = new List<Book>()
            {
                new Book
                {
                    Title = "book1",
                    Description = "",
                    ImageUrl = "",
                    Categories = new List<Category>()
                        { Categories[0], Categories[1] }
                },
                new Book
                {
                    Title = "book2",
                    Description = "",
                    ImageUrl = "https://img.kitapyurdu.com/v1/getImage/fn:4890428/wh:true/miw:200/mih:200",
                    Categories = new List<Category>() { Categories[0], Categories[2] }
                },
            };
            _context.Books.AddRange(Books);
            _context.Categories.AddRange(Categories);
            _context.SaveChanges();
        }

        [Fact]
        public void BookService_GetAllBook_ReturnCaregorizedBook()
        {
            //Arrange
            var categories = _context.Categories.ToList();
            categories.OrderBy(x => x.Id);
            //Act
            var categoryOneBooks = _bookService.GetAllBooks(categories[0].Id).Result;
            var categoryTwoBooks = _bookService.GetAllBooks(categories[1].Id).Result;
            var categoryThreeBooks = _bookService.GetAllBooks(categories[2].Id).Result;
            var categoryFourBooks = _bookService.GetAllBooks(12).Result;
            //Assert
            Assert.NotNull(categoryOneBooks);
            Assert.NotNull(categoryTwoBooks);
            Assert.NotNull(categoryTwoBooks);
            Assert.NotNull(categoryFourBooks);
            Assert.Equal(categoryOneBooks.Count, 2);
            Assert.Equal(categoryTwoBooks.Count, 1);
            Assert.Equal(categoryThreeBooks.Count, 1);
            Assert.Equal(categoryFourBooks.Count, 0);
        }

        [Fact]
        public void BookService_GetAllBook_ReturnAllBook()
        {
            //Arrange

            //Act
            var books = _bookService.GetAllBooks(null).Result;
           
            //Assert
            Assert.NotNull(books);
            Assert.Equal(books.Count, 2);
        }
    }
}