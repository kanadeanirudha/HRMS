using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeeOtherCollegeFinancialAssistanceDetailsBA
    {
        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> InsertEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> UpdateEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> DeleteEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item);
        IBaseEntityCollectionResponse<EmployeeOtherCollegeFinancialAssistanceDetails> GetBySearch(EmployeeOtherCollegeFinancialAssistanceDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> SelectByID(EmployeeOtherCollegeFinancialAssistanceDetails item);
    }
}
