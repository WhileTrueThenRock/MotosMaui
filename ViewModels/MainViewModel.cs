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
            cargarComboMarcas();
        }

        [ObservableProperty]
        private ObservableCollection<string> listaFabricantes;

        [ObservableProperty]
        private string pDFData;
        //Te obliga a ser privada y que empieze en minúscula, Equivalente a public string PDFData {get,set}

        [RelayCommand]
        public async Task getFabricantesModelosAsync() //Esto hace referencia al boton de Consultas que salen las tablas de fabricantes y modelos
        {
            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet", 
            DBManager.GetFabricantesModelos(), "Reports/FabricantesModelosReport.rdlc");
        }

        public void cargarComboMarcas() //Esto hace referencia solo al picker para que salgan las marcas
        {
            DataTable fabricantesModelosDT = DBManager.GetNombreFabricantes();
            ListaFabricantes = DBUtils.DataTableToCollection(fabricantesModelosDT, "Marcas");
        }
        


        [RelayCommand]
        public async Task LoadPicker(string marca)
        {
            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet",
            DBManager.GetFabricantesByMarca(marca), "Reports/FabricantesModelosReport.rdlc");

        } 

        
    }
}
