//----------------------------------------------------------------------------------
// <copyright file="AccountDataAccess.cs" company="Talma Servicios Aeroportuarios">
//     Copyright (c) Talma Servicios Aeroportuarios. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------
namespace Talma.PDA.DataAccess.Implements.UMS
{
    using CoreApp.Framework.DataAccessExtensions;
    using Repositories.UMS;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// AccountDataAccess
    /// </summary>
    public class AccountDataAccess<T> : GenericRepository<T, EntityDBContext>, IAccountRepository<T> where T:class
    {
       
    }
}
