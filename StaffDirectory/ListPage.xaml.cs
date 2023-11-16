namespace StaffDirectory;

public partial class ListPage : ContentPage
{
    private DatabaseService _databaseService;

    public ListPage()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
        LoadEmployeeAsync();
    }

    private async void LoadEmployeeAsync()
    {
        var employees = await _databaseService.GetEmployeeAsync();
        EmployeesListView.ItemsSource = employees;
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Employee selectedEmployee)
        {
            // Clear selection
            EmployeesListView.SelectedItem = null;

            // Navigate to DetailPage with the employee object or ID
            var detailPage = new DetailPage(selectedEmployee);
            await Navigation.PushAsync(detailPage);
        }
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadEmployeeAsync(); // Refresh list when the page appears
    }
}

