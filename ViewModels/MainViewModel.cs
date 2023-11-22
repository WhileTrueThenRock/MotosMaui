using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMotos.DDBB;
using MauiMotos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMotos.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {

        }


        [ObservableProperty]
        private string pDFData;
        //Te obliga a ser privada y que empieze en minúscula, Equivalente a public string PDFData {get,set}

        [RelayCommand]
        public async Task getFabricantesModelosAsync()
        {
            PDFData = await ReportsUtils.GetReport("FabricantesModelosDataSet", DBManager.GetFabricantesModelos(), "Reports/FabricantesModelosReport.rdlc");
        }
    }
}
