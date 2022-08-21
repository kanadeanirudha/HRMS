using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralTaxMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> InsertGeneralTaxMaster(GeneralTaxMaster item);

        /// <summary>
        /// business action interface of update record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> UpdateGeneralTaxMaster(GeneralTaxMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> DeleteGeneralTaxMaster(GeneralTaxMaster item);

        /// <summary>
        /// business action interface of select all record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxMaster> GetBySearch(GeneralTaxMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxMaster> GetBySearchList(GeneralTaxMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> SelectByID(GeneralTaxMaster item);
    }
}
