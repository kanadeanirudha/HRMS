using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralRegionMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRegionMaster> GetGeneralRegionMasterBySearch(GeneralRegionMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRegionMaster> GetGeneralRegionMasterGetByCountryID(GeneralRegionMasterSearchRequest searchRequest);
        
        /// <summary>
        /// data provider interface of select one record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> GetGeneralRegionMasterByID(GeneralRegionMaster item);

        /// <summary>
        /// data provider interface of insert new record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> InsertGeneralRegionMaster(GeneralRegionMaster item);

        /// <summary>
        /// data provider interface of update record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> UpdateGeneralRegionMaster(GeneralRegionMaster item);

        /// <summary>
        /// data provider interface of dalete record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> DeleteGeneralRegionMaster(GeneralRegionMaster item);
    }
}
