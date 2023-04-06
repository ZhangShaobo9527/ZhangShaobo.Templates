using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using __PROJECT_NAME__.Shared.Models;
using __PROJECT_NAME__.Shared.ServerServices;

namespace __PROJECT_NAME__.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>?> GetAllBooksAsync()
        {
            return await this.bookService.GetBooksAsync();
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<Book?> GetBookByIdAsync(int Id)
        {
            return await this.bookService.GetBookByIdAsync(Id);
        }
    }
}
