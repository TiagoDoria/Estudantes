using Estudantes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Estudantes.Data
{
    public class StudentContext : IdentityDbContext<IdentityUser>
    {
        public StudentContext()
        {
        }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
