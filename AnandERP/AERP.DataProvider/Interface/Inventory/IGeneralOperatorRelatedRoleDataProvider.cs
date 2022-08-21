using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralOperatorRelatedRoleDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralOperatorRelatedRole> InsertGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item);

        /// <summary>
        /// data provider interface of update record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralOperatorRelatedRole> UpdateGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item);

        /// <summary>
        /// data provider interface of dalete record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralOperatorRelatedRole> DeleteGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item);

        /// <summary>
        /// data provider interface of select all record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetGeneralOperatorRelatedRoleBySearch(GeneralOperatorRelatedRoleSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetGeneralOperatorRelatedRoleBySearchList(GeneralOperatorRelatedRoleSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetAdminRoleCodeList(GeneralOperatorRelatedRoleSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralOperatorRelatedRole> GetGeneralOperatorRelatedRoleByID(GeneralOperatorRelatedRole item);
    }
}
