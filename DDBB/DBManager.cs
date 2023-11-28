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
        private static fabricantes_modelosTableAdapter anio_range_adapter = new fabricantes_modelosTableAdapter();
        private static clientes_ventas_motosTableAdapter clientes_ventas_motosAdapter = new clientes_ventas_motosTableAdapter();



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

        public static DataTable GetNombreAccesorios()
        {
            return accesorios_adapter.GetNombreAccesorios();

        }

        public static DataTable GetAccesoriosByPrecio(int precioMenor, int precioMayor)
        {
            return accesorios_adapter.GetAccesoriosByPrecio(precioMenor, precioMayor);
        }

        public static DataTable GetAnioGT(int anio)
        {
            return anio_range_adapter.GetAnioGT(anio);
        }

        public static DataTable GetAnioLT(int anio)
        {
            return anio_range_adapter.GetAnioLT(anio);
        }

        public static DataTable GetAnioRange(int anioMenor, int anioMayor)
        {
            return anio_range_adapter.GetAnioRange(anioMenor, anioMayor);
        }

        public static DataTable GetVentasClientes()
        {
            return clientes_ventas_motosAdapter.GetData();
        }
        public static DataTable GetMotos()
        {
            return clientes_ventas_motosAdapter.GetMotos();
        }
        public static DataTable GetMotosDisponibilidad()
        {
            return clientes_ventas_motosAdapter.GetMotosDisponibilidad();
        }

        public static DataTable GetClientesByNombre(String nombre)
        {
            return clientes_ventas_motosAdapter.GetClientesByNombre(nombre);
        }

        public static DataTable GetClientes()
        {
            return clientes_ventas_motosAdapter.GetClientes();
        }

        public static DataTable GetFacturasByFechas(DateTime fecha1, DateTime fecha2)
        {
            return clientes_ventas_motosAdapter.GetDataByFechas(fecha1, fecha2);
        }

    }

}
