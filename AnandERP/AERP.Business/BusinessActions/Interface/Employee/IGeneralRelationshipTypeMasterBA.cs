using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralRelationshipTypeMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> InsertGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item);

        /// <summary>
        /// business action interface of update record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> UpdateGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> DeleteGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item);

        IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetGeneralRelationshipTypeMasterGetBySearchList(GeneralRelationshipTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetBySearch(GeneralRelationshipTypeMasterSearchRequest searchRequest);


        IBaseEntityResponse<GeneralRelationshipTypeMaster> SelectByID(GeneralRelationshipTypeMaster item);
    }
}
