using Microsoft.EntityFrameworkCore;
using MVCLabb1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//for dbcontext
builder.Services.AddDbContext<BookBorrowDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefConnections")));
var app = builder.Build();

        //builder.Services.AddCors((setup) => setup.AddPolicy("default", (option =>
        //{
        //    option.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        //})));
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}/{BookId?}/{BorrowId?}");

app.Run();
