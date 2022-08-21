using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralJobStatusBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> InsertGeneralJobStatus(GeneralJobStatus item);

        /// <summary>
        /// business action interface of update record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> UpdateGeneralJobStatus(GeneralJobStatus item);

        /// <summary>
        /// business action interface of dalete record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> DeleteGeneralJobStatus(GeneralJobStatus item);

        /// <summary>
        /// business action interface of select all record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobStatus> GetBySearch(GeneralJobStatusSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralJobStatus> GetBySearchList(GeneralJobStatusSearchRequest searchRequest);

        IBaseEntityResponse<GeneralJobStatus> SelectByID(GeneralJobStatus item);
    }
}
