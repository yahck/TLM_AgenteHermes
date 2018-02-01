namespace Talma.Conexion.Core
{
    public class DataBase<T> : AbstractBaseOracle<T> where T : class
    {
        public DataBase()
            : base("Importacion")
        {
        }
    }
}
