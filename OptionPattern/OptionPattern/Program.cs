using OptionPattern.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllersWithViews();

//var smtpSettings = builder.Configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
builder.Services.Configure<SmtpSettings>(
        builder.Configuration.GetSection("SmtpSettings")
    );

var app = builder.Build();

app.Logger.LogInformation("web app oluşturuldu");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

var logger = LoggerFactory.Create(bld => bld.AddConsole()).CreateLogger("Program");

app.MapGet("/health", async ctx =>
{
    logger.LogInformation("Health check OK");
    await ctx.Response.WriteAsync("Healthy...");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Logger.LogInformation("Middleware ve pipeline tamamlandı....");
app.Run();
