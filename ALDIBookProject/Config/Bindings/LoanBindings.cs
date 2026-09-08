using ALDIBookProject.Repositories.Implementations;
using ALDIBookProject.Repositories.Interfaces;
using ALDIBookProject.Services.Implementations;
using ALDIBookProject.Services.Interfaces;

namespace ALDIBookProject.Config.Bindings
{
    public class LoanBindings
    {
        public static void bind(IServiceCollection services)
        {
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILoanService, LoanService>();
        }
    }
}
