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
            listaAccesorios = new ObservableCollection<string>();
            ListaFiltrosAccesorios=new ObservableCollection<string>();
            CargarComboAccesorios();
            chipsSeleccionado = "casco.png";
            TextChipName = "Gratian";
        }

        [ObservableProperty]
        private string chipsSeleccionado;

        [ObservableProperty]
        private string textChipName;

        [ObservableProperty]
        private ObservableCollection<string> listaFiltrosAccesorios;

        [ObservableProperty]
        private ObservableCollection<string> listaAccesorios;


        public void CargarComboAccesorios() //Solo para cargar el picker de accesorios
        {
            DataTable accesorios = DBManager.GetNombreAccesorios();
            ListaAccesorios = DBUtils.DataTableToCollection(accesorios, "Nombre");
        }

        [RelayCommand] //Para añadir chips
        public void CargarFiltroAccesorios(string accesorio)
        {
            if (accesorio != null)
            {
                if (!ListaFiltrosAccesorios.Contains(accesorio))
                {
                    ListaFiltrosAccesorios.Add(accesorio);
                }
            }
        }

        [RelayCommand] //Para borrar chips
        public void BorrarFiltroAccesorios(string accesorio)
        {
            ListaFiltrosAccesorios.Remove(accesorio);
        }


        [RelayCommand]
        public async Task Navegar(String pagina)
        {
            await Shell.Current.GoToAsync("//" + pagina);
        }
    }
}
