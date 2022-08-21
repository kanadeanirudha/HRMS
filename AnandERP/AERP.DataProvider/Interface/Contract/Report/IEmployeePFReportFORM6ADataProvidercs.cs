using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeePFReportFORM6ADataProvider
    {
        IBaseEntityCollectionResponse<EmployeePFReportFORM6A> GetEmployeePFReportFORM6ADataList(EmployeePFReportFORM6ASearchRequest searchRequest);
        
    }
}
