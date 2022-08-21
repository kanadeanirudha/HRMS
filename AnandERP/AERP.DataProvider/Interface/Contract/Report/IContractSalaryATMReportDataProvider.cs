﻿using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IContractSalaryATMReportDataProvider
    {
        IBaseEntityCollectionResponse<ContractSalaryATMReport> GetContractSalaryATMReportDataList(ContractSalaryATMReportSearchRequest searchRequest);
        IBaseEntityResponse<ContractSalaryATMReport> InsertContractSalaryATMReport(ContractSalaryATMReport item);
    }
}
