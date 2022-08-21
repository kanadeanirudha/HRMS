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
    public interface IGeneralPolicyDetailsDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyDetails> GetGeneralPolicyDetailsBySearch(GeneralPolicyDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyDetails> GetGeneralPolicyDetailsGetBySearchList(GeneralPolicyDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyDetails> GetGeneralPolicyDetailsByID(GeneralPolicyDetails item);

        /// <summary>
        /// data provider interface of insert new record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyDetails> InsertGeneralPolicyDetails(GeneralPolicyDetails item);

        /// <summary>
        /// data provider interface of update record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyDetails> UpdateGeneralPolicyDetails(GeneralPolicyDetails item);

        /// <summary>
        /// data provider interface of dalete record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyDetails> DeleteGeneralPolicyDetails(GeneralPolicyDetails item);
    }
}
