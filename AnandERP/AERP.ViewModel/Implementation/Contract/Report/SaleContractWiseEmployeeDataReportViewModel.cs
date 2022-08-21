using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractWiseEmployeeDataReportViewModel
    {

        public SaleContractWiseEmployeeDataReportViewModel()
        {
            SaleContractWiseEmployeeDataReport = new SaleContractWiseEmployeeDataReport();
            SaleContractWiseEmployeeDataReportList = new List<SaleContractWiseEmployeeDataReport>();
            SaleContractWiseEmployeeDataReportDetailListForparticulars = new List<SaleContractWiseEmployeeDataReport>();
            SaleContractWiseEmployeeDataReportDTO = new SaleContractWiseEmployeeDataReport();
            SaleContractSpanList = new List<SaleContractAttendance>();
        }
        public SaleContractWiseEmployeeDataReport SaleContractWiseEmployeeDataReportDTO
        { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }

        public List<SaleContractWiseEmployeeDataReport> SaleContractWiseEmployeeDataReportList { get; set; }
        public List<SaleContractWiseEmployeeDataReport> SaleContractWiseEmployeeDataReportDetailListForparticulars { get; set; }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractSpanList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public SaleContractWiseEmployeeDataReport SaleContractWiseEmployeeDataReport
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractWiseEmployeeDataReport != null && SaleContractWiseEmployeeDataReport.ID > 0) ? SaleContractWiseEmployeeDataReport.ID : new Int64();
            }
            set
            {
                SaleContractWiseEmployeeDataReport.ID = value;
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
                return (SaleContractWiseEmployeeDataReport != null) ? SaleContractWiseEmployeeDataReport.IsDeleted : false;
            }
            set
            {
                SaleContractWiseEmployeeDataReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractWiseEmployeeDataReport != null && SaleContractWiseEmployeeDataReport.CreatedBy > 0) ? SaleContractWiseEmployeeDataReport.CreatedBy : new int();
            }
            set
            {
                SaleContractWiseEmployeeDataReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractWiseEmployeeDataReport != null) ? SaleContractWiseEmployeeDataReport.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractWiseEmployeeDataReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractWiseEmployeeDataReport != null && SaleContractWiseEmployeeDataReport.ModifiedBy > 0) ? SaleContractWiseEmployeeDataReport.ModifiedBy : new int();
            }
            set
            {
                SaleContractWiseEmployeeDataReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractWiseEmployeeDataReport != null && SaleContractWiseEmployeeDataReport.ModifiedDate.HasValue) ? SaleContractWiseEmployeeDataReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractWiseEmployeeDataReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractWiseEmployeeDataReport != null && SaleContractWiseEmployeeDataReport.DeletedBy > 0) ? SaleContractWiseEmployeeDataReport.DeletedBy : new int();
            }
            set
            {
                SaleContractWiseEmployeeDataReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractWiseEmployeeDataReport != null && SaleContractWiseEmployeeDataReport.DeletedDate.HasValue) ? SaleContractWiseEmployeeDataReport.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractWiseEmployeeDataReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractWiseEmployeeDataReportDTO != null && SaleContractWiseEmployeeDataReportDTO.SaleContractMasterID > 0) ? SaleContractWiseEmployeeDataReportDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractWiseEmployeeDataReportDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractWiseEmployeeDataReportDTO != null) ? SaleContractWiseEmployeeDataReportDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractWiseEmployeeDataReportDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractWiseEmployeeDataReportDTO != null) ? SaleContractWiseEmployeeDataReportDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractWiseEmployeeDataReportDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractWiseEmployeeDataReportDTO != null) ? SaleContractWiseEmployeeDataReportDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractWiseEmployeeDataReportDTO.SaleContractBillingSpanName = value;
            }
        }
    }
}

