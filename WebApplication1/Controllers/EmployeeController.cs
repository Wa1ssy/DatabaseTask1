using DatabaseTask.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DatabaseTaskDbContext _context;

        public EmployeeController(DatabaseTaskDbContext context)
        {
            _context = context;
        }

        // Index action - default view
        public IActionResult Index()
        {
            return View();
        }

        // Action to fetch employees using the stored procedure
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees
                                    .FromSqlRaw("EXEC GetAllEmployees")
                                    .ToList();

            return View("Index", employees);
        }
    }
}
