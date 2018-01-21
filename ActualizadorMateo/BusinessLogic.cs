using ActualizadorMateo.Dto;
using ActualizadorMateo.Helpers;
using ActualizadorMateo.Implements.General;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualizadorMateo
{
    public class BusinessLogic
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportMoveBusinessLogic"/> class.
        /// </summary>
        protected static readonly Lazy<BusinessLogic> InstanceBusinessLogic = new Lazy<BusinessLogic>(() => new BusinessLogic());

        /// <summary>
        /// Gets the instance created
        /// <see cref="ExportMoveBusinessLogic"/>
        /// </summary>
        public static BusinessLogic Instance
        {
            get { return InstanceBusinessLogic.Value; }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// ExecuteProcessMove
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>CommonResponseDataBase</returns>
        public IEnumerable<AplicacionDTO> GetDataApplication(string codApp)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc["ICO_APP"] = codApp;

            return new CommonDataAccess<AplicacionDTO>().ExecuteStoredProcedure(nvc, PKG_APPLICATION.USP_SEL_APPLICATION, "OCURSOR");
            //IEnumerable<AplicacionDTO> result = CommonDataAccess<AplicacionDTO>().ExecuteStoredProcedure(nvc, PKG_APPLICATION.USP_SEL_APPLICATION, "OCURSOR");

            //return result.FirstOrDefault();
        }
        
        #endregion
    }
}
