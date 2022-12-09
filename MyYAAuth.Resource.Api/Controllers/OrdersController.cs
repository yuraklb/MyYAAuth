using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyYAAuth.Resource.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace MyYAAuth.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IBookStoreService _bookStoreService;
        private Guid UserId
        {
            get
            {
                return Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
        }

        public OrdersController(ILogger<OrdersController> logger, IBookStoreService bookStoreService)
        {
            _logger = logger;
            this._bookStoreService = bookStoreService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        // [Authorize]
        [Route("")]
        public IActionResult GetOrders()
        {
            var order = _bookStoreService.GetOrdersByUserId(this.UserId);

            if (order == null)
            {
                return Ok(Enumerable.Empty<Book>());
            }

            var booksInOrder = _bookStoreService.GetBooks().Where(b => order.BookIds.Contains(b.Id));

            return Ok(booksInOrder);
        }
    }
}