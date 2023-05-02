using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Models;

public class CinemasContext : DbContext
{
    public CinemasContext(DbContextOptions<CinemasContext> options)
    : base(options)
    { }
    public DbSet<CinemasItem> CinemasItems { get; set; } = null!;
}
