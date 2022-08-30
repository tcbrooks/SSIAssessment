using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
namespace WebApplication2.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }
    
    /// <summary>
    /// Creates the Claim table in the database
    /// </summary>
    public DbSet<Claim> Claim { get; set; }
}