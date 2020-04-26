using Microsoft.EntityFrameworkCore;
using RayNote.Models;

namespace RayNote.DataAccessLayer
{
    public class RayNoteDbContext : DbContext
    {
        public RayNoteDbContext(DbContextOptions<RayNoteDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Note> Note { get; set; }
    }
}