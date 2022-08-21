using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralCityMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> InsertGeneralCityMaster(GeneralCityMaster item);

        /// <summary>
        /// business action interface of update record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> UpdateGeneralCityMaster(GeneralCityMaster item);

        /// <summary>
        /// business action interface of dalete record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> DeleteGeneralCityMaster(GeneralCityMaster item);

        /// <summary>
        /// business action interface of select all record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCityMaster> GetBySearch(GeneralCityMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCityMaster> GetByRegionID(GeneralCityMasterSearchRequest searchRequest);

       
        /// <summary>
        /// business action interface of select one record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> SelectByID(GeneralCityMaster item);

        IBaseEntityCollectionResponse<GeneralCityMaster> GetBySearchList(GeneralCityMasterSearchRequest searchRequest);
    }
}
