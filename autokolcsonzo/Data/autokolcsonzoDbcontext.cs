using autokolcsonzo.Models;
using Microsoft.EntityFrameworkCore;

namespace autokolcsonzo.Data
{
    public class autokolcsonzoDbcontext:DbContext
    {
        public autokolcsonzoDbcontext(DbContextOptions<autokolcsonzoDbcontext> options) : base(options) { }
        public DbSet<autok> autok { get; set; }
        public DbSet<kolcsonzesek> kolcsonzesek { get; set; }
        public DbSet<ugyfelek> ugyfelek { get; set; }

    }
}
