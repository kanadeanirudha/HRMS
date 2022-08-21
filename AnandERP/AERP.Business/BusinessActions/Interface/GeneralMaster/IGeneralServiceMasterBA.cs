using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralServiceMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralServiceMaster> InsertGeneralServiceMaster(GeneralServiceMaster item);

        /// <summary>
        /// business action interface of update record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralServiceMaster> UpdateGeneralServiceMaster(GeneralServiceMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralServiceMaster> DeleteGeneralServiceMaster(GeneralServiceMaster item);

        /// <summary>
        /// business action interface of select all record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralServiceMaster> GetBySearch(GeneralServiceMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralServiceMaster> GetBySearchList(GeneralServiceMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralServiceMaster> SelectByID(GeneralServiceMaster item);
    }
}
