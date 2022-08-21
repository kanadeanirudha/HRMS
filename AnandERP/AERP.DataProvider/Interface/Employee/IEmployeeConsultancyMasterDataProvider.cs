using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IEmployeeConsultancyMasterDataProvider
	{
		IBaseEntityResponse<EmployeeConsultancyMaster> InsertEmployeeConsultancyMaster(EmployeeConsultancyMaster item);
		IBaseEntityResponse<EmployeeConsultancyMaster> UpdateEmployeeConsultancyMaster(EmployeeConsultancyMaster item);
		IBaseEntityResponse<EmployeeConsultancyMaster> DeleteEmployeeConsultancyMaster(EmployeeConsultancyMaster item);
		IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetEmployeeConsultancyMasterBySearch(EmployeeConsultancyMasterSearchRequest searchRequest);        
		IBaseEntityResponse<EmployeeConsultancyMaster> GetEmployeeConsultancyMasterByID(EmployeeConsultancyMaster item);
        IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetEmployeeConsultancyMasterAppliedDetails(EmployeeConsultancyMasterSearchRequest searchRequest);

        IBaseEntityResponse<EmployeeConsultancyMaster> InsertEmployeeConsultancyDetails(EmployeeConsultancyMaster item);
        IBaseEntityResponse<EmployeeConsultancyMaster> UpdateEmployeeConsultancyDetails(EmployeeConsultancyMaster item);
        IBaseEntityResponse<EmployeeConsultancyMaster> DeleteEmployeeConsultancyDetails(EmployeeConsultancyMaster item);
        IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetEmployeeConsultancyDetailsBySearch(EmployeeConsultancyMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeConsultancyMaster> SelectEmployeeCentreCode(EmployeeConsultancyMaster item);
	}
}
