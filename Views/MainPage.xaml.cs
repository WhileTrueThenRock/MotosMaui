using MauiMotos.ViewModels;

namespace MauiMotos
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void accesorios_chip_Touch(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
        {

        }
    }
}