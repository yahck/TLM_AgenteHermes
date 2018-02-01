using System;

namespace Talma.Entidades
{
    public class EnParametro
    {
        public int ID_PARA { get; set; }
        public int ID_PARA_PADRE { get; set; }
        public string DE_PARA { get; set; }
        public string VA_PARA { get; set; }
        public int ID_UNIDAD { get; set; }
        public string ES_MOSTRAR { get; set; }
        public string ES_AGREGAR { get; set; }
        public string ES_EDITABLE { get; set; }
        public string ES_ELIMINAR { get; set; }
        public int VA_ENTIDAD { get; set; }
        public string CO_USUA_MODI { get; set; }
        public DateTime? FE_USUA_MODI { get; set; }
        public string CO_USUA_REG { get; set; }
        public DateTime? FE_USUA_REG { get; set; }
        public string CO_ELIMINADO { get; set; }
    }
}
