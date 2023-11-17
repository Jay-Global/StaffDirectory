using System.ComponentModel;
using System.Runtime.CompilerServices;


public class SettingsViewModel : INotifyPropertyChanged
{
    private bool _isDarkThemeEnabled;
    public bool IsDarkThemeEnabled
    {
        get => _isDarkThemeEnabled;
        set
        {
            if (_isDarkThemeEnabled != value)
            {
                _isDarkThemeEnabled = value;
                OnPropertyChanged();
                // Apply the theme
                Application.Current.UserAppTheme = _isDarkThemeEnabled ? AppTheme.Dark : AppTheme.Light;
            }
        }
    }

    private double _fontSize = 12; // Default font size
    public double FontSize
    {
        get => _fontSize;
        set
        {
            if (_fontSize != value)
            {
                _fontSize = value;
                OnPropertyChanged();
            }
        }
    }

    private double _brightness = 1; // Default brightness
    public double Brightness
    {
        get => _brightness;
        set
        {
            if (_brightness != value)
            {
                _brightness = value;
                OnPropertyChanged();
            }
        }
    }

    private int _selectedFontIndex;
    public int SelectedFontIndex
    {
        get => _selectedFontIndex;
        set
        {
            if (_selectedFontIndex != value)
            {
                _selectedFontIndex = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


