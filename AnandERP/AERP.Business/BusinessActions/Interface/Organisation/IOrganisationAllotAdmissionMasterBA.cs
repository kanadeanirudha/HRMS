using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationAllotAdmissionMasterBA
    {
        IBaseEntityResponse<OrganisationAllotAdmissionMaster> InsertOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item);
        IBaseEntityResponse<OrganisationAllotAdmissionMaster> UpdateOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item);
        IBaseEntityResponse<OrganisationAllotAdmissionMaster> DeleteOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item);
        IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> GetBySearch(OrganisationAllotAdmissionMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationAllotAdmissionMaster> SelectByID(OrganisationAllotAdmissionMaster item);
        IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> GetBySearchList(OrganisationAllotAdmissionMasterSearchRequest searchRequest);
    }
}
