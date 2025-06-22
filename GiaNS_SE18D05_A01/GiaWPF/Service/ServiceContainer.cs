using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.Services; // Chỉ giữ dòng này
using DataAccessLayer.Repositories;
// Xóa dòng: using BusinessLogicLayer.Service;

namespace GiaWPF.Services
{
    public static class ServiceContainer
    {
        private static ServiceProvider? _serviceProvider;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register Repositories
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IRoomRepository, RoomRepository>();
            services.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();

            // Register Services
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRoomTypeService, RoomTypeService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() where T : notnull
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("Services not configured. Call ConfigureServices first.");
            return _serviceProvider.GetRequiredService<T>();
        }

        public static void Dispose()
        {
            _serviceProvider?.Dispose();
        }
    }
}
