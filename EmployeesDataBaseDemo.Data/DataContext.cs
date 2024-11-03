using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeesDataBaseDemo.Data;
public class DataContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=EmpDataBase.db");
    }

    // Tables
    public DbSet<Employees> Employees
    {
        get; set; 
    }
}
