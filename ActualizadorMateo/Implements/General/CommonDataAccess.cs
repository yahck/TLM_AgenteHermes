//----------------------------------------------------------------------------------
// <copyright file="CommonDataAccess.cs" company="Talma Servicios Aeroportuarios">
//     Copyright (c) Talma Servicios Aeroportuarios. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------
namespace ActualizadorMateo.Implements.General
{
    using Repositories.General;
    using Talma.CoreApp.Framework.DataAccessExtensions;

    /// <summary>
    /// GeneralDataAccess
    /// </summary>
    public class CommonDataAccess<T> : GenericRepository<T, EntityDBContext>, ICommonRepository<T> where T : class
    {
    }
}
