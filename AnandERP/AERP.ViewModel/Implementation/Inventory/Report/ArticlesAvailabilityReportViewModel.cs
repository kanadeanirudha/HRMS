using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class ArticlesAvailabilityReportViewModel
    {
        public ArticlesAvailabilityReportViewModel()
        {
            ArticlesAvailabilityReportDTO = new ArticlesAvailabilityReport();
            ListArticlesAvailabilityReport = new List<ArticlesAvailabilityReport>();
        }


        public List<ArticlesAvailabilityReport> ListArticlesAvailabilityReport { get; set; }
        public List<ArticlesAvailabilityReport> GetGeneralUnitsForItemmaster { get; set; }
        public ArticlesAvailabilityReport ArticlesAvailabilityReportDTO { get; set; }

       
        public bool IsPosted
        {
            get
            {
                return (ArticlesAvailabilityReportDTO != null) ? ArticlesAvailabilityReportDTO.IsPosted : false;
            }
            set
            {
                ArticlesAvailabilityReportDTO.IsPosted = value;
            }
        }
     
      [Display (Name = "From Date")]
        public string DateFrom
        {
            get
            {
                return (ArticlesAvailabilityReportDTO != null) ? ArticlesAvailabilityReportDTO.DateFrom : string.Empty;
            }
            set
            {
                ArticlesAvailabilityReportDTO.DateFrom = value;
            }
        }
          [Display(Name = "To Date")]
        public string DateTo
        {
            get
            {
                return (ArticlesAvailabilityReportDTO != null) ? ArticlesAvailabilityReportDTO.DateTo : string.Empty;
            }
            set
            {
                ArticlesAvailabilityReportDTO.DateTo = value;
            }
        }
    }
}

