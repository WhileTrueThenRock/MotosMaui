using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiMotos.ViewModels
{
    public partial class FrontViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task Navegar(String pagina)
        {
            await Shell.Current.GoToAsync("//" + pagina);
        }
    }
}
