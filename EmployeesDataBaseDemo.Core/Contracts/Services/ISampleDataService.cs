using EmployeesDataBaseDemo.Core.Models;

namespace EmployeesDataBaseDemo.Core.Contracts.Services;

// Remove this class once your pages/features are using your data.
public interface ISampleDataService
{
    Task<IEnumerable<SampleOrder>> GetGridDataAsync();
}
