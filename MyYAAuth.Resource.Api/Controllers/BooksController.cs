using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyYAAuth.Resource.Api.Models;

namespace MyYAAuth.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookStoreService _bookStoreService;
        public BooksController(IBookStoreService bookStoreService)
        {
            this._bookStoreService = bookStoreService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAvailableBooks(){
            return Ok(this._bookStoreService.GetBooks());
        }
    }
}