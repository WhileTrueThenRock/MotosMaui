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

    }
}