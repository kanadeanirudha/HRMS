using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralOperatorRelatedRoleBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralOperatorRelatedRole> InsertGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item);

        /// <summary>
        /// business action interface of update record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralOperatorRelatedRole> UpdateGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item);

        /// <summary>
        /// business action interface of dalete record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralOperatorRelatedRole> DeleteGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item);

        /// <summary>
        /// business action interface of select all record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetBySearch(GeneralOperatorRelatedRoleSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetBySearchList(GeneralOperatorRelatedRoleSearchRequest searchRequest);


        IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetAdminRoleCodeList(GeneralOperatorRelatedRoleSearchRequest searchRequest);
        IBaseEntityResponse<GeneralOperatorRelatedRole> SelectByID(GeneralOperatorRelatedRole item);
    }
}
