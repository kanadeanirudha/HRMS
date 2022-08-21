using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralJobStatusDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> InsertGeneralJobStatus(GeneralJobStatus item);

        /// <summary>
        /// data provider interface of update record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> UpdateGeneralJobStatus(GeneralJobStatus item);

        /// <summary>
        /// data provider interface of dalete record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> DeleteGeneralJobStatus(GeneralJobStatus item);

        /// <summary>
        /// data provider interface of select all record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobStatus> GetGeneralJobStatusBySearch(GeneralJobStatusSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select records of GeneralJobStatus for dropdown.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobStatus> GetGeneralJobStatusBySearchList(GeneralJobStatusSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> GetGeneralJobStatusByID(GeneralJobStatus item);
    }
}
