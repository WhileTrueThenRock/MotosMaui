using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMotos.Utils
{
    internal class DBUtils
    {
        public static ObservableCollection<string> DataTableToCollection(DataTable dataTable, String nombreColumna)
        {
            ObservableCollection<string> lista = new ObservableCollection<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                var datos = row[nombreColumna];
                lista.Add(datos.ToString()); //cambio del cast al ToString
            }
            return lista;

        }
    }
}
