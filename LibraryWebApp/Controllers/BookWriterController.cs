using System.Linq;
using LibraryWebApp.Dto;
using LibraryWebApp.Dto.BookDto;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookWriterController : ControllerBase
    {
        private readonly IReader<Book> _reader;

        private readonly IWriter<Book> _writer;

        public BookWriterController(IReader<Book> reader, IWriter<Book> writer)
        {
            
            _writer = writer;
            _reader = reader;

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

        [HttpPut("UpdateBook")]
        public void UpdateBook(int id)
        {
            var book = _reader.GetQuery().FirstOrDefault(x => x.Id == id);
            _writer.Update(book);
        }

        [HttpDelete("DeleteBook")]
        public void DeleteBook(int id)
        {
            var book = _reader.GetQuery().FirstOrDefault(x => x.Id == id);
            _writer.Delete(book);
        }

    }
}
