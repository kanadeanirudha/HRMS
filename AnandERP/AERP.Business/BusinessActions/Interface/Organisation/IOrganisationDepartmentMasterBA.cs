using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IOrganisationDepartmentMasterBA
    {
        IBaseEntityResponse<OrganisationDepartmentMaster> InsertOrganisationDepartmentMaster(OrganisationDepartmentMaster item);

        IBaseEntityResponse<OrganisationDepartmentMaster> UpdateOrganisationDepartmentMaster(OrganisationDepartmentMaster item);

        IBaseEntityResponse<OrganisationDepartmentMaster> DeleteOrganisationDepartmentMaster(OrganisationDepartmentMaster item);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetBySearch(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityResponse<OrganisationDepartmentMaster> SelectByID(OrganisationDepartmentMaster item);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetBySearchList(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetByCentreCode(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetByCentrewise(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartmentListRoleWise(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartmentListCentreAndRoleWise(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetByDepartmentNameSearchList_ForPurchase(OrganisationDepartmentMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartment(OrganisationDepartmentMasterSearchRequest searchRequest);
    }
}
