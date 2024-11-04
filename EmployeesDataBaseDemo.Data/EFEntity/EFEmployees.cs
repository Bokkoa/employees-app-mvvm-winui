using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDataBaseDemo.Data.EFEntity;
public class EFEmployees : IDataHelper<Employees>
{
    private DataContext db;
    private Employees employees;

    public EFEmployees()
    {
        db = new DataContext();
    }
    public int Add(Employees table)
    {
        try
        {
            Console.WriteLine(table.ToString());
            db.Employees.Add(table);
            db.SaveChanges();
            return 1;
        }
        catch(Exception ex)
        {
            throw ex;
            return 0;
        }
    }

    public bool CheckConnection()
    {
        return db.Database.CanConnect();

    }
    public int Delete(int id)
    {

        try
        {
            employees = GetById(id);
            db.Employees.Remove(employees);
            db.SaveChanges();
            return 1;
        }
        catch {
            return 0;
        }
    }
    public List<Employees> GetAll()
    {
        try
        {
            return db.Employees.ToList();
        }
        catch {
            return new List<Employees>();
        }
    }
    public Employees GetById(int id)
    {
        try
        {
            return db.Employees.Find(id);

        }catch
        {
            return new Employees();
        }
    }
    public List<Employees> Search(string searchItem)
    {
        try
        {
            return db.Employees.Where(x => x.Id.ToString() == searchItem || x.Details.Contains(searchItem) || x.FullName.Contains(searchItem) || x.Age.ToString() == searchItem ).ToList();
        }
        catch
        {
            return new List<Employees>();
        }
    }
    public int Update(Employees table)
    {
        try
        {
            db.Employees.Add(table);
            db.SaveChanges();
            return 1;
        }
        catch
        {
            return 0;
        }
    }
}
