using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationElectiveGrpMasterBA
    {
        IBaseEntityResponse<OrganisationElectiveGrpMaster> InsertOrganisationElectiveGrpMaster(OrganisationElectiveGrpMaster item);
        IBaseEntityResponse<OrganisationElectiveGrpMaster> UpdateOrganisationElectiveGrpMaster(OrganisationElectiveGrpMaster item);
        IBaseEntityResponse<OrganisationElectiveGrpMaster> DeleteOrganisationElectiveGrpMaster(OrganisationElectiveGrpMaster item);
        IBaseEntityCollectionResponse<OrganisationElectiveGrpMaster> GetBySearch(OrganisationElectiveGrpMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationElectiveGrpMaster> SelectByID(OrganisationElectiveGrpMaster item);
    }
}
