using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services;

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReaderController : ControllerBase
    {
        private readonly IReader<Book> _reader;
        public BookReaderController(IReader<Book> reader)
        {
            _reader = reader;
        }

        [HttpGet]
        public Book GetFirstBook()
        {
            return _reader.GetItems().FirstOrDefault();
        }
    }
}
