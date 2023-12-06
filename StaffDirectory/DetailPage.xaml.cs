namespace StaffDirectory;
using Microsoft.Maui.Controls;

public partial class DetailPage : ContentPage
{
    private DatabaseService _databaseService;
    private Employee _currentEmployee;

    // Constructor that takes the employee or employeeId
    public DetailPage(Employee employee)
    {
        InitializeComponent();
        _databaseService = new DatabaseService(); // Instance of DatabaseService
        _currentEmployee = employee;
        PopulateEmployeeDetails();
    }

    private void PopulateEmployeeDetails()
    {
        FirstNameEntry.Text = _currentEmployee.FirstName;
        LastNameEntry.Text = _currentEmployee.LastName;
        DepartmentEntry.Text = _currentEmployee.Department;
        RoleEntry.Text = _currentEmployee.Role;
        MobileEntry.Text = _currentEmployee.MobileNumber;
        EmailEntry.Text = _currentEmployee.Email;
    }


    private async void OnUpdateContactClicked(object sender, EventArgs e)
    {
        _currentEmployee.FirstName = FirstNameEntry.Text;
        _currentEmployee.LastName = LastNameEntry.Text;
        _currentEmployee.Department = DepartmentEntry.Text;
        _currentEmployee.Role = RoleEntry.Text;
        _currentEmployee.MobileNumber = MobileEntry.Text;
        _currentEmployee.Email = EmailEntry.Text;

        await _databaseService.UpdateEmployeeAsync(_currentEmployee);
        await DisplayAlert("Success", "Contact updated successfully", "OK");
        await Navigation.PopAsync(); // Go back to the previous page
    }

    private async void OnDeleteContactClicked(object sender, EventArgs e)
    {
        await _databaseService.DeleteEmployeeAsync(_currentEmployee);
        await DisplayAlert("Success", "Contact deleted successfully", "OK");
        await Navigation.PopAsync(); // Go back to the previous page
    }
}




