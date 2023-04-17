using Azure.Identity;
using InterthreadNotesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterthreadNotesApi.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User { UserId = 1, UserName = "UserJJB1" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, UserName = "UserJJB2" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 3, UserName = "UserJJB3" });

            modelBuilder.Entity<Note>().HasData(new Note { UserId = 1, NoteId = 1, NoteText = "UserJJB1TestNote1", NoteCreatedTimestamp = DateTime.Now });
            modelBuilder.Entity<Note>().HasData(new Note { UserId = 1, NoteId = 2, NoteText = "UserJJB1TestNote2", NoteCreatedTimestamp = DateTime.Now });
            modelBuilder.Entity<Note>().HasData(new Note { UserId = 2, NoteId = 3, NoteText = "UserJJB2TestNote1", NoteCreatedTimestamp = DateTime.Now });
            modelBuilder.Entity<Note>().HasData(new Note { UserId = 3, NoteId = 4, NoteText = "UserJJB3TestNote1", NoteCreatedTimestamp = DateTime.Now });
        }                                                                                              
    }
}
