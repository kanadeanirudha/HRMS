using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationSubElectiveGrpMasterBA
    {
        IBaseEntityResponse<OrganisationSubElectiveGrpMaster> InsertOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item);
        IBaseEntityResponse<OrganisationSubElectiveGrpMaster> UpdateOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item);
        IBaseEntityResponse<OrganisationSubElectiveGrpMaster> DeleteOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item);
        IBaseEntityCollectionResponse<OrganisationSubElectiveGrpMaster> GetBySearch(OrganisationSubElectiveGrpMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubElectiveGrpMaster> SelectByID(OrganisationSubElectiveGrpMaster item);
    }
}
