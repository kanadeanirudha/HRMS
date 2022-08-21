using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IEmployeeContactDetailsBA
    {
        IBaseEntityResponse<EmployeeContactDetails> InsertEmployeeContactDetails(EmployeeContactDetails item);
        IBaseEntityResponse<EmployeeContactDetails> UpdateEmployeeContactDetails(EmployeeContactDetails item);
        IBaseEntityResponse<EmployeeContactDetails> DeleteEmployeeContactDetails(EmployeeContactDetails item);
        IBaseEntityCollectionResponse<EmployeeContactDetails> GetBySearch(EmployeeContactDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeContactDetails> SelectByID(EmployeeContactDetails item);
    }
}
