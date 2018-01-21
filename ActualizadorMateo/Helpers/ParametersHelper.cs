//----------------------------------------------------------------------------------
// <copyright file="ParametersHelper.cs" company="Talma Servicios Aeroportuarios">
//     Copyright (c) Talma Servicios Aeroportuarios. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------
namespace ActualizadorMateo.Helpers
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// ParametersHelper
    /// </summary>
    public static class ParametersHelper
    {
        /// <summary>
        /// Retorna un arreglo con los parametros y nombre presonalizado del SP para el SqlQuery de E.F.
        /// Los key del nvc tienen que tener el mismo nombre que los parametros de entrada del SP
        /// </summary>
        /// <param name="nvc">NameValueCollection nvc</param>
        /// <param name="storedProcedureName">string storedProcedureName</param>
        /// <param name="cursorName">string cursorsName, si se tiene mas de un cursor se ingresa el nombre separado por comas</param>
        /// <param name="storedProcedureCustom">out string storedProcedureCustom</param>
        /// <returns>Oracle.ManagedDataAccess.Client.OracleParameter[] data parameters</returns>
        public static Oracle.ManagedDataAccess.Client.OracleParameter[] GetCustomParameters(NameValueCollection nvc, string storedProcedureName, string cursorsName, out string storedProcedureCustom)
        {

            List<Oracle.ManagedDataAccess.Client.OracleParameter> parameters = new List<Oracle.ManagedDataAccess.Client.OracleParameter>();
            var items = nvc.AllKeys.SelectMany(nvc.GetValues, (k, v) => new { key = k, value = v });
            storedProcedureCustom = "BEGIN " + storedProcedureName + "(";

            foreach (var item in items)
            {
                parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter(item.key, item.value));
                storedProcedureCustom += ":" + item.key + ",";
            }

            int index = 0;
            if (cursorsName.IndexOf(',') > 0)
            {
                parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter(cursorsName[index].ToString().Trim(), Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor, ParameterDirection.Output));
                storedProcedureCustom += ":" + cursorsName + ","; ;
                index++;
            }
            else
            {
                storedProcedureCustom += ":" + cursorsName;
                parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter(cursorsName.Trim(), Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor, ParameterDirection.Output));
            }

            storedProcedureCustom = storedProcedureCustom.Substring(0, storedProcedureCustom.Length - 1) + "); END;";

            return parameters.ToArray();
        }
    }
}
