using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeniorCollegeScheduler.Models;
using SeniorCollegeScheduler.Models.DataModels;

namespace SeniorCollegeScheduler.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<ProposedClass> ProposedClass { get; set; }
    }
}
