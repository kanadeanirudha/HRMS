using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeePFReportForm10ViewModel
    {

        public EmployeePFReportForm10ViewModel()
        {
            EmployeePFReportForm10 = new EmployeePFReportForm10();
            EmployeePFReportForm10List = new List<EmployeePFReportForm10>();
        }
        public List<EmployeePFReportForm10> EmployeePFReportForm10List { get; set; }

        public EmployeePFReportForm10 EmployeePFReportForm10
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (EmployeePFReportForm10 != null && EmployeePFReportForm10.ID > 0) ? EmployeePFReportForm10.ID : new Int64();
            }
            set
            {
                EmployeePFReportForm10.ID = value;
            }
        }
        [Display(Name ="From Date")]
        public string FromDate
        {
            get
            {
                return (EmployeePFReportForm10 != null) ? EmployeePFReportForm10.FromDate : string.Empty;
            }
            set
            {
                EmployeePFReportForm10.FromDate = value;
            }
        }
        [Display(Name ="Upto Date")]
        public string UptoDate
        {
            get
            {
                return (EmployeePFReportForm10 != null) ? EmployeePFReportForm10.UptoDate : string.Empty;
            }
            set
            {
                EmployeePFReportForm10.UptoDate = value;
            }
        }
        [Display(Name = "Month")]
        public string MonthName
        {
            get
            {
                return (EmployeePFReportForm10 != null) ? EmployeePFReportForm10.MonthName : string.Empty;
            }
            set
            {
                EmployeePFReportForm10.MonthName = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (EmployeePFReportForm10 != null) ? EmployeePFReportForm10.MonthYear : string.Empty;
            }
            set
            {
                EmployeePFReportForm10.MonthYear = value;
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
                return (EmployeePFReportForm10 != null) ? EmployeePFReportForm10.IsDeleted : false;
            }
            set
            {
                EmployeePFReportForm10.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeePFReportForm10 != null && EmployeePFReportForm10.CreatedBy > 0) ? EmployeePFReportForm10.CreatedBy : new int();
            }
            set
            {
                EmployeePFReportForm10.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeePFReportForm10 != null) ? EmployeePFReportForm10.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeePFReportForm10.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeePFReportForm10 != null && EmployeePFReportForm10.ModifiedBy > 0) ? EmployeePFReportForm10.ModifiedBy : new int();
            }
            set
            {
                EmployeePFReportForm10.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeePFReportForm10 != null && EmployeePFReportForm10.ModifiedDate.HasValue) ? EmployeePFReportForm10.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeePFReportForm10.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeePFReportForm10 != null && EmployeePFReportForm10.DeletedBy > 0) ? EmployeePFReportForm10.DeletedBy : new int();
            }
            set
            {
                EmployeePFReportForm10.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeePFReportForm10 != null && EmployeePFReportForm10.DeletedDate.HasValue) ? EmployeePFReportForm10.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeePFReportForm10.DeletedDate = value;
            }
        }
        [Display(Name = "Employee Name")]
        public Int32 SaleContractEmployeeMasterID
        {
            get
            {
                return (EmployeePFReportForm10 != null && EmployeePFReportForm10.SaleContractEmployeeMasterID > 0) ? EmployeePFReportForm10.SaleContractEmployeeMasterID : new Int32();
            }
            set
            {
                EmployeePFReportForm10.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (EmployeePFReportForm10 != null) ? EmployeePFReportForm10.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                EmployeePFReportForm10.SaleContractEmployeeMasterName = value;
            }
        }

        [Display(Name = "Account Session")]
        public int AccountSessionID
        {
            get
            {
                return (EmployeePFReportForm10 != null && EmployeePFReportForm10.AccountSessionID > 0) ? EmployeePFReportForm10.AccountSessionID : new int();
            }
            set
            {
                EmployeePFReportForm10.AccountSessionID = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

