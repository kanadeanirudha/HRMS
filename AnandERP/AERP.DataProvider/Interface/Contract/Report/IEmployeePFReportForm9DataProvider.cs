﻿using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeePFReportForm9DataProvider
    {
        IBaseEntityCollectionResponse<EmployeePFReportForm9> GetEmployeePFReportForm9DataList(EmployeePFReportForm9SearchRequest searchRequest);

    }
}
