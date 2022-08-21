using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationSubElectiveGrpMasterDataProvider
    {
        IBaseEntityResponse<OrganisationSubElectiveGrpMaster> InsertOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item);
        IBaseEntityResponse<OrganisationSubElectiveGrpMaster> UpdateOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item);
        IBaseEntityResponse<OrganisationSubElectiveGrpMaster> DeleteOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item);
        IBaseEntityCollectionResponse<OrganisationSubElectiveGrpMaster> GetOrganisationSubElectiveGrpMasterBySearch(OrganisationSubElectiveGrpMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubElectiveGrpMaster> GetOrganisationSubElectiveGrpMasterByID(OrganisationSubElectiveGrpMaster item);
    }
}
