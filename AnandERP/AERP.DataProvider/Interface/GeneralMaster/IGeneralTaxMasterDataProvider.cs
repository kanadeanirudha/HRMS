using System;
using AERP.Base.DTO;
using AERP.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralTaxMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxMaster> GetGeneralTaxMasterBySearch(GeneralTaxMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxMaster> GetGeneralTaxMasterGetBySearchList(GeneralTaxMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> GetGeneralTaxMasterByID(GeneralTaxMaster item);

        /// <summary>
        /// data provider interface of insert new record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> InsertGeneralTaxMaster(GeneralTaxMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> UpdateGeneralTaxMaster(GeneralTaxMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> DeleteGeneralTaxMaster(GeneralTaxMaster item);
    }
}
