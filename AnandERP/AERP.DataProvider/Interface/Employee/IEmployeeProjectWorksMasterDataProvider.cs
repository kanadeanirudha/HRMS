using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IEmployeeProjectWorksMasterDataProvider
	{
		IBaseEntityResponse<EmployeeProjectWorksMaster> InsertEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item);
		IBaseEntityResponse<EmployeeProjectWorksMaster> UpdateEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item);
		IBaseEntityResponse<EmployeeProjectWorksMaster> DeleteEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item);
		IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetEmployeeProjectWorksMasterBySearch(EmployeeProjectWorksMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetAppliedDetailsEmployeeProjectWorksMasterBySearch(EmployeeProjectWorksMasterSearchRequest searchRequest);
		IBaseEntityResponse<EmployeeProjectWorksMaster> GetEmployeeProjectWorksMasterByID(EmployeeProjectWorksMaster item);

        IBaseEntityResponse<EmployeeProjectWorksMaster> InsertEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item);
        IBaseEntityResponse<EmployeeProjectWorksMaster> UpdateEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item);
        IBaseEntityResponse<EmployeeProjectWorksMaster> DeleteEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item);
        IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetEmployeeProjectWorksDetailsBySearch(EmployeeProjectWorksMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeProjectWorksMaster> SelectEmployeeCentreCode(EmployeeProjectWorksMaster item);
	}
}
