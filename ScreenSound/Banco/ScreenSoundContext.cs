using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;
internal class ScreenSoundContext : DbContext
{
    public DbSet<Artista> Artistas;

    private string connectionString = "Data Source=DESKTOP-SD3LB7D;" +
        "Initial Catalog=ScreenSound;" +
        "Integrated Security=True;" +
        "Encrypt=True;" +
        "Trust Server Certificate=True";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}