using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeniorCollegeScheduler.Models;
using SeniorCollegeScheduler.Models.DataModels;

namespace SeniorCollegeScheduler.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyIdentityUser, UserRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyIdentityUser> MyIdentityUser { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<ProposedClass> ProposedClass { get; set; }
    }
}
