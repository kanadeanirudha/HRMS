using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface IEmployeeProjectWorksMasterBA
	{
		IBaseEntityResponse<EmployeeProjectWorksMaster> InsertEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item);
		IBaseEntityResponse<EmployeeProjectWorksMaster> UpdateEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item);
		IBaseEntityResponse<EmployeeProjectWorksMaster> DeleteEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item);
		IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetBySearch(EmployeeProjectWorksMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetAppliedDetails(EmployeeProjectWorksMasterSearchRequest searchRequest); 
		IBaseEntityResponse<EmployeeProjectWorksMaster> SelectByID(EmployeeProjectWorksMaster item);

        IBaseEntityResponse<EmployeeProjectWorksMaster> InsertEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item);
        IBaseEntityResponse<EmployeeProjectWorksMaster> UpdateEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item);
        IBaseEntityResponse<EmployeeProjectWorksMaster> DeleteEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item);
        IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetBySearchEmployeeProjectWorksDetails(EmployeeProjectWorksMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeProjectWorksMaster> SelectEmployeeCentreCode(EmployeeProjectWorksMaster item);
	}
}
