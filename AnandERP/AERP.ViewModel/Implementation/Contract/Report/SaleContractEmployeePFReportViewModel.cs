using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc; 

namespace AERP.ViewModel
{
    public class SaleContractEmployeePFReportViewModel : ISaleContractEmployeePFReportViewModel
    {

        public SaleContractEmployeePFReportViewModel()
        {
            SaleContractEmployeePFReportDTO = new SaleContractEmployeePFReport();
            SaleContractSpanList = new List<SaleContractAttendance>();
            SaleContractEmployeePFReportList = new List<SaleContractEmployeePFReport>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListAccountSessionMasterReport = new List<AccountSessionMaster>();
        }
        public List<AccountSessionMaster> ListAccountSessionMasterReport { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }
        public List<SaleContractEmployeePFReport> SaleContractEmployeePFReportList { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> AccountSessionMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountSessionMasterReport, "ID", "SessionName");
            }
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractSpanList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public SaleContractEmployeePFReport SaleContractEmployeePFReportDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null && SaleContractEmployeePFReportDTO.ID > 0) ? SaleContractEmployeePFReportDTO.ID : new Int64();
            }
            set
            {
                SaleContractEmployeePFReportDTO.ID = value;
            }
        }
        [Display (Name ="From Date")]
        public string FromDate
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null) ? SaleContractEmployeePFReportDTO.FromDate : string.Empty;
            }
            set
            {
                SaleContractEmployeePFReportDTO.FromDate = value;
            }
        }
        [Display(Name ="Upto Date")]
        public string UptoDate
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null) ? SaleContractEmployeePFReportDTO.UptoDate : string.Empty;
            }
            set
            {
                SaleContractEmployeePFReportDTO.UptoDate = value;
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
                return (SaleContractEmployeePFReportDTO != null) ? SaleContractEmployeePFReportDTO.IsDeleted : false;
            }
            set
            {
                SaleContractEmployeePFReportDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null && SaleContractEmployeePFReportDTO.CreatedBy > 0) ? SaleContractEmployeePFReportDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractEmployeePFReportDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null) ? SaleContractEmployeePFReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractEmployeePFReportDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null && SaleContractEmployeePFReportDTO.ModifiedBy > 0) ? SaleContractEmployeePFReportDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractEmployeePFReportDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null && SaleContractEmployeePFReportDTO.ModifiedDate.HasValue) ? SaleContractEmployeePFReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractEmployeePFReportDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null && SaleContractEmployeePFReportDTO.DeletedBy > 0) ? SaleContractEmployeePFReportDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractEmployeePFReportDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null && SaleContractEmployeePFReportDTO.DeletedDate.HasValue) ? SaleContractEmployeePFReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractEmployeePFReportDTO.DeletedDate = value;
            }
        }
        [Display(Name = "Employee Name")]
        public Int32 SaleContractEmployeeMasterID
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null && SaleContractEmployeePFReportDTO.SaleContractEmployeeMasterID > 0) ? SaleContractEmployeePFReportDTO.SaleContractEmployeeMasterID : new Int32();
            }
            set
            {
                SaleContractEmployeePFReportDTO.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null) ? SaleContractEmployeePFReportDTO.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                SaleContractEmployeePFReportDTO.SaleContractEmployeeMasterName = value;
            }
        }

        [Display(Name = "Account Session")]
        public int AccountSessionID
        {
            get
            {
                return (SaleContractEmployeePFReportDTO != null && SaleContractEmployeePFReportDTO.AccountSessionID > 0) ? SaleContractEmployeePFReportDTO.AccountSessionID : new int();
            }
            set
            {
                SaleContractEmployeePFReportDTO.AccountSessionID = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

