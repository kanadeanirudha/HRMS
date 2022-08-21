using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralServiceMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralServiceMaster> GetGeneralServiceMasterBySearch(GeneralServiceMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralServiceMaster> GetGeneralServiceMasterGetBySearchList(GeneralServiceMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralServiceMaster> GetGeneralServiceMasterByID(GeneralServiceMaster item);

        /// <summary>
        /// data provider interface of insert new record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralServiceMaster> InsertGeneralServiceMaster(GeneralServiceMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralServiceMaster> UpdateGeneralServiceMaster(GeneralServiceMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralServiceMaster> DeleteGeneralServiceMaster(GeneralServiceMaster item);
    }
}
