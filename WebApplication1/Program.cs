using DatabaseTask.Core.Domain;
using DatabaseTask.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<DatabaseTaskDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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

        // CALLING STORED PROCEDURE TO GET ALL EMPLOYEES
        using (var context = new DatabaseTaskDbContext())
        {
            var employees = GetAllEmployees(context);
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName}");
            }
        }
    }

    // Method to call stored procedure
    public static List<Employee> GetAllEmployees(DatabaseTaskDbContext context)
    {
        return context.Employees
                      .FromSqlRaw("EXEC GetAllEmployees")
                      .ToList();
    }
}
