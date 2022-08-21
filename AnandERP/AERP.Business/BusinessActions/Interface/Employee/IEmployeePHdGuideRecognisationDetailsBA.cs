using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface IEmployeePHdGuideRecognisationDetailsBA
	{
		IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item);
		IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item);
		IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item);
		IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> GetBySearch(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest);
		IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> SelectByID(EmployeePHdGuideRecognisationDetails item);

        IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item);
        IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item);
        IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item);
        IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> GetBySearchEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> SelectByIDEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item);
	}
}
	