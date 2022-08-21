using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationAdmissionTypeMasterBA
    {
        IBaseEntityResponse<OrganisationAdmissionTypeMaster> InsertOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item);
        IBaseEntityResponse<OrganisationAdmissionTypeMaster> UpdateOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item);
        IBaseEntityResponse<OrganisationAdmissionTypeMaster> DeleteOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item);
        IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> GetBySearch(OrganisationAdmissionTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationAdmissionTypeMaster> SelectByID(OrganisationAdmissionTypeMaster item);
        IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> GetBySearchList(OrganisationAdmissionTypeMasterSearchRequest searchRequest);
    }
}
