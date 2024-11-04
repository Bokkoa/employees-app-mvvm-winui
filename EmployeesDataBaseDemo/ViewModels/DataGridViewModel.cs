using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeesDataBaseDemo.Data;
using EmployeesDataBaseDemo.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace EmployeesDataBaseDemo.ViewModels;

public partial class DataGridViewModel : ObservableRecipient
{
    private readonly IDataHelper<Employees> dataHelper;

    // STATE MUST BE in cammelcase because is internal state view binding
    [ObservableProperty]
    private List<Employees> listOfEmployees;    

    [ObservableProperty]
    private Employees employee;

    // Command
    public ICommand NewDataCommand
    {
        get;
    }

    public ICommand RefreshCommand
    {
        get;
    }

    public ICommand SearchCommand
    {
        get;
    }

    public ICommand DeleteCommand
    {
        get;
    }
    public DataGridViewModel(IDataHelper<Employees> dataHelper)
    {
        this.dataHelper = dataHelper;
        NewDataCommand = new RelayCommand<XamlRoot>(newData);
        RefreshCommand = new RelayCommand(LoadData);
        SearchCommand = new RelayCommand<string?>(Search);
        DeleteCommand = new RelayCommand(Delete);

        
        // MUST BE in Pascal because is external view binding
        ListOfEmployees = new List<Employees>();

        employee = new Employees();

        LoadData();
    }

    private async void newData(XamlRoot xamlRoot)
    {
        ContentDialog dialog = new ContentDialog();

        // xamlroot must be set in the case of  a Content Dialog running in Desktop app
        dialog.XamlRoot = xamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = "Add Employee";
        dialog.CloseButtonText = "Cancel";
        dialog.DefaultButton = ContentDialogButton.Primary;
        dialog.Content = new EmployeesUserControl();

        await dialog.ShowAsync();
    }

    private async void Delete()
    {
        var hasConnection = await Task.Run(() => dataHelper.CheckConnection());

        if (hasConnection)
        {
            var result = await Task.Run(() => dataHelper.Delete(Employee.Id));

            if (result == 1)
            {
                LoadData();
            }

        }
    }

    private async void LoadData()
    {

        var hasConnection = await Task.Run(() => dataHelper.CheckConnection());

        if (hasConnection)
        {
            // MUST BE in Pascal because is external view binding
            ListOfEmployees = await Task.Run(() => dataHelper.GetAll());

        }
    }

    private async void Search(string searchItem)
    {

        var hasConnection = await Task.Run(() => dataHelper.CheckConnection());

        if (hasConnection)
        {
            // MUST BE in Pascal because is external view binding
            ListOfEmployees = await Task.Run(() => dataHelper.Search(searchItem));

        }
    }
}
