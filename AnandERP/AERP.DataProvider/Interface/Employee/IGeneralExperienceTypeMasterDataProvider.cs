using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralExperienceTypeMasterDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> InsertGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> UpdateGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> DeleteGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item);

        /// <summary>
        /// data provider interface of select all record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetGeneralExperienceTypeMasterBySearch(GeneralExperienceTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralExperienceTypeMaster for dropdown.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetGeneralExperienceTypeMasterBySearchList(GeneralExperienceTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> GetGeneralExperienceTypeMasterByID(GeneralExperienceTypeMaster item);
    }
}
