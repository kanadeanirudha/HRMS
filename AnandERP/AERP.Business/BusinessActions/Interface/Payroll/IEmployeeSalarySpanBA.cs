using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IEmployeeSalarySpanBA
    {
        IBaseEntityCollectionResponse<EmployeeSalarySpan> GetBySearch(EmployeeSalarySpanSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeSalarySpan> InsertEmployeeSalarySpan(EmployeeSalarySpan item);
        IBaseEntityResponse<EmployeeSalarySpan> SelectByID(EmployeeSalarySpan item);
        IBaseEntityResponse<EmployeeSalarySpan> UpdateEmployeeSalarySpan(EmployeeSalarySpan item);
        IBaseEntityCollectionResponse<EmployeeSalarySpan> GetSalarySpanList(EmployeeSalarySpanSearchRequest searchRequest);

    }
}
