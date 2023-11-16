namespace StaffDirectory;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
        Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
    }
}

