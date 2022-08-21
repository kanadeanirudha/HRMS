using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractSalaryWageSheetReportViewModel
    {

        public SaleContractSalaryWageSheetReportViewModel()
        {
            SaleContractSalaryWageSheetReport = new SaleContractSalaryWageSheetReport();
            SaleContractSalaryWageSheetReportList = new List<SaleContractSalaryWageSheetReport>();
            SaleContractSalaryWageSheetReportDetailListForparticulars = new List<SaleContractSalaryWageSheetReport>();
            SaleContractSalaryWageSheetReportDTO = new SaleContractSalaryWageSheetReport();
            SaleContractSpanList = new List<SaleContractAttendance>();
        }
        public SaleContractSalaryWageSheetReport SaleContractSalaryWageSheetReportDTO
        { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }

        public List<SaleContractSalaryWageSheetReport> SaleContractSalaryWageSheetReportList { get; set; }
        public List<SaleContractSalaryWageSheetReport> SaleContractSalaryWageSheetReportDetailListForparticulars { get; set; }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractSpanList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public SaleContractSalaryWageSheetReport SaleContractSalaryWageSheetReport
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractSalaryWageSheetReport != null && SaleContractSalaryWageSheetReport.ID > 0) ? SaleContractSalaryWageSheetReport.ID : new Int64();
            }
            set
            {
                SaleContractSalaryWageSheetReport.ID = value;
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
                return (SaleContractSalaryWageSheetReport != null) ? SaleContractSalaryWageSheetReport.IsDeleted : false;
            }
            set
            {
                SaleContractSalaryWageSheetReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractSalaryWageSheetReport != null && SaleContractSalaryWageSheetReport.CreatedBy > 0) ? SaleContractSalaryWageSheetReport.CreatedBy : new int();
            }
            set
            {
                SaleContractSalaryWageSheetReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractSalaryWageSheetReport != null) ? SaleContractSalaryWageSheetReport.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractSalaryWageSheetReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractSalaryWageSheetReport != null && SaleContractSalaryWageSheetReport.ModifiedBy > 0) ? SaleContractSalaryWageSheetReport.ModifiedBy : new int();
            }
            set
            {
                SaleContractSalaryWageSheetReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractSalaryWageSheetReport != null && SaleContractSalaryWageSheetReport.ModifiedDate.HasValue) ? SaleContractSalaryWageSheetReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractSalaryWageSheetReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractSalaryWageSheetReport != null && SaleContractSalaryWageSheetReport.DeletedBy > 0) ? SaleContractSalaryWageSheetReport.DeletedBy : new int();
            }
            set
            {
                SaleContractSalaryWageSheetReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractSalaryWageSheetReport != null && SaleContractSalaryWageSheetReport.DeletedDate.HasValue) ? SaleContractSalaryWageSheetReport.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractSalaryWageSheetReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractSalaryWageSheetReportDTO != null && SaleContractSalaryWageSheetReportDTO.SaleContractMasterID > 0) ? SaleContractSalaryWageSheetReportDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractSalaryWageSheetReportDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractSalaryWageSheetReportDTO != null) ? SaleContractSalaryWageSheetReportDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractSalaryWageSheetReportDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractSalaryWageSheetReportDTO != null) ? SaleContractSalaryWageSheetReportDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractSalaryWageSheetReportDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractSalaryWageSheetReportDTO != null) ? SaleContractSalaryWageSheetReportDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractSalaryWageSheetReportDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Report Type")]
        public byte ReportType
        {
            get
            {
                return (SaleContractSalaryWageSheetReportDTO != null) ? SaleContractSalaryWageSheetReportDTO.ReportType : new byte();
            }
            set
            {
                SaleContractSalaryWageSheetReportDTO.ReportType = value;
            }
        }
        
    }
}

