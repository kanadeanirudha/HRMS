using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GSTReportsViewModel
    {

        public GSTReportsViewModel()
        {
            GSTReports = new GSTReports();
            GSTReportsList = new List<GSTReports>();
            GSTReportsDetailListForparticulars = new List<GSTReports>();
            GSTReportsDTO = new GSTReports();
            ListAccountSessionMasterReport = new List<AccountSessionMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public GSTReports GSTReportsDTO
        { get; set; }

        public List<GSTReports> GSTReportsList { get; set; }
        public List<GSTReports> GSTReportsDetailListForparticulars { get; set; }
        public List<AccountSessionMaster> ListAccountSessionMasterReport { get; set; }
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
        public GSTReports GSTReports
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (GSTReports != null && GSTReports.ID > 0) ? GSTReports.ID : new Int64();
            }
            set
            {
                GSTReports.ID = value;
            }
        }
      
        public bool IsPosted { get; set; }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;set;
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (GSTReports != null) ? GSTReports.IsDeleted : false;
            }
            set
            {
                GSTReports.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (GSTReports != null && GSTReports.CreatedBy > 0) ? GSTReports.CreatedBy : new int();
            }
            set
            {
                GSTReports.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (GSTReports != null) ? GSTReports.CreatedDate : DateTime.Now;
            }
            set
            {
                GSTReports.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (GSTReports != null && GSTReports.ModifiedBy > 0) ? GSTReports.ModifiedBy : new int();
            }
            set
            {
                GSTReports.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GSTReports != null && GSTReports.ModifiedDate.HasValue) ? GSTReports.ModifiedDate : DateTime.Now;
            }
            set
            {
                GSTReports.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (GSTReports != null && GSTReports.DeletedBy > 0) ? GSTReports.DeletedBy : new int();
            }
            set
            {
                GSTReports.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GSTReports != null && GSTReports.DeletedDate.HasValue) ? GSTReports.DeletedDate : DateTime.Now;
            }
            set
            {
                GSTReports.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        public string FromDate
        {
            get
            {
                return (GSTReports != null) ? GSTReports.FromDate : string.Empty;
            }
            set
            {
                GSTReports.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (GSTReports != null) ? GSTReports.UptoDate : string.Empty;
            }
            set
            {
                GSTReports.UptoDate = value;
            }
        }
        public int AccountSessionID
        {
            get
            {
                return (GSTReports != null) ? GSTReports.AccountSessionID : new Int32();
            }
            set
            {
                GSTReports.AccountSessionID = value;
            }
        }
    }
}

