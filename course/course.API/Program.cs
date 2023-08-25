using course.API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(option =>
                {
                    var factory = option.InvalidModelStateResponseFactory;
                    option.InvalidModelStateResponseFactory = context =>
                    {
                        var logger = context.HttpContext.RequestServices.GetService<ILogger<Program>>();
                        logger.LogWarning($"gönderdiğiniz http request içinde {context.ModelState.ErrorCount} adet hata var. Ayrıntılar: {string.Join(",", context.ModelState.Keys)} ");
                        return factory(context);
                    };
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddIoC(connectionString);

builder.Services.AddMemoryCache(option =>
{

});

builder.Services.AddResponseCaching(opt =>
{
    //150 MB :)
    opt.SizeLimit = 157286400;
});

//Aşağıdaki işlemler; AddIoC Extension'da yaptık!
//var connectionString = builder.Configuration.GetConnectionString("db");
//builder.Services.AddDbContext<CourseDbContext>(builder => builder.UseSqlServer(connectionString));
//builder.Services.AddScoped<ICourseService, CourseService>();
//builder.Services.AddScoped<ICourseRepository, EFCourseRepository>();
//builder.Services.AddScoped<IUserService, FakeUserService>();
//builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "api.akbank",
                    ValidateAudience = true,
                    ValidAudience = "mobil.akbank",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-bizim-sirrimiz"))

                });


builder.Services.AddCors(option => option.AddPolicy("allow", builder =>
{
    /*
     * http://www.akbank.com.tr
     * https://www.akbank.com.tr
     * https://account.akbank.com.tr
     * https://account.akbank.com.tr:8080
     */
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseResponseCaching();

app.UseCors("allow");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
