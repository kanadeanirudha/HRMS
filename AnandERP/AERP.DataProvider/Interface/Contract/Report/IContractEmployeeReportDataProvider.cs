using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IContractEmployeeReportDataProvider
    {
        IBaseEntityCollectionResponse<ContractEmployeeReport> GetContractEmployeeReportDataList(ContractEmployeeReportSearchRequest searchRequest);
        IBaseEntityResponse<ContractEmployeeReport> InsertContractEmployeeReport(ContractEmployeeReport item);
        IBaseEntityCollectionResponse<ContractEmployeeReport> GetContractEmployeeWorkDetailsReportDataList(ContractEmployeeReportSearchRequest searchRequest);
    }
}
