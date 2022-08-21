using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeLanguageDetailsDataProvider
    {
        IBaseEntityResponse<EmployeeLanguageDetails> InsertEmployeeLanguageDetails(EmployeeLanguageDetails item);
        IBaseEntityResponse<EmployeeLanguageDetails> UpdateEmployeeLanguageDetails(EmployeeLanguageDetails item);
        IBaseEntityResponse<EmployeeLanguageDetails> DeleteEmployeeLanguageDetails(EmployeeLanguageDetails item);
        IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetEmployeeLanguageDetailsBySearch(EmployeeLanguageDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetEmployeeLanguageDetailsByID(EmployeeLanguageDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeLanguageDetails> GetEmployeeLanguageDetailsByID(EmployeeLanguageDetails item);
    }
}
