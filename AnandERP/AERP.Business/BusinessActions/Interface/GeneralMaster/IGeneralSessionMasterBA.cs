using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business
{
    public interface IGeneralSessionMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> InsertGeneralSessionMaster(GeneralSessionMaster item);

        /// <summary>
        /// business action interface of update record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> UpdateGeneralSessionMaster(GeneralSessionMaster item);

        /// <summary>
        /// business action interface of dalete record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> DeleteGeneralSessionMaster(GeneralSessionMaster item);

        /// <summary>
        /// business action interface of select all record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralSessionMaster> GetBySearch(GeneralSessionMasterSearchRequest searchRequest);
        
        /// <summary>
        /// business action interface of select all record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralSessionMaster> GetBySearchList(GeneralSessionMasterSearchRequest searchRequest);
        /// <summary>
        /// business action interface of select one record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> SelectByID(GeneralSessionMaster item);
        //Used in Online Exam
        IBaseEntityCollectionResponse<GeneralSessionMaster> GetSession(GeneralSessionMasterSearchRequest searchRequest);
    }
}
