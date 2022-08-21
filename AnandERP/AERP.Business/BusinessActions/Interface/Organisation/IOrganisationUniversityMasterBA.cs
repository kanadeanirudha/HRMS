using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IOrganisationUniversityMasterBA
    {

        /// <summary>
        /// business action interface of insert new record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<OrganisationUniversityMaster> InsertOrganisationUniversityMaster(OrganisationUniversityMaster item);

        /// <summary>
        /// business action interface of update record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<OrganisationUniversityMaster> UpdateOrganisationUniversityMaster(OrganisationUniversityMaster item);

        /// <summary>
        /// business action interface of dalete record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<OrganisationUniversityMaster> DeleteOrganisationUniversityMaster(OrganisationUniversityMaster item);

        /// <summary>
        /// business action interface of select all record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetBySearch(OrganisationUniversityMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetBySearchList(OrganisationUniversityMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<OrganisationUniversityMaster> SelectByID(OrganisationUniversityMaster item);


        IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetByCentreCode(OrganisationUniversityMasterSearchRequest searchRequest);


        /// <summary>
        /// business action interface of select all record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetBySearchListWithoutCenterCode(OrganisationUniversityMasterSearchRequest searchRequest);
    }
}
