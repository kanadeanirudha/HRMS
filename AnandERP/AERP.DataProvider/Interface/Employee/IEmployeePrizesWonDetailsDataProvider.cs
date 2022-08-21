using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeePrizesWonDetailsDataProvider
    {
        IBaseEntityResponse<EmployeePrizesWonDetails> InsertEmployeePrizesWonDetails(EmployeePrizesWonDetails item);
        IBaseEntityResponse<EmployeePrizesWonDetails> UpdateEmployeePrizesWonDetails(EmployeePrizesWonDetails item);
        IBaseEntityResponse<EmployeePrizesWonDetails> DeleteEmployeePrizesWonDetails(EmployeePrizesWonDetails item);
        IBaseEntityCollectionResponse<EmployeePrizesWonDetails> GetEmployeePrizesWonDetailsBySearch(EmployeePrizesWonDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePrizesWonDetails> GetEmployeePrizesWonDetailsByID(EmployeePrizesWonDetails item);
    }
}
