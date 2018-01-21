//-----------------------------------------------------------------------
// <copyright file="IAccountRepository.cs" company="Talma Servicios Aeroportuarios">
//     Copyright (c) Talma Servicios Aeroportuarios. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Talma.PDA.DataAccess.Repositories.UMS
{
    using CoreApp.Framework.DataAccessExtensions;


    /// <summary>
    /// IAccountRepository
    /// </summary>
    public interface IAccountRepository<T> : IGenericRepository<T> where T : class
    {
    }
}
