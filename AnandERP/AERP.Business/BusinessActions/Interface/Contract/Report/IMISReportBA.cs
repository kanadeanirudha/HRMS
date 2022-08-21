﻿using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IMISReportBA
    {
        IBaseEntityCollectionResponse<MISReport> GetMISReportDataList(MISReportSearchRequest searchRequest);

    }
}
