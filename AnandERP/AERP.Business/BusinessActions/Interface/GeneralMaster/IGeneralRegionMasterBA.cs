using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralRegionMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> InsertGeneralRegionMaster(GeneralRegionMaster item);

        /// <summary>
        /// business action interface of update record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> UpdateGeneralRegionMaster(GeneralRegionMaster item);

        /// <summary>
        /// business action interface of dalete record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> DeleteGeneralRegionMaster(GeneralRegionMaster item);

        /// <summary>
        /// business action interface of select all record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRegionMaster> GetBySearch(GeneralRegionMasterSearchRequest searchRequest);
        
        /// <summary>
        /// business action interface of select all record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRegionMaster> GetByCountryID(GeneralRegionMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> SelectByID(GeneralRegionMaster item);
    }
}
