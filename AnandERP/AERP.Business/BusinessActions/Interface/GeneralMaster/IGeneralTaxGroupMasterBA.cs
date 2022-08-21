using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralTaxGroupMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxGroupMaster> InsertGeneralTaxGroupMaster(GeneralTaxGroupMaster item);

        /// <summary>
        /// business action interface of update record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxGroupMaster> UpdateGeneralTaxGroupMaster(GeneralTaxGroupMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxGroupMaster> DeleteGeneralTaxGroupMaster(GeneralTaxGroupMaster item);

        /// <summary>
        /// business action interface of select all record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetBySearch(GeneralTaxGroupMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetGeneralTaxGroupMasterList(GeneralTaxGroupMasterSearchRequest searchRequest);



        IBaseEntityResponse<GeneralTaxGroupMaster> SelectByID(GeneralTaxGroupMaster item);

        IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetTaxSummaryForDisplay(GeneralTaxGroupMasterSearchRequest searchRequest); 
    }
}
