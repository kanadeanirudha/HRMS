using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralCountryMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCountryMaster> GetGeneralCountryMasterBySearch(GeneralCountryMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCountryMaster> GetGeneralCountryMasterGetBySearchList(GeneralCountryMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCountryMaster> GetGeneralCountryMasterByID(GeneralCountryMaster item);

        /// <summary>
        /// data provider interface of insert new record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCountryMaster> InsertGeneralCountryMaster(GeneralCountryMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCountryMaster> UpdateGeneralCountryMaster(GeneralCountryMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCountryMaster> DeleteGeneralCountryMaster(GeneralCountryMaster item);
    }
}
