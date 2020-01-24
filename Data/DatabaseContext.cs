using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using routine_explorer.Models;

namespace routine_explorer.Data
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {}
        
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Routine> Routine { get; set; }
        public DbSet<VacantRoom> VacantRooms { get; set; }
        public DbSet<RoutineFileUploaderStatus> RoutineFileUploaderStatus { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Audit> Audit { get; set; }
    }
}