﻿using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractEmployeePFReportBA
    {
        IBaseEntityCollectionResponse<SaleContractEmployeePFReport> GetSaleContractEmployeePFReportDataList(SaleContractEmployeePFReportSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractEmployeePFReport> InsertSaleContractEmployeePFReport(SaleContractEmployeePFReport item);
    }
}