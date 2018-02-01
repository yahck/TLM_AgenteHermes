using System.Collections.Generic;
using System.Data;
using System.Linq;
using Talma.Conexion.Core;
using Talma.Conexion.Interfaces;
using Talma.Entidades;
using Talma.Entidades.Dto;

namespace Talma.Conexion.Implementacion
{
    public class CoGenerales : DataBase<EnParametro>, ICoGenerales
    {
        public void Insertar(DatosACMA datosAcma)
        {
            //int GrabarGuiasRegistrosAcma(DatosACMA datosACMA);
            //return 1;
            //var p = new OracleDynamicParameters();
            //p.Add("IN_ID_ITIN_VUEL", vueloNacionalDetalle.ID_ITIN_VUEL, OracleDbType.Int64, ParameterDirection.Input);
            //p.Add("IN_STATUS", vueloNacionalDetalle.STATUS, OracleDbType.Int64, ParameterDirection.Input);
            //p.Add("IN_KILOS_RECBIDOS", vueloNacionalDetalle.KILOS_RECBIDOS, OracleDbType.Decimal, ParameterDirection.Input);
            //p.Add("IN_CANT_ELEMENTOS", vueloNacionalDetalle.CANT_ELEMENTOS, OracleDbType.Int64, ParameterDirection.Input);
            //p.Add("IN_TERMINO_TARJA", vueloNacionalDetalle.TERMINO_TARJA, OracleDbType.Varchar2, ParameterDirection.Input);
            //p.Add("IN_RESPONSABLE_TARJA", vueloNacionalDetalle.RESPONSABLE_TARJA, OracleDbType.Varchar2, ParameterDirection.Input);
            //p.Add("IN_MANIFESTADOS", vueloNacionalDetalle.MANIFESTADOS, OracleDbType.Varchar2, ParameterDirection.Input);
            //p.Add("IN_HORA_ENVIO_HOJA_PESO", vueloNacionalDetalle.HORA_ENVIO_HOJA_PESO, OracleDbType.Varchar2, ParameterDirection.Input);
            //p.Add("IN_DE_USUARIO_REG", vueloNacionalDetalle.DE_USUARIO_OPE, OracleDbType.Varchar2, ParameterDirection.Input);
            //base.Ejecutar(Procedimiento.USP_INS_ITINERARIO_VUELO_DET, p);
        }
        //public List<EnUsuario> ObtenerUsuario(int idRol, int idEmpresa)
        //{
        //    var p = new OracleDynamicParameters();
        //    p.Add("IN_CO_ROL", idRol, OracleDbType.Varchar2, ParameterDirection.Input);
        //    p.Add("IN_ID_EMPRESA", idEmpresa, OracleDbType.Varchar2, ParameterDirection.Input);
        //    p.Add("VCURSOR", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
        //    return base.Listar<List<EnUsuario>, EnUsuario>(Procedimiento.USP_LIS_USUARIOS, p).ToList();
        //}

    }
}

