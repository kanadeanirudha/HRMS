using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AERP.DataProvider
{
    public interface IGeneralCityMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCityMaster> GetGeneralCityMasterBySearch(GeneralCityMasterSearchRequest searchRequest);

         /// <summary>
        /// data provider interface of select all record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCityMaster> GetGeneralCityMasterGetByRegionID(GeneralCityMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> GetGeneralCityMasterByID(GeneralCityMaster item);

        /// <summary>
        /// data provider interface of insert new record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> InsertGeneralCityMaster(GeneralCityMaster item);

        /// <summary>
        /// data provider interface of update record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> UpdateGeneralCityMaster(GeneralCityMaster item);

        /// <summary>
        /// data provider interface of dalete record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> DeleteGeneralCityMaster(GeneralCityMaster item);

        IBaseEntityCollectionResponse<GeneralCityMaster> GetGeneralCityMasterGetBySearchList(GeneralCityMasterSearchRequest searchRequest);
    }
}
