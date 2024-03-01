using Alfred.Models_db;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using MySql.EntityFrameworkCore.Extensions;
using System.Reflection;


namespace Alfred.Data;

public class AlfredContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connString = "server=127.0.0.1;user id=alfred;password=alfred_psw;port=3306;database=alfred";
        optionsBuilder.UseMySQL(connString, options =>
        {
            options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });
        base.OnConfiguring(optionsBuilder);
    }
}

