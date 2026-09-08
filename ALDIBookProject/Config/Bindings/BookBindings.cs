using ALDIBookProject.Repositories.Implementations;
using ALDIBookProject.Repositories.Interfaces;
using ALDIBookProject.Services.Implementations;
using ALDIBookProject.Services.Interfaces;

namespace ALDIBookProject.Config.Bindings
{
    public class BookBindings
    {
        public static void bind(IServiceCollection services)
        {
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IBookService, BookService>();
        }
    }
}
