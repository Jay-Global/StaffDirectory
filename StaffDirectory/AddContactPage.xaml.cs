namespace StaffDirectory;

public partial class AddContactPage : ContentPage
{
    private DatabaseService _databaseService;

    public AddContactPage()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
    }

    private async void OnSaveContactClicked(object sender, EventArgs e)
    {
        var newEmployee = new Employee
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            Department = DepartmentEntry.Text,
            Role = RoleEntry.Text,
            MobileNumber = MobileEntry.Text,
            Email = EmailEntry.Text
        };

        await _databaseService.AddEmployeeAsync(newEmployee);
        await DisplayAlert("Success", "Contact saved successfully", "OK");
        await Navigation.PopAsync(); // Go back to the previous page
    }
}
