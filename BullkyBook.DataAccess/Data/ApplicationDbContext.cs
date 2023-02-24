using BullkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BullkyBook.DataAccess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
    }
}
