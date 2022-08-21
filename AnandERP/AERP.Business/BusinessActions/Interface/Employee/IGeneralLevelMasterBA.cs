using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralLevelMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> InsertGeneralLevelMaster(GeneralLevelMaster item);

        /// <summary>
        /// business action interface of update record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> UpdateGeneralLevelMaster(GeneralLevelMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> DeleteGeneralLevelMaster(GeneralLevelMaster item);

        /// <summary>
        /// business action interface of select all record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLevelMaster> GetBySearch(GeneralLevelMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select records of GeneralLevelMaster for dropdown.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLevelMaster> GetBySearchList(GeneralLevelMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralLevelMaster> SelectByID(GeneralLevelMaster item);
    }
}
