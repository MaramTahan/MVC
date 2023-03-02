using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Repositary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add database support
builder.Services.AddDbContext<westcoasteducationContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

// Add dependency injection...
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ITeacherUserRepository, TeacherUserRepository>();
builder.Services.AddScoped<IStudentUserRepository, StudentUserRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//seed the database..
//using here is as a directive
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try{
    var context = services.GetRequiredService<westcoasteducationContext>();
    await context.Database.MigrateAsync();
    await SeedData.LoadCoursesData(context);
    await SeedData.LoadTeacherData(context);
    await SeedData.LoadStudentData(context);
    }
    catch(Exception ex){
        Console.WriteLine("{0}", ex.Message);
    throw;
    }
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
