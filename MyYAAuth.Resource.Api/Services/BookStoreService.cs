using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYAAuth.Resource.Api.Models
{
    public interface IBookStoreService
    {
        List<Book> GetBooks();
        Order GetOrdersByUserId(Guid userId);
    }

    public class BookStoreService : IBookStoreService
    {
        private readonly List<Order> _internalOrders = new List<Order>()
        {
            new Order()
            {
                UserId = Guid.Parse("e2d80add-3db9-465e-b00b-cc0be173d76a"),
                BookIds = new int[] { 1, 3 },
            },
            new Order()
            {
                UserId = Guid.Parse("a834d832-d2b6-44e8-ab1f-bd12423c8fbd"),
                BookIds = new int[] { 2, 3, 4 }
            },
        };

        public List<Book> GetBooks()
        {
            return  new List<Book> {
            
                new Book() { Id = 1, Author="Author1", Title = "Title1", Price = 123.45M},
                new Book() { Id = 2, Author="Author2", Title = "Title2", Price = 223.45M},
                new Book() { Id = 3, Author="Author3", Title = "Title3", Price = 323.45M},
                new Book() { Id = 4, Author="Author4", Title = "Title4", Price = 423.45M},
            };
        }

        public Order GetOrdersByUserId(Guid userId)
        {
            return _internalOrders.FirstOrDefault(o => o.UserId == userId);
        }
    }
}