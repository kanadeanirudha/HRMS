using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationDepartmentBranchDataProvider
    {
        IBaseEntityResponse<OrganisationDepartmentBranch> InsertOrganisationDepartmentBranch(OrganisationDepartmentBranch item);
        IBaseEntityResponse<OrganisationDepartmentBranch> UpdateOrganisationDepartmentBranch(OrganisationDepartmentBranch item);
        IBaseEntityResponse<OrganisationDepartmentBranch> DeleteOrganisationDepartmentBranch(OrganisationDepartmentBranch item);
        IBaseEntityCollectionResponse<OrganisationDepartmentBranch> GetOrganisationDepartmentBranchBySearch(OrganisationDepartmentBranchSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationDepartmentBranch> GetOrganisationDepartmentBranchByID(OrganisationDepartmentBranch item);
    }
}
