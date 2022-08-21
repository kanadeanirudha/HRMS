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
    public class SaleSummaryDrillReportViewModel
    {
        public SaleSummaryDrillReportViewModel()
        {
            SaleSummaryDrillReportDTO = new SaleSummaryDrillReport();
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
        public SaleSummaryDrillReport SaleSummaryDrillReportDTO { get; set; }


        [Display(Name = "From Date")]
        public string DateFrom
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.DateFrom : string.Empty;
            }
            set
            {
                SaleSummaryDrillReportDTO.DateFrom = value;
            }
        }

        [Display(Name = "To Date")]
        public string DateTo
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.DateTo : string.Empty;
            }
            set
            {
                SaleSummaryDrillReportDTO.DateTo = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.CentreCode : string.Empty;
            }
            set
            {
                SaleSummaryDrillReportDTO.CentreCode = value;
            }
        }
        [Display(Name = "Centre")]
        public string CentreName
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.CentreName : string.Empty;
            }
            set
            {
                SaleSummaryDrillReportDTO.CentreName = value;
            }
        }
        public bool IsPosted { get; set; }


        public decimal TotalCard
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.TotalCard : new decimal();
            }
            set
            {
                SaleSummaryDrillReportDTO.TotalCard = value;
            }
        }
        public decimal TotalCash
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.TotalCash : new decimal();
            }
            set
            {
                SaleSummaryDrillReportDTO.TotalCash = value;
            }
        }

        public decimal TotalSale
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.TotalSale : new decimal();
            }
            set
            {
                SaleSummaryDrillReportDTO.TotalSale = value;
            }
        }
        public string BillNumber
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.CentreCode : string.Empty;
            }
            set
            {
                SaleSummaryDrillReportDTO.CentreCode = value;
            }
        }

        public decimal DiscountAmount
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.DiscountAmount : new decimal();
            }
            set
            {
                SaleSummaryDrillReportDTO.DiscountAmount = value;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return (SaleSummaryDrillReportDTO != null) ? SaleSummaryDrillReportDTO.TotalPrice : new decimal();
            }
            set
            {
                SaleSummaryDrillReportDTO.TotalPrice = value;
            }
        }
    }

}

