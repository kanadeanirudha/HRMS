﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IArticlesAvailabilityReportDataProvider
    {
        IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportBySociety(ArticlesAvailabilityReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByCentre(ArticlesAvailabilityReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByStore(ArticlesAvailabilityReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByVendor(ArticlesAvailabilityReportSearchRequest searchRequest);
    }
}
