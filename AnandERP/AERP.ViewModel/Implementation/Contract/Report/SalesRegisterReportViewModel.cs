using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SalesRegisterReportViewModel
    {

        public SalesRegisterReportViewModel()
        {
            SalesRegisterReport = new SalesRegisterReport();
            SalesRegisterReportList = new List<SalesRegisterReport>();
            SalesRegisterReportDetailListForparticulars = new List<SalesRegisterReport>();
            SalesRegisterReportDTO = new SalesRegisterReport();
            ListAccountSessionMaster = new List<AccountSessionMaster>();
        }
        public SalesRegisterReport SalesRegisterReportDTO
        { get; set; }

        public List<SalesRegisterReport> SalesRegisterReportList { get; set; }
        public List<SalesRegisterReport> SalesRegisterReportDetailListForparticulars { get; set; }

        public SalesRegisterReport SalesRegisterReport
        {
            get;
            set;
        }

        public List<AccountSessionMaster> ListAccountSessionMaster { get; set; }

        public IEnumerable<SelectListItem> AccountSessionMasterItems
        {
            get
            {
                return new SelectList(ListAccountSessionMaster, "ID", "SessionName");
            }
        }

        public Int64 ID
        {
            get
            {
                return (SalesRegisterReport != null && SalesRegisterReport.ID > 0) ? SalesRegisterReport.ID : new Int64();
            }
            set
            {
                SalesRegisterReport.ID = value;
            }
        }
      
        public bool IsPosted { get; set; }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName { get; set; }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public int AccountSessionID { get; set; }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SalesRegisterReport != null) ? SalesRegisterReport.IsDeleted : false;
            }
            set
            {
                SalesRegisterReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SalesRegisterReport != null && SalesRegisterReport.CreatedBy > 0) ? SalesRegisterReport.CreatedBy : new int();
            }
            set
            {
                SalesRegisterReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalesRegisterReport != null) ? SalesRegisterReport.CreatedDate : DateTime.Now;
            }
            set
            {
                SalesRegisterReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SalesRegisterReport != null && SalesRegisterReport.ModifiedBy > 0) ? SalesRegisterReport.ModifiedBy : new int();
            }
            set
            {
                SalesRegisterReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SalesRegisterReport != null && SalesRegisterReport.ModifiedDate.HasValue) ? SalesRegisterReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalesRegisterReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SalesRegisterReport != null && SalesRegisterReport.DeletedBy > 0) ? SalesRegisterReport.DeletedBy : new int();
            }
            set
            {
                SalesRegisterReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SalesRegisterReport != null && SalesRegisterReport.DeletedDate.HasValue) ? SalesRegisterReport.DeletedDate : DateTime.Now;
            }
            set
            {
                SalesRegisterReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

