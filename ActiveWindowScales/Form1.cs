using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.IO;
using System.Linq;
using System.Drawing;

namespace ActiveWindowScales
{
    public partial class Form1 : Form
    {
        static bool StatusService = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniciarServicio();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            IniciarServicio();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            DetenerServicio();
        }

        private void IniciarServicio()
        {
            if (!StatusService)
            {
                string fileNode = ConfigurationManager.AppSettings["FileNode"];
                string fileJS = ConfigurationManager.AppSettings["FileJS"];

                Process p = new Process();
                
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.FileName = fileNode + "node.exe"; //Path to node installed folder****
                string argument = fileJS + "server.js";
                p.StartInfo.Arguments = @argument;

                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                p.Start();
                lblMensaje.Text = "Servicio Iniciado...";
                lblMensaje.ForeColor = System.Drawing.Color.Blue;
                iconizarApp.Icon = new Icon("favicon.ico");
                StatusService = true;
            }
            
            
        }

        private void DetenerServicio()
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("node"))
                {
                    proc.Kill();
                }

                StatusService = false;
                lblMensaje.Text = "Servicio Detenido...";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                iconizarApp.Icon = new Icon("favicon_stop.ico");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnDetener_Click(null, null);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                iconizarApp.Icon = this.Icon;
                iconizarApp.ContextMenuStrip = this.mnuContextual;
                iconizarApp.Text = Application.ProductName;
                iconizarApp.Visible = true;
                this.Visible = false;
            }
        }

        private void mnuCerrarAplicacion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuMostrarAplicacion_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            iconizarApp.Visible = false;
        }

        private void mnuInicarServicio_Click(object sender, EventArgs e)
        {
            IniciarServicio();
        }

        private void mnuDetenerServicio_Click(object sender, EventArgs e)
        {
            DetenerServicio();
        }

        public string OptenerIP()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;

        }

        private void ConfigurarHost()
        {
            string ip = OptenerIP();
            string dirJS = ConfigurationManager.AppSettings["FileJS"];
            string fileJS = dirJS + "server.js";

            try
            {
                var host = "var host = ";
                var newhost = "var host = \"" + ip + "\",";

                var lines = File.ReadAllLines(fileJS);

                var replaced = lines.Select(x =>
                {
                    if (x.StartsWith(host))
                        return newhost;
                    return x;
                });

                File.WriteAllLines(fileJS, replaced);

                MessageBox.Show("Se generó el script Server.js para la Ip: " + ip);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuGenerarScriptHost_Click(object sender, EventArgs e)
        {
            ConfigurarHost();
        }
    }
}
