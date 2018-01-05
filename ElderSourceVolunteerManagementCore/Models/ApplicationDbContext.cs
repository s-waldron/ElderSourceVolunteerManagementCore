using Microsoft.EntityFrameworkCore;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Volunteer2Opportunity> Volunteer2Opportunities { get; set; }
    }// end ApplicationDbContext class
}// end ElderSourceVolunteerManagementCore.Models namespace
