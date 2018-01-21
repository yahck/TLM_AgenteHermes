//-----------------------------------------------------------------------
// <copyright file="TalmaConnectionString.cs" company="Grupo Talma.">
//     Copyright (c) Grupo Talma. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ActualizadorMateo.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// Especific the connection string declared in the web.config file
    /// </summary>
    public static class TalmaConnectionString
    {
        /// <summary>
        /// Connection to TLM_TRADU schema
        /// </summary>
        public static string TLM_TRADU = ConfigurationManager.ConnectionStrings["TLM_TRADU"].ConnectionString;
    }
}
