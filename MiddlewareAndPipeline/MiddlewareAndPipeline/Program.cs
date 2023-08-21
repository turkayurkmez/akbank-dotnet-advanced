var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseWelcomePage();
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<<<<<");
    await next();
    await context.Response.WriteAsync(">>>>>");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("=======");
    await next();
    await context.Response.WriteAsync("=======");
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(async context =>
{
    await context.Response.WriteAsync("Uygulama çalıştı");
});

app.Run();