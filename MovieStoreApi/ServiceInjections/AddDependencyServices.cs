using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieStoreApi.DbStore;
using MovieStoreApi.Models;
using MovieStoreApi.Services;

namespace MovieStoreApi.ServiceInjections
{
    public static class AddDependencyServices{
    public static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<IBookRepository, BooksRepository>();
        services.AddScoped<IBookLibrary, BookLibrary>();
    }
    }
    
}