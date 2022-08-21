using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractWiseComplianceReportViewModel
    {

        public SaleContractWiseComplianceReportViewModel()
        {
            SaleContractWiseComplianceReport = new SaleContractWiseComplianceReport();
            SaleContractWiseComplianceReportList = new List<SaleContractWiseComplianceReport>();
            SaleContractWiseComplianceReportDetailListForparticulars = new List<SaleContractWiseComplianceReport>();
            SaleContractWiseComplianceReportDTO = new SaleContractWiseComplianceReport();
            SaleContractSpanList = new List<SaleContractAttendance>();
        }
        public SaleContractWiseComplianceReport SaleContractWiseComplianceReportDTO
        { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }

        public List<SaleContractWiseComplianceReport> SaleContractWiseComplianceReportList { get; set; }
        public List<SaleContractWiseComplianceReport> SaleContractWiseComplianceReportDetailListForparticulars { get; set; }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractSpanList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public SaleContractWiseComplianceReport SaleContractWiseComplianceReport
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractWiseComplianceReport != null && SaleContractWiseComplianceReport.ID > 0) ? SaleContractWiseComplianceReport.ID : new Int64();
            }
            set
            {
                SaleContractWiseComplianceReport.ID = value;
            }
        }

        public bool IsPosted { get; set; }
        public string CentreCode
        {
            get;
            set;
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractWiseComplianceReport != null) ? SaleContractWiseComplianceReport.IsDeleted : false;
            }
            set
            {
                SaleContractWiseComplianceReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractWiseComplianceReport != null && SaleContractWiseComplianceReport.CreatedBy > 0) ? SaleContractWiseComplianceReport.CreatedBy : new int();
            }
            set
            {
                SaleContractWiseComplianceReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractWiseComplianceReport != null) ? SaleContractWiseComplianceReport.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractWiseComplianceReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractWiseComplianceReport != null && SaleContractWiseComplianceReport.ModifiedBy > 0) ? SaleContractWiseComplianceReport.ModifiedBy : new int();
            }
            set
            {
                SaleContractWiseComplianceReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractWiseComplianceReport != null && SaleContractWiseComplianceReport.ModifiedDate.HasValue) ? SaleContractWiseComplianceReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractWiseComplianceReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractWiseComplianceReport != null && SaleContractWiseComplianceReport.DeletedBy > 0) ? SaleContractWiseComplianceReport.DeletedBy : new int();
            }
            set
            {
                SaleContractWiseComplianceReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractWiseComplianceReport != null && SaleContractWiseComplianceReport.DeletedDate.HasValue) ? SaleContractWiseComplianceReport.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractWiseComplianceReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractWiseComplianceReportDTO != null && SaleContractWiseComplianceReportDTO.SaleContractMasterID > 0) ? SaleContractWiseComplianceReportDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractWiseComplianceReportDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractWiseComplianceReportDTO != null) ? SaleContractWiseComplianceReportDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractWiseComplianceReportDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractWiseComplianceReportDTO != null) ? SaleContractWiseComplianceReportDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractWiseComplianceReportDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractWiseComplianceReportDTO != null) ? SaleContractWiseComplianceReportDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractWiseComplianceReportDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Salary Month")]
        public string SalaryMonth
        {
            get
            {
                return (SaleContractWiseComplianceReportDTO != null) ? SaleContractWiseComplianceReportDTO.SalaryMonth : string.Empty;
            }
            set
            {
                SaleContractWiseComplianceReportDTO.SalaryMonth = value;
            }
        }
        [Display(Name = "Salary Year")]
        public string SalaryYear
        {
            get
            {
                return (SaleContractWiseComplianceReportDTO != null) ? SaleContractWiseComplianceReportDTO.SalaryYear : string.Empty;
            }
            set
            {
                SaleContractWiseComplianceReportDTO.SalaryYear = value;
            }
        }
        [Display(Name = "Report Type")]
        public string ReportType
        {
            get
            {
                return (SaleContractWiseComplianceReportDTO != null) ? SaleContractWiseComplianceReportDTO.ReportType : string.Empty;
            }
            set
            {
                SaleContractWiseComplianceReportDTO.ReportType = value;
            }
        }
        [Display(Name = "Salary Month")]
        public string SalaryMonthDisplay
        {
            get
            {
                return (SaleContractWiseComplianceReportDTO != null) ? SaleContractWiseComplianceReportDTO.SalaryMonthDisplay : string.Empty;
            }
            set
            {
                SaleContractWiseComplianceReportDTO.SalaryMonthDisplay = value;
            }
        }
        
    }
}

