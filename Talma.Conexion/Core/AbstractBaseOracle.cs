using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Dapper;
using Oracle.DataAccess.Client;

namespace Talma.Conexion.Core
{
    public abstract class AbstractBaseOracle<T> where T: class
    {
        public string _nombreConexion;
        //private readonly string _nombreConexion;

        protected AbstractBaseOracle(string nombreConexion)
        {
            _nombreConexion = nombreConexion;
        }

        protected IDbConnection OpenConnection()
        {
            var connection = new OracleConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["OracleServices"].ConnectionString;
            return connection;
        }

        protected object Insertar(string procedimiento, OracleDynamicParameters parametros)
        {
            using (IDbConnection conn = OpenConnection())
            {
                conn.Open();
                conn.Execute(procedimiento, parametros, commandType: CommandType.StoredProcedure);
                var nuevoid = parametros.Get(parametros.ParameterNames.Last());
                return nuevoid;
            }
        }

        protected object EjecutarOutput(string procedimiento, OracleDynamicParameters parametros)
        {
            using (IDbConnection conn = OpenConnection())
            {
                conn.Open();
                conn.Execute(procedimiento, parametros, commandType: CommandType.StoredProcedure);
                var nuevoid = parametros.Get(parametros.ParameterNames.Last());
                return nuevoid;
            }
        }

        protected void Ejecutar(string procedimiento, OracleDynamicParameters parametros)
        {
            using (IDbConnection conn = OpenConnection())
            {
                conn.Open();
                conn.Execute(procedimiento, parametros, commandType: CommandType.StoredProcedure);
            }
        }

        protected T Obtener(string procedimiento, OracleDynamicParameters parametros)
        {
            using (IDbConnection conn = OpenConnection())
            {
                conn.Open();
                return conn.Query<T>(procedimiento, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        protected TR Obtener<TR>(string procedimiento, OracleDynamicParameters parametros)
        {
            using (IDbConnection conn = OpenConnection())
            {
                conn.Open();
                return conn.Query<TR>(procedimiento, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        protected TR Listar<TR>(string procedimiento, OracleDynamicParameters parametros) where TR : IEnumerable<T>
        {
            using (IDbConnection conn = OpenConnection())
            {
                conn.Open();
                return (TR)conn.Query<T>(procedimiento, parametros, commandType: CommandType.StoredProcedure);
            }
        }

        protected TR Listar<TR, R>(string procedimiento, OracleDynamicParameters parametros) where TR : IEnumerable<R>
        {
            using (IDbConnection conn = OpenConnection())
            {
                conn.Open();
                return (TR)conn.Query<R>(procedimiento, parametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
