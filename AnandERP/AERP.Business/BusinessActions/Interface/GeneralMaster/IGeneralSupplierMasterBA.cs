using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralSupplierMasterBA
    {
        /// <summary>
        /// business action interface of select all record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralSupplierMaster> GetBySearch(GeneralSupplierMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> SelectByID(GeneralSupplierMaster item);

        /// <summary>
        /// business action interface of insert new record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> InsertGeneralSupplierMaster(GeneralSupplierMaster item);

        /// <summary>
        /// business action interface of update record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> UpdateGeneralSupplierMaster(GeneralSupplierMaster item);

        /// <summary>
        /// business action interface of dalete record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> DeleteGeneralSupplierMaster(GeneralSupplierMaster item);

        IBaseEntityCollectionResponse<GeneralSupplierMaster> GetBySearchList(GeneralSupplierMasterSearchRequest searchRequest);
    }
}
