using Microsoft.EntityFrameworkCore;

namespace SchedulerWebApi.Models
{
    public class AssignmentContext : DbContext
    {
        public AssignmentContext(DbContextOptions<AssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }
    }
}