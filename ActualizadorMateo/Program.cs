using System;
using System.Configuration;
using System.Windows.Forms;

namespace ActualizadorMateo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string nombreApp = ConfigurationManager.AppSettings["nomApp"];
            Aplicacion aplicacion = null;
            App app;

            switch (nombreApp)
            {
                case "MATEO":
                    app = App.Mateo;
                    aplicacion = new Mateo();
                    aplicacion.codigo = Convert.ToInt16(App.Mateo);
                    break;
                case "SCALES":
                    app = App.Scales;
                    aplicacion = new Scales();
                    aplicacion.codigo = 1;
                    break;
                default:
                    break;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmEjecutaApp(aplicacion));
        }
    }
}
