using ActualizadorApp.Entities;

namespace ActualizadorApp.Factory
{
    public static class FactoryAplicacion
    {
        public static void ejecutaAplicacion(tipoApp _tipoApp)
        {
            switch (_tipoApp)
            {
                case tipoApp.Mateo:
                    new Mateo().EjecutaInstalacion();
                    break;
                case tipoApp.Scales:
                    new Scales().EjecutaInstalacion();
                    break;
                default:
                    break;
            }
        }
    }
}
