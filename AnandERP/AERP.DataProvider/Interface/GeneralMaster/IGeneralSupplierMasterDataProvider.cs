using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IGeneralSupplierMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralSupplierMaster> GetGeneralSupplierMasterBySearch(GeneralSupplierMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> GetGeneralSupplierMasterByID(GeneralSupplierMaster item);

        /// <summary>
        /// data provider interface of insert new record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> InsertGeneralSupplierMaster(GeneralSupplierMaster item);

        /// <summary>
        /// data provider interface of update record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> UpdateGeneralSupplierMaster(GeneralSupplierMaster item);

        /// <summary>
        /// data provider interface of dalete record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> DeleteGeneralSupplierMaster(GeneralSupplierMaster item);


        IBaseEntityCollectionResponse<GeneralSupplierMaster> GetGeneralSupplierMasterGetBySearchList(GeneralSupplierMasterSearchRequest searchRequest);
    }
}
