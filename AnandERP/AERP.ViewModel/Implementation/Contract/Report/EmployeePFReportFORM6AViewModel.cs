using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeePFReportFORM6AViewModel
    {

        public EmployeePFReportFORM6AViewModel()
        {
            EmployeePFReportFORM6A = new EmployeePFReportFORM6A();
            SaleContractSpanList = new List<SaleContractAttendance>();
            EmployeePFReportFORM6AList = new List<EmployeePFReportFORM6A>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListAccountSessionMasterReport = new List<AccountSessionMaster>();
        }
        public List<AccountSessionMaster> ListAccountSessionMasterReport { get; set; }
        public List<SaleContractAttendance> SaleContractSpanList { get; set; }
        public List<EmployeePFReportFORM6A> EmployeePFReportFORM6AList { get; set; }
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

        public EmployeePFReportFORM6A EmployeePFReportFORM6A
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (EmployeePFReportFORM6A != null && EmployeePFReportFORM6A.ID > 0) ? EmployeePFReportFORM6A.ID : new Int64();
            }
            set
            {
                EmployeePFReportFORM6A.ID = value;
            }
        }
       [Display (Name ="From Date")]
        public string FromDate
        {
            get
            {
                return (EmployeePFReportFORM6A != null) ? EmployeePFReportFORM6A.FromDate : string.Empty;
            }
            set
            {
                EmployeePFReportFORM6A.FromDate = value;
            }
        }
        [Display (Name ="Upto Date")]
        public string UptoDate
        {
            get
            {
                return (EmployeePFReportFORM6A != null) ? EmployeePFReportFORM6A.UptoDate : string.Empty;
            }
            set
            {
                EmployeePFReportFORM6A.UptoDate = value;
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
                return (EmployeePFReportFORM6A != null) ? EmployeePFReportFORM6A.IsDeleted : false;
            }
            set
            {
                EmployeePFReportFORM6A.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeePFReportFORM6A != null && EmployeePFReportFORM6A.CreatedBy > 0) ? EmployeePFReportFORM6A.CreatedBy : new int();
            }
            set
            {
                EmployeePFReportFORM6A.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeePFReportFORM6A != null) ? EmployeePFReportFORM6A.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeePFReportFORM6A.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeePFReportFORM6A != null && EmployeePFReportFORM6A.ModifiedBy > 0) ? EmployeePFReportFORM6A.ModifiedBy : new int();
            }
            set
            {
                EmployeePFReportFORM6A.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeePFReportFORM6A != null && EmployeePFReportFORM6A.ModifiedDate.HasValue) ? EmployeePFReportFORM6A.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeePFReportFORM6A.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeePFReportFORM6A != null && EmployeePFReportFORM6A.DeletedBy > 0) ? EmployeePFReportFORM6A.DeletedBy : new int();
            }
            set
            {
                EmployeePFReportFORM6A.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeePFReportFORM6A != null && EmployeePFReportFORM6A.DeletedDate.HasValue) ? EmployeePFReportFORM6A.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeePFReportFORM6A.DeletedDate = value;
            }
        }
        [Display(Name = "Employee Name")]
        public Int32 SaleContractEmployeeMasterID
        {
            get
            {
                return (EmployeePFReportFORM6A != null && EmployeePFReportFORM6A.SaleContractEmployeeMasterID > 0) ? EmployeePFReportFORM6A.SaleContractEmployeeMasterID : new Int32();
            }
            set
            {
                EmployeePFReportFORM6A.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (EmployeePFReportFORM6A != null) ? EmployeePFReportFORM6A.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                EmployeePFReportFORM6A.SaleContractEmployeeMasterName = value;
            }
        }

        [Display(Name = "Account Session")]
        public int AccountSessionID
        {
            get
            {
                return (EmployeePFReportFORM6A != null && EmployeePFReportFORM6A.AccountSessionID > 0) ? EmployeePFReportFORM6A.AccountSessionID : new int();
            }
            set
            {
                EmployeePFReportFORM6A.AccountSessionID = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

