using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralLevelMasterDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> InsertGeneralLevelMaster(GeneralLevelMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> UpdateGeneralLevelMaster(GeneralLevelMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> DeleteGeneralLevelMaster(GeneralLevelMaster item);

        /// <summary>
        /// data provider interface of select all record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLevelMaster> GetGeneralLevelMasterBySearch(GeneralLevelMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select records of GeneralLevelMaster for dropdown.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLevelMaster> GetGeneralLevelMasterBySearchList(GeneralLevelMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> GetGeneralLevelMasterByID(GeneralLevelMaster item);
    }
}
