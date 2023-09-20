using Microsoft.EntityFrameworkCore;

namespace Juke_Box.Models
{
    public class SongDbContext:DbContext
    {
        public SongDbContext(DbContextOptions<SongDbContext>op):base(op)
        {

        }

        public DbSet<Juke>jukes { get; set; }
    }
}
