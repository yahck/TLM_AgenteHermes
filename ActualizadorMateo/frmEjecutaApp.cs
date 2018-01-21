using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using ActualizadorMateo.Dto;

namespace ActualizadorMateo
{
    public partial class frmEjecutaApp : Form
    {
        Aplicacion aplicacion;

        public frmEjecutaApp(Aplicacion _aplicacion)
        {
            InitializeComponent();
            
            aplicacion = _aplicacion;
            obtenerDatosAplicacion();
            ejecutarAplicacion();
        }

        private void obtenerDatosAplicacion()
        {
            try
            {
                List<AplicacionDTO> lista = getDataApplication(aplicacion.codigo.ToString());

                aplicacion.directorio = lista[0].directorio; // "C:\\Talma\\Scales.Windows\\";
                aplicacion.ejecutable = lista[0].ejecutable; // "Scales.Windows.exe";
                aplicacion.version = lista[0].version; // "1.0";
                aplicacion.pc = new PC() { nombre = obtenerNombrePC(), ip = "" };

                List<PC> pcs = new List<PC>();
                foreach (var item in lista[0].listaPC.Split('|'))
                {
                    pcs.Add(new PC() { nombre = item, ip = "" });
                }
                
                aplicacion.listaPCdesplegar = pcs;
            }
            catch (Exception)
            {

            }
            
        }

        private void ejecutarAplicacion()
        {
            var _aplicacion = aplicacion.directorio + aplicacion.ejecutable;

            try
            {
                if (validaPCdesplegar())
                {
                    if (validaVersion(_aplicacion))
                    {
                        killAplicacion();
                        desplegarArchivosApp();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(_aplicacion);
            //psi.Arguments = "/c \"first.exe -a -b -c | second.exe\"";
            p.StartInfo = psi;
            p.Start();
        }

        private bool validaPCdesplegar()
        {
            return aplicacion.listaPCdesplegar.Exists(x => x.nombre.ToUpper() == aplicacion.pc.nombre.ToUpper());
        }

        private bool validaVersion(string pathToExe)
        {
            bool versionSuperior = false;

            var versionInfo = FileVersionInfo.GetVersionInfo(pathToExe);
            string version = versionInfo.ProductVersion;

            string[] arrVersionDll = version.Split('.');

            int i = 0;
            foreach (var item in arrVersionDll)
            {
                if (Convert.ToInt16(aplicacion.version.Split('.')[i]) > Convert.ToInt16(item[i]))
                {
                    versionSuperior = true;
                    break;
                }
                else if(Convert.ToInt16(aplicacion.version.Split('.')[i]) < Convert.ToInt16(item[i]))
                {
                    versionSuperior = false;
                    break;
                }

                i++;
            }

            return versionSuperior;
        }

        private void killAplicacion()
        {
            var resultado = Process.GetProcessesByName(aplicacion.ejecutable);
            foreach (var item in resultado)
            {
                item.Kill();
            }
        }

        private void desplegarArchivosApp()
        {
            var fuenteOrigen = aplicacion.ruta_instalador + aplicacion.directorio_instalador ;
            var fuenteDestino = aplicacion.directorio;
            var fuenteBackup = aplicacion.ruta_backup + aplicacion.directorio_backup;

            File.Replace(fuenteOrigen, fuenteDestino, fuenteBackup, false);
        }

        private string obtenerNombrePC()
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());
            return host.HostName.Split('.')[0];

            //TM - CP - ATC - FAC17
            //TM - CP - ATC - FAC03
            //TM - CP - ATC - FAC01
            //TM - CP - ATC - FAC11
            //TM - CP - ATC - FAC05
            //TM - CP - ATC - FAC09
            //TM - CP - ATC - FAC04
            //TM - CP - ATC - FAC14
            //TM - CP - ATC - FAC13
            //TM - CP - ATC - FAC02
            //TM - CP - ATC - FAC16
            //TM - CP - ATC - FAC15
            //TM - CP - ATC - FAC12
            //TM - CP - ATC - FAC18
            //TM - CP - ATC - FAC10
            //TM - CL - SIS - YEAGR.PE.TALMA.CORP

        }

        public List<AplicacionDTO> getDataApplication(string codApp)
        {
            return BusinessLogic.Instance.GetDataApplication(codApp).ToList();
        }

        private void frmEjecutaApp_Load(object sender, EventArgs e)
        {
            
        }
    }
}
