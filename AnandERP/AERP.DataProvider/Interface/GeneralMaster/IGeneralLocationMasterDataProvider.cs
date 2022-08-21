using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralLocationMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetGeneralLocationMasterBySearch(GeneralLocationMasterSearchRequest searchRequest);
        
         /// <summary>
        /// data provider interface of select all record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetGeneralLocationMasterGetBySearchList(GeneralLocationMasterSearchRequest searchRequest);


        /// <summary>
        /// data provider interface of select one record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> GetGeneralLocationMasterByID(GeneralLocationMaster item);

        /// <summary>
        /// data provider interface of insert new record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> InsertGeneralLocationMaster(GeneralLocationMaster item);

        /// <summary>
        /// data provider interface of update record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> UpdateGeneralLocationMaster(GeneralLocationMaster item);

        /// <summary>
        /// data provider interface of dalete record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> DeleteGeneralLocationMaster(GeneralLocationMaster item);


         /// <summary>
        /// data provider interface of select all record of General Location Master by CityID.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetGeneralLocationMasterGetByCityID(GeneralLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetByRegionIDAndCityID(GeneralLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearchKeyWord(GeneralLocationMasterSearchRequest searchRequest);
        
    }
}