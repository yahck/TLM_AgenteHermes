using System.Collections.Generic;

namespace ActualizadorApp.Entities
{
    public class EAplicacion
    {
        public string nombre { get; set; }
        public tipoApp codigo { get; set; }
        public string directorio { get; set; }
        public string ejecutable { get; set; }
        public string version { get; set; }
        public EPc pc { get; set; }
        public List<EPc> listaPCdesplegar { get; set; }
        public string directorio_instalador { get; set; }
        public string ruta_instalador { get; set; }
        public string ruta_backup { get; set; }
        public string directorio_backup { get; set; }
    }

    public enum tipoApp
    {
        Mateo,
        Scales
    };

}
