using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeePrizesWonDetailsBA
    {
        IBaseEntityResponse<EmployeePrizesWonDetails> InsertEmployeePrizesWonDetails(EmployeePrizesWonDetails item);
        IBaseEntityResponse<EmployeePrizesWonDetails> UpdateEmployeePrizesWonDetails(EmployeePrizesWonDetails item);
        IBaseEntityResponse<EmployeePrizesWonDetails> DeleteEmployeePrizesWonDetails(EmployeePrizesWonDetails item);
        IBaseEntityCollectionResponse<EmployeePrizesWonDetails> GetBySearch(EmployeePrizesWonDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePrizesWonDetails> SelectByID(EmployeePrizesWonDetails item);
    }
}
