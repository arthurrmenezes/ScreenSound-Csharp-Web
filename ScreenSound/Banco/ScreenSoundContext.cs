using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;
internal class ScreenSoundContext : DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    private string connectionString = "Data Source=ULTRANOTE;Initial Catalog=ScreenSound;" + // BANCO DO NOTE ULTRA
        "Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
    
    //private string connectionString = "Data Source=DESKTOP-SD3LB7D;" +                     // BANCO DO PC ARTHUR
    //    "Initial Catalog=ScreenSound;" +
    //    "Integrated Security=True;" +
    //    "Encrypt=True;" +
    //    "Trust Server Certificate=True";           

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}