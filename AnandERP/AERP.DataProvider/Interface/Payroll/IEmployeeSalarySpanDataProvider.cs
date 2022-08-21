using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IEmployeeSalarySpanDataProvider
    {
        IBaseEntityCollectionResponse<EmployeeSalarySpan> GetEmployeeSalarySpanBySearch(EmployeeSalarySpanSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeSalarySpan> GetEmployeeSalarySpanByID(EmployeeSalarySpan item);
        IBaseEntityResponse<EmployeeSalarySpan> InsertEmployeeSalarySpan(EmployeeSalarySpan item);
        IBaseEntityResponse<EmployeeSalarySpan> UpdateEmployeeSalarySpan(EmployeeSalarySpan item);
        IBaseEntityCollectionResponse<EmployeeSalarySpan> GetSalarySpan(EmployeeSalarySpanSearchRequest searchRequest);

    }
}
