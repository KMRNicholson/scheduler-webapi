using Microsoft.EntityFrameworkCore;

namespace SchedulerWebApi.Models
{
    public partial class CourseAppointmentContext : DbContext
    {
        public CourseAppointmentContext(DbContextOptions<CourseAppointmentContext> options)
            : base(options)
        {
        }

        public DbSet<CourseAppointment> CourseAppointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseAppointment>()
                .HasKey(c => new {c.CourseId, c.AppointmentId});
        }
    }
}