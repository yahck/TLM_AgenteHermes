using System.Diagnostics;
using ActualizadorApp.Entities;
using ActualizadorApp.DataAccess;
using System.Net;
using System;
using System.IO;

namespace ActualizadorApp.Factory
{
    public class Mateo : Aplicacion
    {
        AplicacionDTO aplicacion;

        public override void EjecutaInstalacion()
        {
            obtenerDatosAppBD((int)tipoApp.Mateo);

            try
            {
                if (validaPCdesplegar() && aplicacion.actualiza == "1")
                {
                    killAplicacion();

                    DirectoryCopy(aplicacion.ruta_instalador, aplicacion.directorio, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            RunAplicacion();
        }

        private void obtenerDatosAppBD(int codApp)
        {
            aplicacion = Mongodb.getAplicaciones(codApp);
        }

        private string obtenerNombrePC()
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());
            return host.HostName.Split('.')[0];
        }

        private bool validaPCdesplegar()
        {
            var retorna = false;
            var listaPc = aplicacion.listaPC.Split('|');
            var pcDesplegar = obtenerNombrePC();

            foreach (var item in listaPc)
            {
                if (item == pcDesplegar)
                {
                    retorna = true;
                    break;
                }
            }

            return retorna;
        }

        private void RunAplicacion()
        {
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(Path.Combine(aplicacion.directorio, aplicacion.ejecutable));
            //psi.Arguments = "/c \"first.exe -a -b -c | second.exe\"";
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit(1000);
        }

        private void killAplicacion()
        {
            var resultado = Process.GetProcessesByName(aplicacion.ejecutable.Split('.')[0]);

            foreach (var item in resultado)
            {
                item.Kill();
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }

        }

    }
}




//public List<AplicacionDTO> getDataApplication(string codApp)
//{
//    return BusinessLogic.Instance.GetDataApplication(codApp).ToList();
//}



//private void obtenerDatosAplicacion()
//{
//    try
//    {
//        List<AplicacionDTO> lista = getDataApplication(aplicacion.codigo.ToString());

//        aplicacion.directorio = lista[0].directorio; // "C:\\Talma\\Scales.Windows\\";
//        aplicacion.ejecutable = lista[0].ejecutable; // "Scales.Windows.exe";
//        aplicacion.version = lista[0].version; // "1.0";
//        aplicacion.pc = new PC() { nombre = obtenerNombrePC(), ip = "" };

//        List<PC> pcs = new List<PC>();
//        foreach (var item in lista[0].listaPC.Split('|'))
//        {
//            pcs.Add(new PC() { nombre = item, ip = "" });
//        }

//        aplicacion.listaPCdesplegar = pcs;
//    }
//    catch (Exception)
//    {

//    }

//}