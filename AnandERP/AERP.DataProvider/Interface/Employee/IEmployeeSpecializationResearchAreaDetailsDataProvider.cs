using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeSpecializationResearchAreaDetailsDataProvider
    {
        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> InsertEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item);
        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> UpdateEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item);
        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> DeleteEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item);
        IBaseEntityCollectionResponse<EmployeeSpecializationResearchAreaDetails> GetEmployeeSpecializationResearchAreaDetailsBySearch(EmployeeSpecializationResearchAreaDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> GetEmployeeSpecializationResearchAreaDetailsByID(EmployeeSpecializationResearchAreaDetails item);
    }
}
