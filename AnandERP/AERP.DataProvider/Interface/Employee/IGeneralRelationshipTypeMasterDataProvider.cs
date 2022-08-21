using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralRelationshipTypeMasterDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> InsertGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> UpdateGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> DeleteGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item);

        IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetGeneralRelationshipTypeMasterGetBySearchList(GeneralRelationshipTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetGeneralRelationshipTypeMasterBySearch(GeneralRelationshipTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> GetGeneralRelationshipTypeMasterByID(GeneralRelationshipTypeMaster item);
    }
}
