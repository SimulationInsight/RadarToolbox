using Microsoft.EntityFrameworkCore;

namespace SimulationInsight.Ais.Database;

public class AisDataContext : DbContext
{
    public DbSet<AisData> AisData { get; set; }

    public string ConnectionString { get; set; }

    public AisDataContext()
    {
        ConnectionString = "Server=localhost;Database=Ais;Trusted_Connection=True;";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(ConnectionString);
}