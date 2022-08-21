using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface IEmployeeConsultancyMasterBA
	{
		IBaseEntityResponse<EmployeeConsultancyMaster> InsertEmployeeConsultancyMaster(EmployeeConsultancyMaster item);
		IBaseEntityResponse<EmployeeConsultancyMaster> UpdateEmployeeConsultancyMaster(EmployeeConsultancyMaster item);
		IBaseEntityResponse<EmployeeConsultancyMaster> DeleteEmployeeConsultancyMaster(EmployeeConsultancyMaster item);
		IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetBySearch(EmployeeConsultancyMasterSearchRequest searchRequest);
		IBaseEntityResponse<EmployeeConsultancyMaster> SelectByID(EmployeeConsultancyMaster item);
        IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetAppliedDetails(EmployeeConsultancyMasterSearchRequest searchRequest);

        IBaseEntityResponse<EmployeeConsultancyMaster> InsertEmployeeConsultancyDetails(EmployeeConsultancyMaster item);
        IBaseEntityResponse<EmployeeConsultancyMaster> UpdateEmployeeConsultancyDetails(EmployeeConsultancyMaster item);
        IBaseEntityResponse<EmployeeConsultancyMaster> DeleteEmployeeConsultancyDetails(EmployeeConsultancyMaster item);
        IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetBySearchEmployeeConsultancyDetails(EmployeeConsultancyMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeConsultancyMaster> SelectEmployeeCentreCode(EmployeeConsultancyMaster item);
	}
}

