using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IEnterpriseDrillThroughReportBA
    {
        IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> GetEnterpriseDrillThroughReportBySearch_Centre(EnterpriseDrillThroughReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> GetEnterpriseDrillThroughReportBySearch_Employee(EnterpriseDrillThroughReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> GetEnterpriseDrillThroughReportBySearch_Department(EnterpriseDrillThroughReportSearchRequest searchRequest);
    }
}
