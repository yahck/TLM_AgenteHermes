using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualizadorMateo.Dto
{
    public class AplicacionDTO
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string directorio { get; set; }
        public string ejecutable { get; set; }
        public string version { get; set; }
        public string listaPC { get; set; }
        public string directorio_instalador { get; set; }
        public string ruta_instalador { get; set; }
        public string ruta_backup { get; set; }
        public string directorio_backup { get; set; }
    }
}
