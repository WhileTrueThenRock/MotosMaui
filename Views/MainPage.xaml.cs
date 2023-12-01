using MauiMotos.ViewModels;
using Syncfusion.Maui.Picker;

namespace MauiMotos
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
            SfDatePicker datePicker = new SfDatePicker()
            {
                Mode = PickerMode.Dialog
            };
        }

        private void ClickToShowPopup_Clicked(object sender, EventArgs e)
        {
            popup.Show();
        }
        private void Button_ClickedIni(object sender, System.EventArgs e)
        {
            this.pickerIni.IsOpen = true;
        }
        private void Button_ClickedFin(object sender, System.EventArgs e)
        {
            this.pickerFin.IsOpen = true;
        }
    }
}