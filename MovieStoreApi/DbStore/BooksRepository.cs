using MovieStoreApi.Models;

namespace MovieStoreApi.DbStore
{
    public class BooksRepository : IBookRepository
    {
        private List<Book>? books;

        public List<Book> Books(){
            if(books == null){
                books = [];
                return books;
            }
            else return books;
        }
    }
}