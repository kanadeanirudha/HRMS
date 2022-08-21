using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeeServiceDetailsDataProvider
    {
        IBaseEntityResponse<EmployeeServiceDetails> InsertEmployeeServiceDetails(EmployeeServiceDetails item);
        IBaseEntityResponse<EmployeeServiceDetails> UpdateEmployeeServiceDetails(EmployeeServiceDetails item);
        IBaseEntityResponse<EmployeeServiceDetails> DeleteEmployeeServiceDetails(EmployeeServiceDetails item);
        IBaseEntityCollectionResponse<EmployeeServiceDetails> GetEmployeeServiceDetailsBySearch(EmployeeServiceDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeServiceDetails> GetEmployeeServiceDetailsBySearchList(EmployeeServiceDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeServiceDetails> GetEmployeeServiceDetailsByID(EmployeeServiceDetails item);
        IBaseEntityResponse<EmployeeServiceDetails> GetEmployeeServiceDetailsByEmployeeID(EmployeeServiceDetails item);
    }
}
