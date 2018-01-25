using MongoDB.Bson;

namespace ActualizadorApp.Entities
{
    public class AplicacionDTO
    {
        public ObjectId Id { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string version { get; set; }
        public string directorio { get; set; }
        public string ejecutable { get; set; }
        public string listaPC { get; set; }
        public string ruta_instalador { get; set; }
        public string actualiza { get; set; }
        static string[] val = null;

    }
}
