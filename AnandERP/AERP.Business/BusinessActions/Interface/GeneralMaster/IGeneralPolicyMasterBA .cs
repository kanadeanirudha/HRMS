using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralPolicyMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyMaster> InsertGeneralPolicyMaster(GeneralPolicyMaster item);

        /// <summary>
        /// business action interface of update record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyMaster> UpdateGeneralPolicyMaster(GeneralPolicyMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyMaster> DeleteGeneralPolicyMaster(GeneralPolicyMaster item);

        /// <summary>
        /// business action interface of select all record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyMaster> GetBySearch(GeneralPolicyMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyMaster> GetGeneralPolicyMasterList(GeneralPolicyMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyMaster> SelectByID(GeneralPolicyMaster item);
    }
}
