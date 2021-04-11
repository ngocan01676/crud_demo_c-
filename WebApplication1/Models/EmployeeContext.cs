using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public  virtual DbSet<Employee>  Employees { get; set; }
    }
}
