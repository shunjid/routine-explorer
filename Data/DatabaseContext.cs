using Microsoft.EntityFrameworkCore;
using routine_explorer.Models;

namespace routine_explorer.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {}

        public DbSet<Routine> Routine { get; set; }
        public DbSet<RoutineFileUploaderStatus> RoutineFileUploaderStatus { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Audit> Audit { get; set; }
    }
}