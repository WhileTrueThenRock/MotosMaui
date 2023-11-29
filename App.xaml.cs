namespace MauiMotos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF1cWWhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEZiWH1XcH1QR2RYVkF/Ww==");
            MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 1280;
            const int newHeight = 820;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}