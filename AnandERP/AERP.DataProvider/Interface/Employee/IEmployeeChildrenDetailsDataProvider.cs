using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeChildrenDetailsDataProvider
    {
        IBaseEntityResponse<EmployeeChildrenDetails> InsertEmployeeChildrenDetails(EmployeeChildrenDetails item);
        IBaseEntityResponse<EmployeeChildrenDetails> UpdateEmployeeChildrenDetails(EmployeeChildrenDetails item);
        IBaseEntityResponse<EmployeeChildrenDetails> DeleteEmployeeChildrenDetails(EmployeeChildrenDetails item);
        IBaseEntityCollectionResponse<EmployeeChildrenDetails> GetEmployeeChildrenDetailsBySearch(EmployeeChildrenDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeChildrenDetails> GetEmployeeChildrenDetailsByID(EmployeeChildrenDetails item);
    }
}
