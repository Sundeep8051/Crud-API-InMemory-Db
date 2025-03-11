using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Models;
using MovieStoreApi.Services;

namespace MovieStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookLibrary _bookLibrary;

        public BooksController(IBookLibrary bookLibrary, ILogger<BooksController> logger)
        {
            _bookLibrary = bookLibrary;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAll(){
            return Ok(await _bookLibrary.GetBooks());
        }

        [HttpGet]
        [Route("GetBookById")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id > 0){
            var book = await _bookLibrary.GetBookById(id);
            
            if(book == null){
                return NotFound();
            }
            return Ok(book);
            }
            else return BadRequest();
            
        }

        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            if(String.IsNullOrWhiteSpace(book.Title)){
                return BadRequest("Title is required");
            }

            var result = await _bookLibrary.AddBook(book);
            if(result == StatusCodes.Status201Created){
                return Created();
            }
            else return new ObjectResult(StatusCodes.Status500InternalServerError);
        }
        
        [HttpPut]
        [Route("UpdateBook")]
        public async Task<IActionResult> Put([FromBody] Book book){
            if(book.Id <= 0){
                return BadRequest("invalid book");
            }

            var result = await _bookLibrary.UpdateBook(book);
            return Ok(result);
        }

        [HttpDelete]
        [Route("RemoveBook")]
        public async Task<IActionResult> Delete(int id){
            if(id > 0){
                return Ok(await _bookLibrary.DeleteBook(id));
            }
            else return NotFound();
        }
    }
}