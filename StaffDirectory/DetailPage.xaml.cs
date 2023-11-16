using System.Web;

namespace StaffDirectory;

public partial class DetailPage : ContentPage
{
    private DatabaseService _databaseService;
    private Employee _employee;

    public DetailPage()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var route = Shell.Current.CurrentState.Location.OriginalString;
        var queryParams = HttpUtility.ParseQueryString(new Uri(route).Query);

        if (queryParams["employeeId"] is string employeeIdString && int.TryParse(employeeIdString, out int employeeId))
        {
            Employee employee = await _databaseService.GetEmployeeByIdAsync(employeeId);
            if (employee != null)
            {
                DisplayEmployeeDetails(employee);
            }
            else
            {
                Console.WriteLine("Employee not found");
                // Optionally, navigate back or show an error message
            }
        }
    }

    private void DisplayEmployeeDetails(Employee employee)
    {
        FirstNameLabel.Text = employee.FirstName;
        LastNameLabel.Text = employee.LastName;
        DepartmentLabel.Text = employee.Department;
        RoleLabel.Text = employee.Role;
        MobileLabel.Text = employee.MobileNumber;
        EmailLabel.Text = employee.Email;
    }

    private async void OnModifyClicked(object sender, EventArgs e)
    {
        // Implement the ModifyEmployeePage with existing employee data
        // await Shell.Current.GoToAsync($"ModifyEmployeePage?employeeId={employee.Id}");
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        bool confirmed = await DisplayAlert("Delete Employee", "Are you sure?", "Yes", "No");
        if (confirmed)
        {
            // Assume employee is the current employee object being displayed
            await _databaseService.DeleteEmployeeAsync(_employee);
            await Shell.Current.GoToAsync(".."); // Go back to the previous page using Shell navigation
        }
    }
}


