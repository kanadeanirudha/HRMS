using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralCurrencyMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCurrencyMaster> InsertGeneralCurrencyMaster(GeneralCurrencyMaster item);

        /// <summary>
        /// business action interface of update record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCurrencyMaster> UpdateGeneralCurrencyMaster(GeneralCurrencyMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCurrencyMaster> DeleteGeneralCurrencyMaster(GeneralCurrencyMaster item);

        /// <summary>
        /// business action interface of select all record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetBySearch(GeneralCurrencyMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetBySearchList(GeneralCurrencyMasterSearchRequest searchRequest);



        IBaseEntityResponse<GeneralCurrencyMaster> SelectByID(GeneralCurrencyMaster item);
    }
}
