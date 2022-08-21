using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralIndustryMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralIndustryMaster> GetGeneralIndustryMasterBySearch(GeneralIndustryMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralIndustryMaster> GetGeneralIndustryMasterGetBySearchList(GeneralIndustryMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralIndustryMaster> GetGeneralIndustryMasterByID(GeneralIndustryMaster item);

        /// <summary>
        /// data provider interface of insert new record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralIndustryMaster> InsertGeneralIndustryMaster(GeneralIndustryMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralIndustryMaster> UpdateGeneralIndustryMaster(GeneralIndustryMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralIndustryMaster> DeleteGeneralIndustryMaster(GeneralIndustryMaster item);
    }
}
