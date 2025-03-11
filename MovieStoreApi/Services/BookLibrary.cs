using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieStoreApi.DbStore;
using MovieStoreApi.Models;

namespace MovieStoreApi.Services
{
    public class BookLibrary : IBookLibrary
    {
        private IBookRepository BookRepository { get; }
        public BookLibrary(IBookRepository bookRepository){
            BookRepository = bookRepository;
        }

        public Task<int> AddBook(Book book)
        {
            var books = BookRepository.Books();
            books.Add(book);
            return Task.FromResult(StatusCodes.Status201Created);
        }

        public Task<int> DeleteBook(int id)
        {
            var book = BookRepository.Books().Where(x=>x.Id == id).FirstOrDefault();
            if(book!=null)
                {BookRepository.Books().Remove(book);
                return Task.FromResult(StatusCodes.Status200OK);
                }
            else return Task.FromResult(StatusCodes.Status404NotFound);
        }

        public Task<Book>? GetBookById(int id)
        {
            var book = BookRepository.Books().Where(x=>x.Id == id).FirstOrDefault();
            if(book!=null)
                return Task.FromResult(book);
            else return null;
        }

        public Task<List<Book>> GetBooks()
        {
            return Task.FromResult(BookRepository.Books());
        }

        public Task<Book>? UpdateBook(Book book)
        {
            var existingBook = BookRepository.Books().Where(b => b.Id == book.Id).FirstOrDefault();
            if(existingBook!=null)
            {   
                existingBook.Title = book.Title;
                existingBook.AuthorName = book.AuthorName;
                existingBook.Price = book.Price;
                return Task.FromResult(book);
            }
            else return null;
        }
    }
}