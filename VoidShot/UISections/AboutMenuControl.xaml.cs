using VoidShot.Theme;
using Other;
using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VoidShot.Controls
{
    public partial class AboutMenuControl : UserControl
    {
        private MainWindow? _mainWindow;
        private bool _isInitialized;
        private static readonly HttpClient _httpClient = new() { Timeout = TimeSpan.FromSeconds(5) };

        // Cached resources
        private Brush? _themeColor;
        private FontFamily? _fontFamily;



        // Public properties for MainWindow access
        public Label AboutSpecsControl => AboutSpecs;
        public ScrollViewer AboutMenuScrollViewer => AboutMenu;

        public AboutMenuControl()
        {
            InitializeComponent();
        }

        public void Initialize(MainWindow mainWindow)
        {
            if (_isInitialized) return;

            _mainWindow = mainWindow;
            _isInitialized = true;

            // Use ThemeManager directly for theme color
            _themeColor = new SolidColorBrush(ThemeManager.ThemeColor);
            _fontFamily = Application.Current.TryFindResource("Atkinson Hyperlegible") as FontFamily
                ?? new FontFamily("Segoe UI"); // Fallback font


        }





        private void VersionBorder_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var version = AboutDesc.Content?.ToString()?.TrimStart('v') ?? "1.0.0";
                Process.Start(new ProcessStartInfo
                {
                    FileName = $"https://github.com/VoidShot/VoidShot/releases/tag/v{version}",
                    UseShellExecute = true
                });
            }
            catch { }
        }
    }
}
