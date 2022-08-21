using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class ContractPaymentPendingReportViewModel
    {

        public ContractPaymentPendingReportViewModel()
        {
            ContractPaymentPendingReport = new ContractPaymentPendingReport();
            ContractPaymentPendingReportList = new List<ContractPaymentPendingReport>();
            ContractPaymentPendingReportDTO = new ContractPaymentPendingReport();

        }
        public ContractPaymentPendingReport ContractPaymentPendingReportDTO
        { get; set; }

        public List<ContractPaymentPendingReport> ContractPaymentPendingReportList { get; set; }

        public ContractPaymentPendingReport ContractPaymentPendingReport
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (ContractPaymentPendingReport != null && ContractPaymentPendingReport.ID > 0) ? ContractPaymentPendingReport.ID : new int();
            }
            set
            {
                ContractPaymentPendingReport.ID = value;
            }
        }
        [Display(Name = "Contract Start Date")]
        public string ContractStartDate
        {
            get
            {
                return (ContractPaymentPendingReport != null) ? ContractPaymentPendingReport.ContractStartDate : string.Empty;
            }
            set
            {
                ContractPaymentPendingReport.ContractStartDate = value;
            }
        }

        [Display(Name = "Contract End Date")]
        public string ContractEndDate
        {
            get
            {
                return (ContractPaymentPendingReport != null) ? ContractPaymentPendingReport.ContractEndDate : string.Empty;
            }
            set
            {
                ContractPaymentPendingReport.ContractEndDate = value;
            }
        }

        public bool IsPosted { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (ContractPaymentPendingReport != null) ? ContractPaymentPendingReport.IsDeleted : false;
            }
            set
            {
                ContractPaymentPendingReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ContractPaymentPendingReport != null && ContractPaymentPendingReport.CreatedBy > 0) ? ContractPaymentPendingReport.CreatedBy : new int();
            }
            set
            {
                ContractPaymentPendingReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ContractPaymentPendingReport != null) ? ContractPaymentPendingReport.CreatedDate : DateTime.Now;
            }
            set
            {
                ContractPaymentPendingReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ContractPaymentPendingReport != null && ContractPaymentPendingReport.ModifiedBy > 0) ? ContractPaymentPendingReport.ModifiedBy : new int();
            }
            set
            {
                ContractPaymentPendingReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ContractPaymentPendingReport != null && ContractPaymentPendingReport.ModifiedDate.HasValue) ? ContractPaymentPendingReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                ContractPaymentPendingReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ContractPaymentPendingReport != null && ContractPaymentPendingReport.DeletedBy > 0) ? ContractPaymentPendingReport.DeletedBy : new int();
            }
            set
            {
                ContractPaymentPendingReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ContractPaymentPendingReport != null && ContractPaymentPendingReport.DeletedDate.HasValue) ? ContractPaymentPendingReport.DeletedDate : DateTime.Now;
            }
            set
            {
                ContractPaymentPendingReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

