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

        public static DataTable GetFabricantesModelos()
        {
            return fabricantes_modelosAdapter.GetData();
        }
    }
}
