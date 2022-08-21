using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IEmployeeDependentsBA
    {
        IBaseEntityResponse<EmployeeDependents> InsertEmployeeDependents(EmployeeDependents item);
        IBaseEntityResponse<EmployeeDependents> UpdateEmployeeDependents(EmployeeDependents item);
        IBaseEntityResponse<EmployeeDependents> DeleteEmployeeDependents(EmployeeDependents item);
        IBaseEntityCollectionResponse<EmployeeDependents> GetBySearch(EmployeeDependentsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeDependents> SelectByID(EmployeeDependents item);
    }
}
