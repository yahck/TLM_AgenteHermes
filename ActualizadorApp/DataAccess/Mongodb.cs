using MongoDB.Driver;
using ActualizadorApp.Entities;
using System.Configuration;

namespace ActualizadorApp.DataAccess
{
    public static class Mongodb
    {
        public static AplicacionDTO getAplicaciones(int codApp)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["CxMongoDB"];
                var cliente = new MongoClient(connectionString);
                var bd = cliente.GetDatabase("local");

                return bd.GetCollection<AplicacionDTO>("aplicacion").AsQueryable<AplicacionDTO>().ToList().Find(x=>x.codigo == codApp);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

    }
}
