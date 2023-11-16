namespace StaffDirectory;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAddNewContactClicked(object sender, EventArgs e)
    {
        // Use Shell navigation
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void OnViewContactsClicked(object sender, EventArgs e)
    {
        // Use Shell navigation
        await Shell.Current.GoToAsync(nameof(ListPage));
    }

}


