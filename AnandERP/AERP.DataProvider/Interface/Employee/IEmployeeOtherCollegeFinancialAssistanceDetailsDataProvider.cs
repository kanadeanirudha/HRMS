using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeOtherCollegeFinancialAssistanceDetailsDataProvider
    {
        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> InsertEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> UpdateEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> DeleteEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item);
        IBaseEntityCollectionResponse<EmployeeOtherCollegeFinancialAssistanceDetails> GetEmployeeOtherCollegeFinancialAssistanceDetailsBySearch(EmployeeOtherCollegeFinancialAssistanceDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> GetEmployeeOtherCollegeFinancialAssistanceDetailsByID(EmployeeOtherCollegeFinancialAssistanceDetails item);
    }
}
