using Microsoft.EntityFrameworkCore;
using EducationSystem.Domain.Models;
using EducationSystem.Repository;
using EducationSystem.Repository.Interfaces;
using EducationSystem.Repository.Implementation;
using EducationSystem.Service.Interface;
using EducationSystem.Service.Implementation;
using EducationSystem.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<CourseUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Register Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserQuizAttemptRepository, UserQuizAttemptRepository>();

// Register Services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IUserQuizAttemptService, UserQuizAttemptService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
