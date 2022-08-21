using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralCurrencyMasterDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCurrencyMaster> InsertGeneralCurrencyMaster(GeneralCurrencyMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCurrencyMaster> UpdateGeneralCurrencyMaster(GeneralCurrencyMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCurrencyMaster> DeleteGeneralCurrencyMaster(GeneralCurrencyMaster item);

        /// <summary>
        /// data provider interface of select all record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetGeneralCurrencyMasterBySearch(GeneralCurrencyMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetGeneralCurrencyMasterBySearchList(GeneralCurrencyMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCurrencyMaster> GetGeneralCurrencyMasterByID(GeneralCurrencyMaster item);
    }
}
