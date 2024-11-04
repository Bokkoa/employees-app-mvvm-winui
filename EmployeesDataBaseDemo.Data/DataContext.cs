using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeesDataBaseDemo.Data;
public class DataContext: DbContext
{
    public static string database = "EmpDataBase.db";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var projectPath = AppDomain.CurrentDomain.BaseDirectory;
        var databasePath = Path.Combine(projectPath, database);

        optionsBuilder.UseSqlite($"Data Source={databasePath}",
            sqliteOptionsAction: op => {
                op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

        base.OnConfiguring(optionsBuilder);
    }

    // Tables
    public DbSet<Employees> Employees
    {
        get; set; 
    }
}
