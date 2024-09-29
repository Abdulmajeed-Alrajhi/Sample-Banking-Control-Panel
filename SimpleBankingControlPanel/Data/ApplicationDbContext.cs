using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleBankingControlPanel.Domain;

namespace SimpleBankingControlPanel.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<SearchParameter> SearchParameters { get; set; }
    public DbSet<Client> Clients { get; set; }
}