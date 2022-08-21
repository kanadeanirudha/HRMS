using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationDepartmentBranchBA
    {
        IBaseEntityResponse<OrganisationDepartmentBranch> InsertOrganisationDepartmentBranch(OrganisationDepartmentBranch item);
        IBaseEntityResponse<OrganisationDepartmentBranch> UpdateOrganisationDepartmentBranch(OrganisationDepartmentBranch item);
        IBaseEntityResponse<OrganisationDepartmentBranch> DeleteOrganisationDepartmentBranch(OrganisationDepartmentBranch item);
        IBaseEntityCollectionResponse<OrganisationDepartmentBranch> GetBySearch(OrganisationDepartmentBranchSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationDepartmentBranch> SelectByID(OrganisationDepartmentBranch item);
    }
}
