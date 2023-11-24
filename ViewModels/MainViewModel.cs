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
            listaAccesorios = new ObservableCollection<string>();
            cargarComboMarcas();
            filtro = 0;
        }

        [ObservableProperty]
        private ObservableCollection<string> listaFabricantes;

        [ObservableProperty]
        private ObservableCollection<string> listaAccesorios;

        [ObservableProperty]
        private int filtro;

        [ObservableProperty]
        private string pDFData;
        //Te obliga a ser privada y que empieze en minúscula, Equivalente a public string PDFData {get,set}

        [RelayCommand]
        public async Task GetFabricantesModelosAsync() //Esto hace referencia al boton de Consultas que salen las tablas de fabricantes y modelos
        {
            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet",
            DBManager.GetFabricantesModelos(), "Reports/FabricantesModelosReport.rdlc");
        }

        public void cargarComboMarcas() //Solo para cargar el picker
        {
            DataTable fabricantesModelosDT = DBManager.GetNombreFabricantes();
            ListaFabricantes = DBUtils.DataTableToCollection(fabricantesModelosDT, "Marcas");
        }



        [RelayCommand] //Cargar el pdf de una marca seleccionada
        public async Task LoadPicker(string marca)
        {
            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet",
            DBManager.GetFabricantesByMarca(marca), "Reports/FabricantesModelosReport.rdlc");

        }

        [RelayCommand]
        public async Task GetAccesoriosAsync() //Esto hace referencia al boton de Consultas que salen las tablas de fabricantes y modelos
        {
            PDFData = await ReportsUtils.GetReport("AccesoriosDataSet",
            DBManager.GetAccesorios(), "Reports/AccesoriosReport.rdlc");
        }

        [RelayCommand]
        public async Task GetFabricantesByAnioGT() //Esto hace referencia al boton de Consultas que salen las tablas de fabricantes y modelos
        {

            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet",
            DBManager.GetAnioGT(filtro), "Reports/FabricantesModelosReport.rdlc");

        }

    }
}
