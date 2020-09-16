using LibraryWebApp.Dto;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookWriterController : ControllerBase
    {
        private readonly IWriter<Book> _writer;

        public BookWriterController(IWriter<Book> writer)
        {
            
            _writer = writer;
        }

        [HttpPost("CreateBook")]
        public void CreateBook(CreateBookDto bookDto)
        {
            var book = new Book
            {
                Name = bookDto.Name,
                Authors = bookDto.Authors,
                PageAmount = bookDto.PageAmount,
                Year = bookDto.Year,
                CityName = bookDto.CityName,
                PublishingOfficeName = bookDto.PublishingOfficeName,
                IsOriginal = bookDto.IsOriginal,
                CountryName = bookDto.CountryName,
                Isbn = bookDto.Isbn,
                Udk = bookDto.Udk,
                Bbk = bookDto.Bbk,
            };
            _writer.Create(book);
        }
    }
}
