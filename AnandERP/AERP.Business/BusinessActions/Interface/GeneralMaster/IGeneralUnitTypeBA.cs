using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralUnitTypeBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> InsertGeneralUnitType(GeneralUnitType item);

        /// <summary>
        /// business action interface of update record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> UpdateGeneralUnitType(GeneralUnitType item);

        /// <summary>
        /// business action interface of dalete record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> DeleteGeneralUnitType(GeneralUnitType item);

        /// <summary>
        /// business action interface of select all record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralUnitType> GetBySearch(GeneralUnitTypeSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralUnitType> GetBySearchList(GeneralUnitTypeSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> SelectByID(GeneralUnitType item);
    }
}
