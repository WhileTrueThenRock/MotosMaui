using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMotos.Utils
{
    internal class ReportsUtils
    {
        private static ReportViewer myReport = new ReportViewer();
        private static ReportDataSource rds = new ReportDataSource();

        public static async Task<string> GetReport(string rdsname,
                                                   DataTable dt,
                                                   string reportpath)
        {
            try
            {
                // Configurar origen de datos del informe
                rds.Name = rdsname;
                rds.Value = dt;

                // Agregar el origen de datos al ReportViewer
                myReport.LocalReport.DataSources.Add(rds);

                // Abrir el archivo del infome
                var stream = await FileSystem.OpenAppPackageFileAsync(reportpath);

                // Cargar la definición del informe
                myReport.LocalReport.LoadReportDefinition(stream);

                // Renderizar el informe en formato PDF
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF");

                // Escribir los bytes del PDF en un archivo temporar
                string tempPath = Path.GetTempFileName();
                File.WriteAllBytes(tempPath, PDFBytes);

                // Devolver la ruta del archivo que contiene el PDF
                return tempPath;

            }
            catch (Exception ex)
            {
                ex.ToString();
                return null; // Devolver null para indicar que ocurrio un error
            }

        }
    }

}
