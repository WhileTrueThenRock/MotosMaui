using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMotos.DDBB;
using MauiMotos.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMotos.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            listaFabricantes = new ObservableCollection<string>();
            GetFabricantes();
        }

        [ObservableProperty]
        private ObservableCollection<string> listaFabricantes;

        [ObservableProperty]
        private string pDFData;
        //Te obliga a ser privada y que empieze en minúscula, Equivalente a public string PDFData {get,set}

        [RelayCommand]
        public async Task getFabricantesModelosAsync()
        {
            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet", DBManager.GetFabricantesModelos(), "Reports/FabricantesModelosReport.rdlc");
        }

        public void GetFabricantes()
        {
            DataTable nombreAutoresDT = DBManager.GetNombreFabricantes();
            ListaFabricantes = DBUtils.DataTableToCollection(nombreAutoresDT, "nombre");
        }

    }
}
