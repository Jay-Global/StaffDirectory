namespace StaffDirectory;

public partial class SettingsPage : ContentPage
{
    private SettingsViewModel _viewModel;

    public SettingsPage()
    {
        InitializeComponent();
        _viewModel = new SettingsViewModel();
        BindingContext = _viewModel;
    }

    private void OnThemeToggled(object sender, ToggledEventArgs e)
    {
        // Your logic to toggle the theme
        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }

    // Other event handlers if necessary
}
