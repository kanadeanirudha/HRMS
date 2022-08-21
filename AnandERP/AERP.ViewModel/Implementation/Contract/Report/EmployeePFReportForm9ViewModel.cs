using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeePFReportForm9ViewModel
    {

        public EmployeePFReportForm9ViewModel()
        {
            EmployeePFReportForm9 = new EmployeePFReportForm9();
            EmployeePFReportForm9List = new List<EmployeePFReportForm9>();
        }
        public List<EmployeePFReportForm9> EmployeePFReportForm9List { get; set; }

        public EmployeePFReportForm9 EmployeePFReportForm9
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (EmployeePFReportForm9 != null && EmployeePFReportForm9.ID > 0) ? EmployeePFReportForm9.ID : new Int64();
            }
            set
            {
                EmployeePFReportForm9.ID = value;
            }
        }
        [Display(Name = "From Date")]
        public string FromDate
        {
            get
            {
                return (EmployeePFReportForm9 != null) ? EmployeePFReportForm9.FromDate : string.Empty;
            }
            set
            {
                EmployeePFReportForm9.FromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string UptoDate
        {
            get
            {
                return (EmployeePFReportForm9 != null) ? EmployeePFReportForm9.UptoDate : string.Empty;
            }
            set
            {
                EmployeePFReportForm9.UptoDate = value;
            }
        }
        [Display(Name = "Month")]
        public string MonthName
        {
            get
            {
                return (EmployeePFReportForm9 != null) ? EmployeePFReportForm9.MonthName : string.Empty;
            }
            set
            {
                EmployeePFReportForm9.MonthName = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (EmployeePFReportForm9 != null) ? EmployeePFReportForm9.MonthYear : string.Empty;
            }
            set
            {
                EmployeePFReportForm9.MonthYear = value;
            }
        }
        [Display(Name = "Month")]
        public string MonthFullName
        {
            get
            {
                return (EmployeePFReportForm9 != null) ? EmployeePFReportForm9.MonthFullName : string.Empty;
            }
            set
            {
                EmployeePFReportForm9.MonthFullName = value;
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
                return (EmployeePFReportForm9 != null) ? EmployeePFReportForm9.IsDeleted : false;
            }
            set
            {
                EmployeePFReportForm9.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeePFReportForm9 != null && EmployeePFReportForm9.CreatedBy > 0) ? EmployeePFReportForm9.CreatedBy : new int();
            }
            set
            {
                EmployeePFReportForm9.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeePFReportForm9 != null) ? EmployeePFReportForm9.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeePFReportForm9.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeePFReportForm9 != null && EmployeePFReportForm9.ModifiedBy > 0) ? EmployeePFReportForm9.ModifiedBy : new int();
            }
            set
            {
                EmployeePFReportForm9.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeePFReportForm9 != null && EmployeePFReportForm9.ModifiedDate.HasValue) ? EmployeePFReportForm9.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeePFReportForm9.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeePFReportForm9 != null && EmployeePFReportForm9.DeletedBy > 0) ? EmployeePFReportForm9.DeletedBy : new int();
            }
            set
            {
                EmployeePFReportForm9.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeePFReportForm9 != null && EmployeePFReportForm9.DeletedDate.HasValue) ? EmployeePFReportForm9.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeePFReportForm9.DeletedDate = value;
            }
        }
        [Display(Name = "Employee Name")]
        public Int32 SaleContractEmployeeMasterID
        {
            get
            {
                return (EmployeePFReportForm9 != null && EmployeePFReportForm9.SaleContractEmployeeMasterID > 0) ? EmployeePFReportForm9.SaleContractEmployeeMasterID : new Int32();
            }
            set
            {
                EmployeePFReportForm9.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (EmployeePFReportForm9 != null) ? EmployeePFReportForm9.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                EmployeePFReportForm9.SaleContractEmployeeMasterName = value;
            }
        }

        [Display(Name = "Account Session")]
        public int AccountSessionID
        {
            get
            {
                return (EmployeePFReportForm9 != null && EmployeePFReportForm9.AccountSessionID > 0) ? EmployeePFReportForm9.AccountSessionID : new int();
            }
            set
            {
                EmployeePFReportForm9.AccountSessionID = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

