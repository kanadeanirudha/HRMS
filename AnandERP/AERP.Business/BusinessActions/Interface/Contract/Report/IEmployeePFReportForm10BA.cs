using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IEmployeePFReportForm10BA
    {
        IBaseEntityCollectionResponse<EmployeePFReportForm10> GetEmployeePFReportForm10DataList(EmployeePFReportForm10SearchRequest searchRequest);

    }
}
