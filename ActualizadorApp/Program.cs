using System;
using System.Configuration;
using ActualizadorApp.Factory;
using ActualizadorApp.Entities;
using ActualizadorApp.DataAccess;
using System.Collections.Generic;

namespace ActualizadorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var codigoApp = Convert.ToInt32(ConfigurationManager.AppSettings["codApp"]);
                        
            FactoryAplicacion.ejecutaAplicacion((tipoApp)(codigoApp));
            
        }
    }
}
