//-----------------------------------------------------------------------
// <copyright file="ICommonRepository.cs" company="Talma Servicios Aeroportuarios">
//     Copyright (c) Talma Servicios Aeroportuarios. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ActualizadorMateo.Repositories.General
{
    using Talma.CoreApp.Framework.DataAccessExtensions;

    /// <summary>
    /// IGeneralRepository
    /// </summary>
    public interface ICommonRepository<T> : IGenericRepository<T> where T : class
    {
    }
}
