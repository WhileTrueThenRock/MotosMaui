using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMotos.DDBB;
using MauiMotos.Utils;
using System.Collections.ObjectModel;
using System.Data;

namespace MauiMotos.ViewModels
{
    public partial class FrontViewModel : ObservableObject
    {

        public FrontViewModel() 
        {

        }

        [RelayCommand]
        public async Task Navegar(String pagina)
        {
            await Shell.Current.GoToAsync("//" + pagina);
        }
    }

}
