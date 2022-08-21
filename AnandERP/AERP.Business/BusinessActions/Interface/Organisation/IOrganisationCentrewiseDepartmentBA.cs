using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IOrganisationCentrewiseDepartmentBA
    {
        IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
        IBaseEntityResponse<OrganisationCentrewiseDepartment> UpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
        IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertUpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
        IBaseEntityResponse<OrganisationCentrewiseDepartment> DeleteOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
        IBaseEntityCollectionResponse<OrganisationCentrewiseDepartment> GetBySearch(OrganisationCentrewiseDepartmentSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationCentrewiseDepartment> SelectByID(OrganisationCentrewiseDepartment item);
    }
}
