using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeePFReportForm10DataProvider
    {
        IBaseEntityCollectionResponse<EmployeePFReportForm10> GetEmployeePFReportForm10DataList(EmployeePFReportForm10SearchRequest searchRequest);

    }
}
