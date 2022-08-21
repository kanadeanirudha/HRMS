using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EnterpriseDrillThroughReportViewModel
    {
        public EnterpriseDrillThroughReportViewModel()
        {
            EnterpriseDrillThroughReportDTO = new EnterpriseDrillThroughReport();
            ListEnterpriseDrillThroughReport = new List<EnterpriseDrillThroughReport>();
        }


        public List<EnterpriseDrillThroughReport> ListEnterpriseDrillThroughReport { get; set; }

        public EnterpriseDrillThroughReport EnterpriseDrillThroughReportDTO { get; set; }
    }
}
