using System;
using System.Collections.Generic;
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
   public  interface IGeneralTaskModelDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of GeneralTaskModel.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskModel> GetGeneralTaskModelBySearch(GeneralTaskModelSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralTaskModel.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskModel> GetMenuCodeAndMenuLink(GeneralTaskModelSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralTaskModel.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaskModel> GetTaskCode(GeneralTaskModelSearchRequest searchRequest);      
       
       
       
       /// <summary>
        /// data provider interface of select one record of GeneralTaskModel.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskModel> GetGeneralTaskModelByID(GeneralTaskModel item);

        /// <summary>
        /// data provider interface of insert new record of GeneralTaskModel.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskModel> InsertGeneralTaskModel(GeneralTaskModel item);

        /// <summary>
        /// data provider interface of update record of GeneralTaskModel.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskModel> UpdateGeneralTaskModel(GeneralTaskModel item);

        /// <summary>
        /// data provider interface of dalete record of GeneralTaskModel.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaskModel> DeleteGeneralTaskModel(GeneralTaskModel item);
    }
}
