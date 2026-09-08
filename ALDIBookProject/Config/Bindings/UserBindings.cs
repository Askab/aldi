using ALDIBookProject.Repositories.Implementations;
using ALDIBookProject.Repositories.Interfaces;
using ALDIBookProject.Services.Implementations;
using ALDIBookProject.Services.Interfaces;

namespace ALDIBookProject.Config.Bindings
{
    public class UserBindings
    {
        public static void bind(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
