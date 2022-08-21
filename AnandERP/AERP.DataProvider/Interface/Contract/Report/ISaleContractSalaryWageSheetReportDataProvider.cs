using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractSalaryWageSheetReportDataProvider
    {
        IBaseEntityCollectionResponse<SaleContractSalaryWageSheetReport> GetSaleContractSalaryWageSheetReportDataList(SaleContractSalaryWageSheetReportSearchRequest searchRequest);

    }
}
