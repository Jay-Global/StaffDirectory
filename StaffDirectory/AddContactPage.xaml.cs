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
        // Validate the inputs
        if (string.IsNullOrWhiteSpace(FirstNameEntry.Text) ||
            string.IsNullOrWhiteSpace(LastNameEntry.Text) ||
            string.IsNullOrWhiteSpace(DepartmentEntry.Text) ||
            string.IsNullOrWhiteSpace(RoleEntry.Text) ||
            string.IsNullOrWhiteSpace(MobileEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        // Validate the mobile number (assumes only numbers are valid)
        if (!MobileEntry.Text.All(char.IsDigit))
        {
            await DisplayAlert("Error", "Please enter a valid mobile number (digits only).", "OK");
            return;
        }

        // Basic email validation
        if (!EmailEntry.Text.Contains('@') || !EmailEntry.Text.Contains('.'))
        {
            await DisplayAlert("Error", "Please enter a valid email address.", "OK");
            return;
        }

        // If validation passes, create a new Employee object
        var newEmployee = new Employee
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            Department = DepartmentEntry.Text,
            Role = RoleEntry.Text,
            MobileNumber = MobileEntry.Text,
            Email = EmailEntry.Text
        };

        // Add the new employee to the database
        await _databaseService.AddEmployeeAsync(newEmployee);
        await DisplayAlert("Success", "Contact saved successfully", "OK");
        await Shell.Current.GoToAsync(nameof(ListPage)); // Go back to the list page
    }

}
