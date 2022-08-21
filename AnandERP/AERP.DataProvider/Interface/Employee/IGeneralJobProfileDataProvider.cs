using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralJobProfileDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> InsertGeneralJobProfile(GeneralJobProfile item);

        /// <summary>
        /// data provider interface of update record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> UpdateGeneralJobProfile(GeneralJobProfile item);

        /// <summary>
        /// data provider interface of dalete record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> DeleteGeneralJobProfile(GeneralJobProfile item);

        /// <summary>
        /// data provider interface of select all record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobProfile> GetGeneralJobProfileBySearch(GeneralJobProfileSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select records of GeneralJobProfile for dropdown.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobProfile> GetGeneralJobProfileGetBySearchList(GeneralJobProfileSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> GetGeneralJobProfileByID(GeneralJobProfile item);
    }
}
