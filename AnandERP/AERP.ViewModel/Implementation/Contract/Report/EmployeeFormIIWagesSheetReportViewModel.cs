using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeFormIIWagesSheetReportViewModel
    {

        public EmployeeFormIIWagesSheetReportViewModel()
        {
            EmployeeFormIIWagesSheetReport = new EmployeeFormIIWagesSheetReport();
            EmployeeFormIIWagesSheetReportList = new List<EmployeeFormIIWagesSheetReport>();
            EmployeeFormIIWagesSheetReportDetailListForparticulars = new List<EmployeeFormIIWagesSheetReport>();
            EmployeeFormIIWagesSheetReportDTO = new EmployeeFormIIWagesSheetReport();

        }
        public EmployeeFormIIWagesSheetReport EmployeeFormIIWagesSheetReportDTO
        { get; set; }

        public List<EmployeeFormIIWagesSheetReport> EmployeeFormIIWagesSheetReportList { get; set; }
        public List<EmployeeFormIIWagesSheetReport> EmployeeFormIIWagesSheetReportDetailListForparticulars { get; set; }

        public EmployeeFormIIWagesSheetReport EmployeeFormIIWagesSheetReport
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null && EmployeeFormIIWagesSheetReport.ID > 0) ? EmployeeFormIIWagesSheetReport.ID : new Int64();
            }
            set
            {
                EmployeeFormIIWagesSheetReport.ID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public int SaleContractEmployeeMasterID
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null && EmployeeFormIIWagesSheetReport.SaleContractEmployeeMasterID > 0) ? EmployeeFormIIWagesSheetReport.SaleContractEmployeeMasterID : new int();
            }
            set
            {
                EmployeeFormIIWagesSheetReport.ID = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null) ? EmployeeFormIIWagesSheetReport.MonthYear : string.Empty;
            }
            set
            {
                EmployeeFormIIWagesSheetReport.MonthYear = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null) ? EmployeeFormIIWagesSheetReport.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                EmployeeFormIIWagesSheetReport.SaleContractEmployeeMasterName = value;
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
                return (EmployeeFormIIWagesSheetReport != null) ? EmployeeFormIIWagesSheetReport.IsDeleted : false;
            }
            set
            {
                EmployeeFormIIWagesSheetReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null && EmployeeFormIIWagesSheetReport.CreatedBy > 0) ? EmployeeFormIIWagesSheetReport.CreatedBy : new int();
            }
            set
            {
                EmployeeFormIIWagesSheetReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null) ? EmployeeFormIIWagesSheetReport.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeFormIIWagesSheetReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null && EmployeeFormIIWagesSheetReport.ModifiedBy > 0) ? EmployeeFormIIWagesSheetReport.ModifiedBy : new int();
            }
            set
            {
                EmployeeFormIIWagesSheetReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null && EmployeeFormIIWagesSheetReport.ModifiedDate.HasValue) ? EmployeeFormIIWagesSheetReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeFormIIWagesSheetReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null && EmployeeFormIIWagesSheetReport.DeletedBy > 0) ? EmployeeFormIIWagesSheetReport.DeletedBy : new int();
            }
            set
            {
                EmployeeFormIIWagesSheetReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeFormIIWagesSheetReport != null && EmployeeFormIIWagesSheetReport.DeletedDate.HasValue) ? EmployeeFormIIWagesSheetReport.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeFormIIWagesSheetReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

