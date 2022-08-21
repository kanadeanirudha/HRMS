using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
	public interface IOrganisationCentrewiseDepartmentDataProvider
	{
		IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
		IBaseEntityResponse<OrganisationCentrewiseDepartment> UpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
        IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertUpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
		IBaseEntityResponse<OrganisationCentrewiseDepartment> DeleteOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
		IBaseEntityCollectionResponse<OrganisationCentrewiseDepartment> GetOrganisationCentrewiseDepartmentBySearch(OrganisationCentrewiseDepartmentSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationCentrewiseDepartment> GetOrganisationCentrewiseDepartmentByID(OrganisationCentrewiseDepartment item);
	}
}
