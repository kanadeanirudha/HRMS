using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class ATTRITIONReportViewModel
    {

        public ATTRITIONReportViewModel()
        {
            ATTRITIONReport = new ATTRITIONReport();
            ATTRITIONReportList = new List<ATTRITIONReport>();
            ATTRITIONReportDetailListForparticulars = new List<ATTRITIONReport>();
            ATTRITIONReportDTO = new ATTRITIONReport();

        }
        public ATTRITIONReport ATTRITIONReportDTO
        { get; set; }

        public List<ATTRITIONReport> ATTRITIONReportList { get; set; }
        public List<ATTRITIONReport> ATTRITIONReportDetailListForparticulars { get; set; }

        public ATTRITIONReport ATTRITIONReport
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (ATTRITIONReport != null && ATTRITIONReport.ID > 0) ? ATTRITIONReport.ID : new Int64();
            }
            set
            {
                ATTRITIONReport.ID = value;
            }
        }
        [Display(Name = "Employee Name")]
        public int SaleContractEmployeeMasterID
        {
            get
            {
                return (ATTRITIONReport != null && ATTRITIONReport.SaleContractEmployeeMasterID > 0) ? ATTRITIONReport.SaleContractEmployeeMasterID : new int();
            }
            set
            {
                ATTRITIONReport.ID = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (ATTRITIONReport != null) ? ATTRITIONReport.MonthYear : string.Empty;
            }
            set
            {
                ATTRITIONReport.MonthYear = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (ATTRITIONReport != null) ? ATTRITIONReport.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                ATTRITIONReport.SaleContractEmployeeMasterName = value;
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
                return (ATTRITIONReport != null) ? ATTRITIONReport.IsDeleted : false;
            }
            set
            {
                ATTRITIONReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ATTRITIONReport != null && ATTRITIONReport.CreatedBy > 0) ? ATTRITIONReport.CreatedBy : new int();
            }
            set
            {
                ATTRITIONReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ATTRITIONReport != null) ? ATTRITIONReport.CreatedDate : DateTime.Now;
            }
            set
            {
                ATTRITIONReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ATTRITIONReport != null && ATTRITIONReport.ModifiedBy > 0) ? ATTRITIONReport.ModifiedBy : new int();
            }
            set
            {
                ATTRITIONReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ATTRITIONReport != null && ATTRITIONReport.ModifiedDate.HasValue) ? ATTRITIONReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                ATTRITIONReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ATTRITIONReport != null && ATTRITIONReport.DeletedBy > 0) ? ATTRITIONReport.DeletedBy : new int();
            }
            set
            {
                ATTRITIONReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ATTRITIONReport != null && ATTRITIONReport.DeletedDate.HasValue) ? ATTRITIONReport.DeletedDate : DateTime.Now;
            }
            set
            {
                ATTRITIONReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

