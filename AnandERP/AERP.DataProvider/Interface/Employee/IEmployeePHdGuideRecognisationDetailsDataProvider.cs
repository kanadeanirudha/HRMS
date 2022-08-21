using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IEmployeePHdGuideRecognisationDetailsDataProvider
	{
		IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item);
		IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item);
		IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item);
		IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> GetEmployeePHdGuideRecognisationDetailsBySearch(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest);
		IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> GetEmployeePHdGuideRecognisationDetailsByID(EmployeePHdGuideRecognisationDetails item);

        IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item);
        IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item);
        IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item);
        IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> GetEmployeePHdGuideStudentsDetailsBySearch(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> GetEmployeePHdGuideStudentsDetailsByID(EmployeePHdGuideRecognisationDetails item);
	}
}
	