using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IEmployeePFReportFORM6ABA
    {
        IBaseEntityCollectionResponse<EmployeePFReportFORM6A> GetEmployeePFReportFORM6ADataList(EmployeePFReportFORM6ASearchRequest searchRequest);
        
    }
}
