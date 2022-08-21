using System;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralPolicyMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyMaster> GetGeneralPolicyMasterBySearch(GeneralPolicyMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyMaster> GetGeneralPolicyMasterGetBySearchList(GeneralPolicyMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyMaster> GetGeneralPolicyMasterByID(GeneralPolicyMaster item);

        /// <summary>
        /// data provider interface of insert new record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyMaster> InsertGeneralPolicyMaster(GeneralPolicyMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyMaster> UpdateGeneralPolicyMaster(GeneralPolicyMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyMaster> DeleteGeneralPolicyMaster(GeneralPolicyMaster item);
    }
}
