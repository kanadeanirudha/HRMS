using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GrossOperatingProfitReportViewModel
    {

        public GrossOperatingProfitReportViewModel()
        {
            GrossOperatingProfitReport = new GrossOperatingProfitReport();
            GrossOperatingProfitReportList = new List<GrossOperatingProfitReport>();
            GrossOperatingProfitReportDetailListForparticulars = new List<GrossOperatingProfitReport>();
            GrossOperatingProfitReportDTO = new GrossOperatingProfitReport();
            SaleContractSpanList = new List<SaleContractAttendance>();
        }
        public GrossOperatingProfitReport GrossOperatingProfitReportDTO
        { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }

        public List<GrossOperatingProfitReport> GrossOperatingProfitReportList { get; set; }
        public List<GrossOperatingProfitReport> GrossOperatingProfitReportDetailListForparticulars { get; set; }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractSpanList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public GrossOperatingProfitReport GrossOperatingProfitReport
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (GrossOperatingProfitReport != null && GrossOperatingProfitReport.ID > 0) ? GrossOperatingProfitReport.ID : new Int64();
            }
            set
            {
                GrossOperatingProfitReport.ID = value;
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
                return (GrossOperatingProfitReport != null) ? GrossOperatingProfitReport.IsDeleted : false;
            }
            set
            {
                GrossOperatingProfitReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (GrossOperatingProfitReport != null && GrossOperatingProfitReport.CreatedBy > 0) ? GrossOperatingProfitReport.CreatedBy : new int();
            }
            set
            {
                GrossOperatingProfitReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (GrossOperatingProfitReport != null) ? GrossOperatingProfitReport.CreatedDate : DateTime.Now;
            }
            set
            {
                GrossOperatingProfitReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (GrossOperatingProfitReport != null && GrossOperatingProfitReport.ModifiedBy > 0) ? GrossOperatingProfitReport.ModifiedBy : new int();
            }
            set
            {
                GrossOperatingProfitReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GrossOperatingProfitReport != null && GrossOperatingProfitReport.ModifiedDate.HasValue) ? GrossOperatingProfitReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                GrossOperatingProfitReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (GrossOperatingProfitReport != null && GrossOperatingProfitReport.DeletedBy > 0) ? GrossOperatingProfitReport.DeletedBy : new int();
            }
            set
            {
                GrossOperatingProfitReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GrossOperatingProfitReport != null && GrossOperatingProfitReport.DeletedDate.HasValue) ? GrossOperatingProfitReport.DeletedDate : DateTime.Now;
            }
            set
            {
                GrossOperatingProfitReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
        public Int64 SaleContractMasterID
        {
            get
            {
                return (GrossOperatingProfitReportDTO != null && GrossOperatingProfitReportDTO.SaleContractMasterID > 0) ? GrossOperatingProfitReportDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                GrossOperatingProfitReportDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (GrossOperatingProfitReportDTO != null) ? GrossOperatingProfitReportDTO.ContractNumber : string.Empty;
            }
            set
            {
                GrossOperatingProfitReportDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (GrossOperatingProfitReportDTO != null) ? GrossOperatingProfitReportDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                GrossOperatingProfitReportDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (GrossOperatingProfitReportDTO != null) ? GrossOperatingProfitReportDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                GrossOperatingProfitReportDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerMasterName
        {
            get
            {
                return (GrossOperatingProfitReportDTO != null) ? GrossOperatingProfitReportDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                GrossOperatingProfitReportDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (GrossOperatingProfitReportDTO != null) ? GrossOperatingProfitReportDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                GrossOperatingProfitReportDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Customer Name")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (GrossOperatingProfitReportDTO != null) ? GrossOperatingProfitReportDTO.CustomerMasterID : new Int32();
            }
            set
            {
                GrossOperatingProfitReportDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Customer Type")]
        public byte CustomerType
        {
            get
            {
                return (GrossOperatingProfitReportDTO != null) ? GrossOperatingProfitReportDTO.CustomerType : new byte();
            }
            set
            {
                GrossOperatingProfitReportDTO.CustomerType = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (GrossOperatingProfitReportDTO != null) ? GrossOperatingProfitReportDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                GrossOperatingProfitReportDTO.CustomerBranchMasterID = value;
            }
        }
    }
}

