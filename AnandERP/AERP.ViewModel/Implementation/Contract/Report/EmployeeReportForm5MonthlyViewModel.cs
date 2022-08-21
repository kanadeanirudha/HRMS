using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeReportForm5MonthlyViewModel
    {

        public EmployeeReportForm5MonthlyViewModel()
        {
            EmployeeReportForm5Monthly = new EmployeeReportForm5Monthly();
            EmployeeReportForm5MonthlyList = new List<EmployeeReportForm5Monthly>();
        }
        public List<EmployeeReportForm5Monthly> EmployeeReportForm5MonthlyList { get; set; }

        public EmployeeReportForm5Monthly EmployeeReportForm5Monthly
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (EmployeeReportForm5Monthly != null && EmployeeReportForm5Monthly.ID > 0) ? EmployeeReportForm5Monthly.ID : new Int64();
            }
            set
            {
                EmployeeReportForm5Monthly.ID = value;
            }
        }
        [Display(Name = "From Date")]
        public string FromDate
        {
            get
            {
                return (EmployeeReportForm5Monthly != null) ? EmployeeReportForm5Monthly.FromDate : string.Empty;
            }
            set
            {
                EmployeeReportForm5Monthly.FromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string UptoDate
        {
            get
            {
                return (EmployeeReportForm5Monthly != null) ? EmployeeReportForm5Monthly.UptoDate : string.Empty;
            }
            set
            {
                EmployeeReportForm5Monthly.UptoDate = value;
            }
        }
        [Display(Name = "Month")]
        public string MonthName
        {
            get
            {
                return (EmployeeReportForm5Monthly != null) ? EmployeeReportForm5Monthly.MonthName : string.Empty;
            }
            set
            {
                EmployeeReportForm5Monthly.MonthName = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (EmployeeReportForm5Monthly != null) ? EmployeeReportForm5Monthly.MonthYear : string.Empty;
            }
            set
            {
                EmployeeReportForm5Monthly.MonthYear = value;
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
                return (EmployeeReportForm5Monthly != null) ? EmployeeReportForm5Monthly.IsDeleted : false;
            }
            set
            {
                EmployeeReportForm5Monthly.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeReportForm5Monthly != null && EmployeeReportForm5Monthly.CreatedBy > 0) ? EmployeeReportForm5Monthly.CreatedBy : new int();
            }
            set
            {
                EmployeeReportForm5Monthly.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeReportForm5Monthly != null) ? EmployeeReportForm5Monthly.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeReportForm5Monthly.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeeReportForm5Monthly != null && EmployeeReportForm5Monthly.ModifiedBy > 0) ? EmployeeReportForm5Monthly.ModifiedBy : new int();
            }
            set
            {
                EmployeeReportForm5Monthly.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeReportForm5Monthly != null && EmployeeReportForm5Monthly.ModifiedDate.HasValue) ? EmployeeReportForm5Monthly.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeReportForm5Monthly.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeeReportForm5Monthly != null && EmployeeReportForm5Monthly.DeletedBy > 0) ? EmployeeReportForm5Monthly.DeletedBy : new int();
            }
            set
            {
                EmployeeReportForm5Monthly.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeReportForm5Monthly != null && EmployeeReportForm5Monthly.DeletedDate.HasValue) ? EmployeeReportForm5Monthly.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeReportForm5Monthly.DeletedDate = value;
            }
        }
        [Display(Name = "Employee Name")]
        public Int32 SaleContractEmployeeMasterID
        {
            get
            {
                return (EmployeeReportForm5Monthly != null && EmployeeReportForm5Monthly.SaleContractEmployeeMasterID > 0) ? EmployeeReportForm5Monthly.SaleContractEmployeeMasterID : new Int32();
            }
            set
            {
                EmployeeReportForm5Monthly.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (EmployeeReportForm5Monthly != null) ? EmployeeReportForm5Monthly.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                EmployeeReportForm5Monthly.SaleContractEmployeeMasterName = value;
            }
        }

        [Display(Name = "Account Session")]
        public int AccountSessionID
        {
            get
            {
                return (EmployeeReportForm5Monthly != null && EmployeeReportForm5Monthly.AccountSessionID > 0) ? EmployeeReportForm5Monthly.AccountSessionID : new int();
            }
            set
            {
                EmployeeReportForm5Monthly.AccountSessionID = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

