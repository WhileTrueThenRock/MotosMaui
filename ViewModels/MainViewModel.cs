using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMotos.DDBB;
using MauiMotos.Utils;
using System.Collections.ObjectModel;
using System.Data;
using Syncfusion.Maui.Core;
using Material.Components.Maui;
using SkiaSharp.Views.Maui;
using System.Security.Cryptography;
namespace MauiMotos.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            listaFabricantes = new ObservableCollection<string>();
            listaClientes = new ObservableCollection<string>();
            listaAccesorios = new ObservableCollection<string>();
            listaFiltrosAccesorios = new ObservableCollection<string>();
            CargarComboMarcas();
            CargarComboClientes();
            CargarComboAccesorios();
            anioMenor = 1900;
            anioMayor = 2024;
            precioMenor = 0;
            precioMayor = 0;
            SwitchEstado = false;
            fechaIni = DateTime.Now;
            fechaFin = DateTime.Now;
            imagenSeleccionada = "";

            chipsSeleccionado = "casco.png";



        }
        private void Chip_Touch(object sender, SKTouchEventArgs e)
        {
            if (sender is Chip)
    {
                // Acciones al hacer clic en el chip (por ejemplo, cambiar la imagen)
                ChipsSeleccionado = "casco.png";
            }
        }

        [ObservableProperty]
        private string chipsSeleccionado;

        [ObservableProperty]
        private string imagenSeleccionada;

        [ObservableProperty]
        private DateTime pickerIni;

        [ObservableProperty]
        private ObservableCollection<string> listaFabricantes;

        [ObservableProperty]
        private ObservableCollection<string> listaClientes;

        [ObservableProperty]
        private ObservableCollection<string> listaAccesorios;

        [ObservableProperty]
        private ObservableCollection<string> listaFiltrosAccesorios;

        [ObservableProperty]
        private int anioMenor;

        [ObservableProperty]
        private int anioMayor;

        [ObservableProperty]
        private int precioMenor;

        [ObservableProperty]
        private int precioMayor;

        [ObservableProperty]
        private string resultadoPrecios;

        [ObservableProperty]
        private string resultadoFecha;

        [ObservableProperty]
        private Boolean switchEstado;

        [ObservableProperty]
        private DateTime fechaIni;

        [ObservableProperty]
        private DateTime fechaFin;

        [ObservableProperty]
        private string pDFData;

        //Te obliga a ser privada y que empieze en minúscula, Equivalente a public string PDFData {get,set}

        [RelayCommand]
        public async Task GetFabricantesModelosAsync() //Esto hace referencia al boton de Consultas que salen las tablas de fabricantes y modelos
        {
            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet",
            DBManager.GetFabricantesModelos(), "Reports/FabricantesModelosReport.rdlc");
        }

        public void CargarComboMarcas() //Solo para cargar el picker de motos
        {
            DataTable fabricantesModelosDT = DBManager.GetNombreFabricantes();
            ListaFabricantes = DBUtils.DataTableToCollection(fabricantesModelosDT, "Marcas");
        }

        [RelayCommand] //Cargar el pdf de una marca seleccionada
        public async Task LoadPickerMarcas(string marca)
        {
            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet",
            DBManager.GetFabricantesByMarca(marca), "Reports/FabricantesModelosReport.rdlc");

            switch (marca)
            {
                case "Honda":
                    ImagenSeleccionada = "honda.png";
                    break;
                case "Yamaha":
                    ImagenSeleccionada = "yamaha.png";
                    break;
                case "Harley-Davidson":
                    ImagenSeleccionada = "harley.png";
                    break;
                case "Kawasaki":
                    ImagenSeleccionada = "kawasaki.png";
                    break;
                case "Suzuki":
                    ImagenSeleccionada = "suzuki.png";
                    break;
                case "Ducati":
                    ImagenSeleccionada = "ducati.png";
                    break;
                case "BMW Motorrad":
                    ImagenSeleccionada = "bmw.png";
                    break;
                case "KTM":
                    ImagenSeleccionada = "ktm.png";
                    break;
                case "Triumph":
                    ImagenSeleccionada = "triumph.png";
                    break;
                case "Indian Motorcycle":
                    ImagenSeleccionada = "indian.png";
                    break;
                case "Aprilia":
                    ImagenSeleccionada = "aprilia.png";
                    break;
                case "Moto Guzzi":
                    ImagenSeleccionada = "moto_guzzi.png";
                    break;
                case "Husqvarna":
                    ImagenSeleccionada = "husqvarna.png";
                    break;
            }
        }

        public void CargarComboClientes() //Solo para cargar el picker de clientes
        {
            DataTable clientes = DBManager.GetClientes();
            ListaClientes = DBUtils.DataTableToCollection(clientes, "Nombre");
        }

        [RelayCommand] //Cargar el pdf de un cliente seleccionado
        public async Task LoadPickerClientes(string nombre)
        {
            PDFData = await ReportsUtils.GetReport("ClientesDataSet",
            DBManager.GetClientesByNombre(nombre), "Reports/ClientesReport.rdlc");

        }

        public void CargarComboAccesorios() //Solo para cargar el picker de accesorios
        {
            DataTable accesorios = DBManager.GetNombreAccesorios();
            ListaAccesorios = DBUtils.DataTableToCollection(accesorios, "Nombre");
        }

        [RelayCommand]
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
        [RelayCommand]
        public void BorrarFiltroAccesorios(string accesorio)
        {
            ListaFiltrosAccesorios.Remove(accesorio);
        }


    [RelayCommand]
        public async Task GetAccesoriosAsync() //Esto hace referencia al boton de buscar todos los Accesorios
        {
            PDFData = await ReportsUtils.GetReport("AccesoriosDataSet",
            DBManager.GetAccesorios(), "Reports/AccesoriosReport.rdlc");
        }

        [RelayCommand]
        public async Task GetAccesoriosByPrecio() //Esto hace referencia al boton de buscar todos los Accesorios
        {
            PDFData = await ReportsUtils.GetReport("AccesoriosDataSet",
            DBManager.GetAccesoriosByPrecio(PrecioMenor, PrecioMayor), "Reports/AccesoriosReport.rdlc");
            ResultadoPrecios = $"Precios filtrados: {PrecioMenor}€ - {PrecioMayor}€";
        }

        [RelayCommand]
        public async Task GetFabricantesByAnioGT() //Esto hace referencia al boton de buscar fabricantes mayor que >
        {

            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet",
            DBManager.GetAnioGT(AnioMayor), "Reports/FabricantesModelosReport.rdlc");

        }

        [RelayCommand]
        public async Task GetFabricantesByAnioLT() //Esto hace referencia al boton de buscar fabricantes menor que <
        {

            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet",
            DBManager.GetAnioLT(AnioMenor), "Reports/FabricantesModelosReport.rdlc");

        }

        [RelayCommand]
        public async Task GetFabricantesByAnioRange() //Esto hace referencia al boton de buscar por 2 intervalos
        {
            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet",
                DBManager.GetAnioRange(AnioMenor, AnioMayor),
                "Reports/FabricantesModelosReport.rdlc");
            ResultadoFecha = $"Años filtrados: {AnioMenor} - {AnioMayor}";
        }

        [RelayCommand]
        public async Task GetClientesVentasMotos() //Esto hace referencia al boton de buscar clientes y ventas de las motos
        {

            PDFData = await ReportsUtils.GetReport("ClientesVentasMotosDataSet",
            DBManager.GetVentasClientes(), "Reports/ClientesVentasMotosReport.rdlc");

        }

        [RelayCommand]
        public async Task GetFacturasByFecha() //Esto hace referencia al boton de buscar clientes y ventas de las motos
        {

            PDFData = await ReportsUtils.GetReport("FacturasFechasDataSet",
            DBManager.GetFacturasByFechas(FechaIni, FechaFin), "Reports/FacturasFechasReport.rdlc");

        }

        [RelayCommand]
        public async Task GetMotos() //Esto hace referencia al boton de mostrar motos totales
        {
            PDFData = await ReportsUtils.GetReport("MotosDataSet",
            DBManager.GetMotos(), "Reports/MotosReport.rdlc");
        }



        [RelayCommand]
        public async Task GetMotosDisponibles() //Esto hace referencia al boton de mostrar motos disponibles
        {
                if (SwitchEstado)
                {
                    PDFData = await ReportsUtils.GetReport("MotosDisponiblesDataSet",
                    DBManager.GetMotosDisponibilidad(), "Reports/MotosDisponiblesReport.rdlc");
                }
                else
                {
                    GetMotos();
                }
            }
    }
}
