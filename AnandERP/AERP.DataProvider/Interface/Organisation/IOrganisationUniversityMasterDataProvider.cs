using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationUniversityMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterBySearch(OrganisationUniversityMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterGetBySearchList(OrganisationUniversityMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterByID(OrganisationUniversityMaster item);

        /// <summary>
        /// data provider interface of insert new record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<OrganisationUniversityMaster> InsertOrganisationUniversityMaster(OrganisationUniversityMaster item);

        /// <summary>
        /// data provider interface of update record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<OrganisationUniversityMaster> UpdateOrganisationUniversityMaster(OrganisationUniversityMaster item);

        /// <summary>
        /// data provider interface of dalete record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<OrganisationUniversityMaster> DeleteOrganisationUniversityMaster(OrganisationUniversityMaster item);

        IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterByCentreCode(OrganisationUniversityMasterSearchRequest searchRequest);



        /// <summary>
        /// data provider interface of select all record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetOrganisationUniversityMasterGetBySearchListWithoutCenterCode(OrganisationUniversityMasterSearchRequest searchRequest);

    }
}


