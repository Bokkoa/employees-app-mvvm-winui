using System.Collections.Generic;

namespace EmployeesDataBaseDemo.Data;
public interface IDataHelper<Table>
{

    // READ
    List<Table> GetAll();
    List<Table> Search(string searchItem);
    Table GetById(int id);


    // WRITE
    int Add(Table table);
    int Update(Table table);
    int Delete(int id);


    bool CheckConnection();

}
