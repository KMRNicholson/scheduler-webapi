using Microsoft.EntityFrameworkCore;

namespace SchedulerWebApi.Models
{
    public partial class UserAppointmentContext : DbContext
    {
        public UserAppointmentContext(DbContextOptions<UserAppointmentContext> options)
            : base(options)
        {
        }

        public DbSet<UserAppointment> UserAppointments { get; set; }
    }
}