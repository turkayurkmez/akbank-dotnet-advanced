using course.Application.MapProfile;
using course.Application.Services;
using course.Infrastructure.Data;
using course.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace course.API.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, string connectionString)
        {


            services.AddDbContext<CourseDbContext>(builder => builder.UseSqlServer(connectionString));
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseRepository, FakeCourseRepository>();
            services.AddScoped<IUserService, FakeUserService>();
            services.AddAutoMapper(typeof(MappingProfile));

            return services;

        }
    }
}
