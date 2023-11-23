using MauiMotos.DDBB.MotosDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMotos.DDBB
{
    internal class DBManager
    {
        private static fabricantes_modelosTableAdapter fabricantes_modelosAdapter = new fabricantes_modelosTableAdapter();
        private static fabricantesTableAdapter fabricantes_adapter = new fabricantesTableAdapter();
        public static DataTable GetFabricantesModelos()
        {
            return fabricantes_modelosAdapter.GetData();
        }
        public static DataTable GetNombreFabricantes()
        {
            return fabricantes_adapter.GetNombreFabricantes();
        }
    }
}
