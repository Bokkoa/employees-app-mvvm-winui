using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeesDataBaseDemo.Data;


namespace EmployeesDataBaseDemo.ViewModels;

public partial class AddEmployeesViewModel : ObservableRecipient
{
    private readonly IDataHelper<Employees> dataHelper;


    public AddEmployeesViewModel(IDataHelper<Employees> dataHelper)
    {
        this.dataHelper = dataHelper;
        SaveCommand = new RelayCommand(Save);
    }

    [ObservableProperty]
    private Employees employees;

    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string fullName;

    [ObservableProperty]
    private int age;

    [ObservableProperty]
    private string details;

    private void Save()
    {
        var _employee = new Employees
        {
            FullName = FullName,
            Age = Age,
            Details = Details
        };

        dataHelper.Add(_employee);
    }

    // Commands
    public ICommand SaveCommand
    {

        get; set;
    }

}
