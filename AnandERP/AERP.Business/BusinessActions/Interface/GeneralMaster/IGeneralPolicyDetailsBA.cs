using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralPolicyDetailsBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyDetails> InsertGeneralPolicyDetails(GeneralPolicyDetails item);

        /// <summary>
        /// business action interface of update record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyDetails> UpdateGeneralPolicyDetails(GeneralPolicyDetails item);

        /// <summary>
        /// business action interface of dalete record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyDetails> DeleteGeneralPolicyDetails(GeneralPolicyDetails item);

        /// <summary>
        /// business action interface of select all record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyDetails> GetBySearch(GeneralPolicyDetailsSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyDetails> GetGeneralPolicyDetailsList(GeneralPolicyDetailsSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyDetails> SelectByID(GeneralPolicyDetails item);
    }
}
