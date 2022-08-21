using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralUnitTypeDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralUnitType> GetGeneralUnitTypeBySearch(GeneralUnitTypeSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralUnitType> GetGeneralUnitTypeGetBySearchList(GeneralUnitTypeSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> GetGeneralUnitTypeByID(GeneralUnitType item);

        /// <summary>
        /// data provider interface of insert new record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> InsertGeneralUnitType(GeneralUnitType item);

        /// <summary>
        /// data provider interface of update record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> UpdateGeneralUnitType(GeneralUnitType item);

        /// <summary>
        /// data provider interface of dalete record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> DeleteGeneralUnitType(GeneralUnitType item);
    }
}
