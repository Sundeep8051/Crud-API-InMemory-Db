using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieStoreApi.Models;

namespace MovieStoreApi.DbStore
{
    public interface IBookRepository
    {
        List<Book> Books();
    }
}