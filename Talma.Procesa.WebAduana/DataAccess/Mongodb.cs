using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;

namespace Talma.Procesa.WebAduana.DataAccess
{
    public static class Mongodb
    {
        public static ManifiestoProvisional getManifiesto(string nuMani)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["CxMongoDB"];
                var cliente = new MongoClient(connectionString);
                var bd = cliente.GetDatabase("local");

                return bd.GetCollection<ManifiestoProvisional>("manifiesto").AsQueryable<ManifiestoProvisional>().ToList().Find(x => x.Manifiesto == nuMani);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public static List<ManifiestoProvisional> getManifiesto()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["CxMongoDB"];
                var cliente = new MongoClient(connectionString);
                var bd = cliente.GetDatabase("local");

                return bd.GetCollection<ManifiestoProvisional>("manifiesto").AsQueryable<ManifiestoProvisional>().ToList();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public static void insertar(List<ManifiestoProvisional> lista)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["CxMongoDB"];
                var cliente = new MongoClient(connectionString);
                var db = cliente.GetDatabase("local");

                var col = db.GetCollection<BsonDocument>("manifiesto");

                foreach (var item in lista)
                {
                    var doc = new BsonDocument
                    {
                        {"Manifiesto" ,item.Manifiesto },
                        { "FechaLlegada" ,  item.FechaLlegada },
                        { "FechaTransmision" , item.FechaTransmision },
                        { "Aerolinea" , item.Aerolinea },
                        { "Vuelo" , item.Vuelo }
                    };

                    col.InsertOne(doc);
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }


    }
}
