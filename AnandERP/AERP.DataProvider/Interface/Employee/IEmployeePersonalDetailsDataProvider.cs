using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeePersonalDetailsDataProvider
    {
        IBaseEntityResponse<EmployeePersonalDetails> InsertEmployeePersonalDetails(EmployeePersonalDetails item);
        IBaseEntityResponse<EmployeePersonalDetails> UpdateEmployeePersonalDetails(EmployeePersonalDetails item);
        IBaseEntityResponse<EmployeePersonalDetails> DeleteEmployeePersonalDetails(EmployeePersonalDetails item);
        IBaseEntityCollectionResponse<EmployeePersonalDetails> GetEmployeePersonalDetailsBySearch(EmployeePersonalDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePersonalDetails> GetEmployeePersonalDetailsByID(EmployeePersonalDetails item);
    }
}
