using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            List<ManiProvi> listaMani = new List<ManiProvi>();

            try
            {
                //HtmlDocument document = this.webBrowserAduana.Document;
                //oHtml = document.Body.InnerHtml;

                int i = 0;

                HtmlElementCollection elements = webBrowserAduana.Document.GetElementsByTagName("TR");
                foreach (HtmlElement element in elements)
                {
                    if (i > 4)
                    {
                        ManiProvi mani = new ManiProvi();

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
             
                //new SCALES_WCF.SCALES_WCFClient().UpdateValidaDua(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pathPage = Directory.GetCurrentDirectory() + "\\" + InfoManifiestoProvisional + "\\pagManifiestoProv.html";
            webBrowserAduana.Navigate(pathPage);
            //webBrowserAduana.Refresh();

        }
    }

    public class ManiProvi
    {
        public string Manifiesto { get; set; }
        public string FechaLlegada { get; set; }
        public string FechaTransmision { get; set; }
        public string Aerolinea { get; set; }
        public string Vuelo { get; set; }
    }

}
