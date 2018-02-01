using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using System.Xml;
using EmulaEnvioGuiasAcma.srvGuiasAcma;

namespace EmulaEnvioGuiasAcma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.DefaultExt = ".zip";
                dialog.Filter = "ZIP Folder (.zip)|*.zip";

                if (dialog.ShowDialog() == DialogResult.OK) 
                {
                    var path = dialog.FileName; 

                    byte[] buffer = File.ReadAllBytes(path);

                    srvGuiasAcma.ManifiestoClient srv = new srvGuiasAcma.ManifiestoClient();

                    int res = srv.EnviarArchivoACMA("TALMA", "TALMA", "1", buffer);

                    MessageBox.Show(res.ToString());

                    //using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
                    //{
                        
                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public string strEmpresa { get; set; }
        public string strTerminal { get; set; }
        public string strUsuario { get; set; }

        public int EnviarArchivoACMA(string usuario, string clave, string tipoTransaccion, byte[] buffer)
        {
            string item = ConfigurationManager.AppSettings["PathArchivosACMA"];
            string str = ConfigurationManager.AppSettings["PathLogAudiArchACMA"];
            int num = 0;
            this.strEmpresa = "02";
            this.strTerminal = "3507";
            this.strUsuario = usuario;

            try
            {
                if ((usuario.ToUpper().Trim() != "TALMA" ? true : !(clave.ToUpper().Trim() == "TALMA")))
                {
                    num = 0;
                }
                else
                {
                    File.WriteAllBytes(string.Concat(item, "ArchACMA.zip"), buffer);
                    ZipFile zipFiles = new ZipFile(string.Concat(item, "ArchACMA.zip"));
                    try
                    {
                        zipFiles.ExtractAll(string.Concat(item, "ArchivosACMA"), ExtractExistingFileAction.OverwriteSilently);
                        this.MoverArchivo(string.Concat(item, "ArchivosACMA"), str);
                    }
                    finally
                    {
                        if (zipFiles != null)
                        {
                            ((IDisposable)zipFiles).Dispose();
                        }
                    }
                    num = this.LeerXml(string.Concat(item, "ArchivosACMA\\Guias.xml"));
                }
            }
            catch (Exception exception)
            {
                //CargaGuiasAccessBL.GrabaLogSucesosWCF(exception, "EnviarArchivoACMA", "Error");
                num = 0;
            }
            return num;
        }

        private int LeerXml(string pathXml)
        {
            int num;
            int num1 = 0;
            List<DatosACMA> datosACMAs = new List<DatosACMA>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(pathXml);
            XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("DocumentElement");

            foreach (XmlElement xmlElement in ((XmlElement)elementsByTagName[0]).GetElementsByTagName("Guia"))
            {
                num1++;
                DatosACMA datosACMA = new DatosACMA()
                {
                    CO_EMPR = this.strEmpresa,
                    CO_TERM = this.strTerminal,
                    CO_USUA_MODI = this.strUsuario
                };

                datosACMA.guCodAerolineaLet = xmlElement.GetElementsByTagName("guCodAerolineaLet")[0].InnerText;
                datosACMA.guNumGuia = xmlElement.GetElementsByTagName("guNumGuia")[0].InnerText.PadLeft(12, '0');
                datosACMA.guNumVuelo = xmlElement.GetElementsByTagName("guNumVuelo")[0].InnerText;
                datosACMA.guFechaVuelo = xmlElement.GetElementsByTagName("guFechaVuelo")[0].InnerText;
                datosACMA.guCodTerminal = xmlElement.GetElementsByTagName("guCodTerminal")[0].InnerText;
                datosACMA.guEmbarcador = xmlElement.GetElementsByTagName("guEmbarcador")[0].InnerText;
                datosACMA.guConsignatario = xmlElement.GetElementsByTagName("guConsignatario")[0].InnerText;
                datosACMA.guCodPuertoCarga = xmlElement.GetElementsByTagName("guCodPuertoCarga")[0].InnerText;
                datosACMA.guCodPuertoDFinal = xmlElement.GetElementsByTagName("guCodPuertoDFinal")[0].InnerText;
                datosACMA.guDescMercaderia = xmlElement.GetElementsByTagName("guDescMercaderia")[0].InnerText;
                datosACMA.guCantBultos = xmlElement.GetElementsByTagName("guCantBultos")[0].InnerText;
                datosACMA.guPesoBruto = xmlElement.GetElementsByTagName("guPesoBruto")[0].InnerText;
                datosACMA.guFechaDescarga =xmlElement.GetElementsByTagName("guFechaDescarga")[0].InnerText;

                try
                {
                    datosACMA.guTipoSHC = xmlElement.GetElementsByTagName("guTipoSHC")[0].InnerText;
                }
                catch (Exception ex)
                {
                    datosACMA.guTipoSHC = "";
                }

                try
                {
                    datosACMA.guObservacionSHC = xmlElement.GetElementsByTagName("guObservacionSHC")[0].InnerText;
                }
                catch (Exception ex)
                {
                    datosACMA.guObservacionSHC = "";
                }

                datosACMAs.Add(datosACMA);
            }

            //num = (CargaGuiasAccessBL.GrabarGuiasRegistrosAcma(datosACMAs) != 0 ? 1 : 0);
            num = 1;
            return num;
        }

        private void MoverArchivo(string sourcePath, string targetPath)
        {
            string str = string.Concat(sourcePath, "\\Guias.xml");
            object[] year = new object[] { targetPath, "\\Guias_", null, null, null, null, null, null, null, null };
            DateTime now = DateTime.Now;
            year[2] = now.Year;
            int month = DateTime.Now.Month;
            year[3] = month.ToString().PadLeft(2, '0');
            month = DateTime.Now.Day;
            year[4] = month.ToString().PadLeft(2, '0');
            year[5] = "_";
            now = DateTime.Now;
            year[6] = now.Hour;
            now = DateTime.Now;
            year[7] = now.Minute;
            now = DateTime.Now;
            year[8] = now.Second;
            year[9] = ".xml";
            string str1 = string.Concat(year);
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            File.Copy(str, str1);
        }



    }
}
