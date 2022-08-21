using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractWisePNLReportViewModel
    {

        public SaleContractWisePNLReportViewModel()
        {
            SaleContractWisePNLReport = new SaleContractWisePNLReport();
            SaleContractWisePNLReportList = new List<SaleContractWisePNLReport>();
            SaleContractWisePNLReportDetailListForparticulars = new List<SaleContractWisePNLReport>();
            SaleContractWisePNLReportDTO = new SaleContractWisePNLReport();
            SaleContractSpanList = new List<SaleContractAttendance>();
        }
        public SaleContractWisePNLReport SaleContractWisePNLReportDTO
        { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }

        public List<SaleContractWisePNLReport> SaleContractWisePNLReportList { get; set; }
        public List<SaleContractWisePNLReport> SaleContractWisePNLReportDetailListForparticulars { get; set; }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractSpanList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public SaleContractWisePNLReport SaleContractWisePNLReport
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractWisePNLReport != null && SaleContractWisePNLReport.ID > 0) ? SaleContractWisePNLReport.ID : new Int64();
            }
            set
            {
                SaleContractWisePNLReport.ID = value;
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
                return (SaleContractWisePNLReport != null) ? SaleContractWisePNLReport.IsDeleted : false;
            }
            set
            {
                SaleContractWisePNLReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractWisePNLReport != null && SaleContractWisePNLReport.CreatedBy > 0) ? SaleContractWisePNLReport.CreatedBy : new int();
            }
            set
            {
                SaleContractWisePNLReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractWisePNLReport != null) ? SaleContractWisePNLReport.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractWisePNLReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractWisePNLReport != null && SaleContractWisePNLReport.ModifiedBy > 0) ? SaleContractWisePNLReport.ModifiedBy : new int();
            }
            set
            {
                SaleContractWisePNLReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractWisePNLReport != null && SaleContractWisePNLReport.ModifiedDate.HasValue) ? SaleContractWisePNLReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractWisePNLReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractWisePNLReport != null && SaleContractWisePNLReport.DeletedBy > 0) ? SaleContractWisePNLReport.DeletedBy : new int();
            }
            set
            {
                SaleContractWisePNLReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractWisePNLReport != null && SaleContractWisePNLReport.DeletedDate.HasValue) ? SaleContractWisePNLReport.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractWisePNLReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractWisePNLReportDTO != null && SaleContractWisePNLReportDTO.SaleContractMasterID > 0) ? SaleContractWisePNLReportDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractWisePNLReportDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractWisePNLReportDTO != null) ? SaleContractWisePNLReportDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractWisePNLReportDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractWisePNLReportDTO != null) ? SaleContractWisePNLReportDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractWisePNLReportDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractWisePNLReportDTO != null) ? SaleContractWisePNLReportDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractWisePNLReportDTO.SaleContractBillingSpanName = value;
            }
        }
    }
}

