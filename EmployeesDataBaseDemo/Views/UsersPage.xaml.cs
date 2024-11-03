using EmployeesDataBaseDemo.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace EmployeesDataBaseDemo.Views;

public sealed partial class UsersPage : Page
{
    public UsersViewModel ViewModel
    {
        get;
    }

    public UsersPage()
    {
        ViewModel = App.GetService<UsersViewModel>();
        InitializeComponent();
    }
}
