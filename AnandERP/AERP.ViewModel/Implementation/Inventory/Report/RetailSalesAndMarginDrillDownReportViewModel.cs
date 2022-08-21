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
    public class RetailSalesAndMarginDrillDownReportViewModel
    {
        public RetailSalesAndMarginDrillDownReportViewModel()
        {
            RetailSalesAndMarginDrillDownReportDTO = new RetailSalesAndMarginDrillDownReport();
            ListGeneralUnits = new List<GeneralUnits>(); 
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public List<GeneralUnits> ListGeneralUnits
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        {
            get
            {
                return new SelectList(ListGeneralUnits, "ID", "UnitName");
            }
        }
       
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public RetailSalesAndMarginDrillDownReport RetailSalesAndMarginDrillDownReportDTO { get; set; }

      
        [Display(Name = "From Date")]
        public string DateFrom
        {
            get
            {
                return (RetailSalesAndMarginDrillDownReportDTO != null) ? RetailSalesAndMarginDrillDownReportDTO.DateFrom : string.Empty;
            }
            set
            {
                RetailSalesAndMarginDrillDownReportDTO.DateFrom = value;
            }
        }
        public string GeneralUnitsName
        {
            get
            {
                return (RetailSalesAndMarginDrillDownReportDTO != null) ? RetailSalesAndMarginDrillDownReportDTO.GeneralUnitsName : string.Empty;
            }
            set
            {
                RetailSalesAndMarginDrillDownReportDTO.GeneralUnitsName = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (RetailSalesAndMarginDrillDownReportDTO != null) ? RetailSalesAndMarginDrillDownReportDTO.CentreName : string.Empty;
            }
            set
            {
                RetailSalesAndMarginDrillDownReportDTO.CentreName = value;
            }
        }
        public string GranularityName
        {
            get
            {
                return (RetailSalesAndMarginDrillDownReportDTO != null) ? RetailSalesAndMarginDrillDownReportDTO.GranularityName : string.Empty;
            }
            set
            {
                RetailSalesAndMarginDrillDownReportDTO.GranularityName = value;
            }
        }
        [Display(Name = "To Date")]
        public string DateTo
        {
            get
            {
                return (RetailSalesAndMarginDrillDownReportDTO != null) ? RetailSalesAndMarginDrillDownReportDTO.DateTo : string.Empty;
            }
            set
            {
                RetailSalesAndMarginDrillDownReportDTO.DateTo = value;
            }
        }

        [Display(Name = "Granularity")]
        public string Granularity
        {
            get
            {
                return (RetailSalesAndMarginDrillDownReportDTO != null) ? RetailSalesAndMarginDrillDownReportDTO.Granularity : string.Empty;
            }
            set
            {
                RetailSalesAndMarginDrillDownReportDTO.Granularity = value;
            }
        }

        [Display(Name = "Site")]
        public Int32 GeneralUnitsID
        {
            get
            {
                return (RetailSalesAndMarginDrillDownReportDTO != null && RetailSalesAndMarginDrillDownReportDTO.GeneralUnitsID > 0) ? RetailSalesAndMarginDrillDownReportDTO.GeneralUnitsID : new Int32();
            }
            set
            {
                RetailSalesAndMarginDrillDownReportDTO.GeneralUnitsID = value;
            }
        }
       
        public int SRNo
        {
            get
            {
                return (RetailSalesAndMarginDrillDownReportDTO != null) ? RetailSalesAndMarginDrillDownReportDTO.SRNo : new int();
            }
            set
            {
                RetailSalesAndMarginDrillDownReportDTO.SRNo = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (RetailSalesAndMarginDrillDownReportDTO != null) ? RetailSalesAndMarginDrillDownReportDTO.CentreCode : string.Empty;
            }
            set
            {
                RetailSalesAndMarginDrillDownReportDTO.CentreCode = value;
            }
        }
       
        public bool IsPosted { get; set; }
    }
    
}

