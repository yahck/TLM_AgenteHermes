using System.Collections.Generic;

namespace ActualizadorMateo
{
    public class Aplicacion
    {
        public string nombre { get; set; }
        public int codigo { get; set; }
        public string directorio { get; set; }
        public string ejecutable { get; set; }
        public string version { get; set; }
        public PC pc { get; set; }
        public List<PC> listaPCdesplegar { get; set;}
        public string directorio_instalador { get; set; }
        public string ruta_instalador { get; set; }
        public string ruta_backup { get; set; }
        public string directorio_backup { get; set; }
    }

    public class PC
    {
        public string nombre { get; set; }
        public string ip { get; set; }
    }

    enum App
    {
        Mateo, Scales
    };

}
