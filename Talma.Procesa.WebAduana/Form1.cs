using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Talma.Procesa.WebAduana.DataAccess;

namespace Talma.Procesa.WebAduana
{
    public partial class Form1 : Form
    {
        const string InfoManifiestoProvisional = "InfoManifiestoProvisional";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ManifiestoProvisional> listaMani = new List<ManifiestoProvisional>();
            
            try
            {
                int i = 0;

                HtmlElementCollection elements = webBrowserAduana.Document.GetElementsByTagName("TR");
                foreach (HtmlElement element in elements)
                {
                    if (i > 4)
                    {
                        ManifiestoProvisional mani = new ManifiestoProvisional();

                        int j = 0;

                        HtmlElementCollection elementsChild = element.GetElementsByTagName("TD");
                        foreach (HtmlElement elemenTD in elementsChild)
                        {
                            switch (j)
                            {
                                case 0:
                                    mani.Manifiesto = elemenTD.InnerText;
                                    break;
                                case 1:
                                    mani.FechaLlegada = elemenTD.InnerText;
                                    break;
                                case 2:
                                    mani.FechaTransmision = elemenTD.InnerText;
                                    break;
                                case 3:
                                    mani.Aerolinea = elemenTD.InnerText;
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    mani.Vuelo = elemenTD.InnerText;
                                    break;
                                default:
                                    break;
                            }

                            j++;
                        }

                        listaMani.Add(mani);
                    }

                    i++;
                   
                }

                Mongodb.insertar(listaMani);

                MessageBox.Show("Se proceso correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        //F:\RepositoriosGit\AgenteHermesScales\Talma.Procesa.WebAduana\bin\Debug\InfoManifiestoProvisional
            var pathPage = Directory.GetCurrentDirectory() + "\\" + InfoManifiestoProvisional + "\\pagManifiestoProv.html";
            webBrowserAduana.Navigate(pathPage);
            //webBrowserAduana.Refresh();

        }
    }

    

}
