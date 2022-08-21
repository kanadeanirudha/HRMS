using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IGeneralSessionMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralSessionMaster> GetGeneralSessionMasterBySearch(GeneralSessionMasterSearchRequest searchRequest);
        
        /// <summary>
        /// data provider interface of select all record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralSessionMaster> GetGeneralSessionMasterGetBySearchList(GeneralSessionMasterSearchRequest searchRequest);
        /// <summary>
        /// data provider interface of select one record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> GetGeneralSessionMasterByID(GeneralSessionMaster item);

        /// <summary>
        /// data provider interface of insert new record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> InsertGeneralSessionMaster(GeneralSessionMaster item);

        /// <summary>
        /// data provider interface of update record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> UpdateGeneralSessionMaster(GeneralSessionMaster item);

        /// <summary>
        /// data provider interface of dalete record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> DeleteGeneralSessionMaster(GeneralSessionMaster item);
        //Online
        IBaseEntityCollectionResponse<GeneralSessionMaster> GetSession(GeneralSessionMasterSearchRequest searchRequest);
    }
}
