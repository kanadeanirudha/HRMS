using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IEmployeePFReportForm12ABA
    {
        IBaseEntityCollectionResponse<EmployeePFReportForm12A> GetEmployeePFReportForm12ADataList(EmployeePFReportForm12ASearchRequest searchRequest);

    }
}
