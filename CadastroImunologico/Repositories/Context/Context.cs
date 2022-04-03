using Microsoft.EntityFrameworkCore;

public class Imunologico
{
    public int Id { get; set; }
    public string? Fabricante { get; set; }

     public int AnoLote { get; set; }
}

public class Context : DbContext
{
    public DbSet<Imunologico>? Imunologicos { get; set; }

    public string DbPath { get; }

    public Context()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Imunologicos.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}



