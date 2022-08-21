using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeESICReportForm7ViewModel
    {

        public EmployeeESICReportForm7ViewModel()
        {
            EmployeeESICReportForm7 = new EmployeeESICReportForm7();
            EmployeeESICReportForm7List = new List<EmployeeESICReportForm7>();
        }
        public List<EmployeeESICReportForm7> EmployeeESICReportForm7List { get; set; }

        public EmployeeESICReportForm7 EmployeeESICReportForm7
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (EmployeeESICReportForm7 != null && EmployeeESICReportForm7.ID > 0) ? EmployeeESICReportForm7.ID : new Int64();
            }
            set
            {
                EmployeeESICReportForm7.ID = value;
            }
        }
        [Display(Name = "From Date")]
        public string FromDate
        {
            get
            {
                return (EmployeeESICReportForm7 != null) ? EmployeeESICReportForm7.FromDate : string.Empty;
            }
            set
            {
                EmployeeESICReportForm7.FromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string UptoDate
        {
            get
            {
                return (EmployeeESICReportForm7 != null) ? EmployeeESICReportForm7.UptoDate : string.Empty;
            }
            set
            {
                EmployeeESICReportForm7.UptoDate = value;
            }
        }
        [Display(Name = "Month")]
        public string MonthName
        {
            get
            {
                return (EmployeeESICReportForm7 != null) ? EmployeeESICReportForm7.MonthName : string.Empty;
            }
            set
            {
                EmployeeESICReportForm7.MonthName = value;
            }
        }
        [Display(Name = "Month")]
        public string MonthFullName
        {
            get
            {
                return (EmployeeESICReportForm7 != null) ? EmployeeESICReportForm7.MonthFullName : string.Empty;
            }
            set
            {
                EmployeeESICReportForm7.MonthFullName = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (EmployeeESICReportForm7 != null) ? EmployeeESICReportForm7.MonthYear : string.Empty;
            }
            set
            {
                EmployeeESICReportForm7.MonthYear = value;
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
                return (EmployeeESICReportForm7 != null) ? EmployeeESICReportForm7.IsDeleted : false;
            }
            set
            {
                EmployeeESICReportForm7.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeESICReportForm7 != null && EmployeeESICReportForm7.CreatedBy > 0) ? EmployeeESICReportForm7.CreatedBy : new int();
            }
            set
            {
                EmployeeESICReportForm7.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeESICReportForm7 != null) ? EmployeeESICReportForm7.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeESICReportForm7.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeeESICReportForm7 != null && EmployeeESICReportForm7.ModifiedBy > 0) ? EmployeeESICReportForm7.ModifiedBy : new int();
            }
            set
            {
                EmployeeESICReportForm7.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeESICReportForm7 != null && EmployeeESICReportForm7.ModifiedDate.HasValue) ? EmployeeESICReportForm7.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeESICReportForm7.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeeESICReportForm7 != null && EmployeeESICReportForm7.DeletedBy > 0) ? EmployeeESICReportForm7.DeletedBy : new int();
            }
            set
            {
                EmployeeESICReportForm7.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeESICReportForm7 != null && EmployeeESICReportForm7.DeletedDate.HasValue) ? EmployeeESICReportForm7.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeESICReportForm7.DeletedDate = value;
            }
        }
        [Display(Name = "Employee Name")]
        public Int32 SaleContractEmployeeMasterID
        {
            get
            {
                return (EmployeeESICReportForm7 != null && EmployeeESICReportForm7.SaleContractEmployeeMasterID > 0) ? EmployeeESICReportForm7.SaleContractEmployeeMasterID : new Int32();
            }
            set
            {
                EmployeeESICReportForm7.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (EmployeeESICReportForm7 != null) ? EmployeeESICReportForm7.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                EmployeeESICReportForm7.SaleContractEmployeeMasterName = value;
            }
        }

        [Display(Name = "Account Session")]
        public int AccountSessionID
        {
            get
            {
                return (EmployeeESICReportForm7 != null && EmployeeESICReportForm7.AccountSessionID > 0) ? EmployeeESICReportForm7.AccountSessionID : new int();
            }
            set
            {
                EmployeeESICReportForm7.AccountSessionID = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

