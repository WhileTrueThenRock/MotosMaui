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
        private static accesoriosTableAdapter accesorios_adapter = new accesoriosTableAdapter();
        private static fabricantes_modelosTableAdapter anioGT_adapter = new fabricantes_modelosTableAdapter();
        private static fabricantes_modelosTableAdapter anioLT_adapter = new fabricantes_modelosTableAdapter();
        private static clientes_ventas_motosTableAdapter clientes_ventas_motosAdapter = new clientes_ventas_motosTableAdapter();
        private static clientes_ventas_motosTableAdapter motos_disponibles_Adapter = new clientes_ventas_motosTableAdapter();


        public static DataTable GetFabricantesModelos()
        {
            return fabricantes_modelosAdapter.GetData();
        }
        public static DataTable GetNombreFabricantes()
        {
            return fabricantes_adapter.GetNombreFabricantes();
        }
        public static DataTable GetFabricantesByMarca(String marca)
        {
            return fabricantes_modelosAdapter.GetFabricantesByMarca(marca);
        }
        public static DataTable GetAccesorios()
        {
            return accesorios_adapter.GetData();
        }

        public static DataTable GetAnioGT(int anio)
        {
            return anioGT_adapter.GetAnioGT(anio);
        }

        public static DataTable GetAnioLT(int anio)
        {
            return anioLT_adapter.GetAnioLT(anio);
        }

        public static DataTable GetVentasClientes()
        {
            return clientes_ventas_motosAdapter.GetData();
        }
        public static DataTable GetDisponibilidad()
        {
            return motos_disponibles_Adapter.GetDisponibilidad();
        }

    }
    
}
