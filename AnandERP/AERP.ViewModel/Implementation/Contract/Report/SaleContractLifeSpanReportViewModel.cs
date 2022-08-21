using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractLifeSpanReportViewModel
    {

        public SaleContractLifeSpanReportViewModel()
        {
            SaleContractLifeSpanReport = new SaleContractLifeSpanReport();
            SaleContractLifeSpanReportList = new List<SaleContractLifeSpanReport>();
            SaleContractLifeSpanReportDTO = new SaleContractLifeSpanReport();

        }
        public SaleContractLifeSpanReport SaleContractLifeSpanReportDTO
        { get; set; }

        public List<SaleContractLifeSpanReport> SaleContractLifeSpanReportList { get; set; }

        public SaleContractLifeSpanReport SaleContractLifeSpanReport
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SaleContractLifeSpanReport != null && SaleContractLifeSpanReport.ID > 0) ? SaleContractLifeSpanReport.ID : new int();
            }
            set
            {
                SaleContractLifeSpanReport.ID = value;
            }
        }
        [Display(Name = "Contract Start Date")]
        public string ContractStartDate
        {
            get
            {
                return (SaleContractLifeSpanReport != null) ? SaleContractLifeSpanReport.ContractStartDate : string.Empty;
            }
            set
            {
                SaleContractLifeSpanReport.ContractStartDate = value;
            }
        }

        [Display(Name = "Contract End Date")]
        public string ContractEndDate
        {
            get
            {
                return (SaleContractLifeSpanReport != null) ? SaleContractLifeSpanReport.ContractEndDate : string.Empty;
            }
            set
            {
                SaleContractLifeSpanReport.ContractEndDate = value;
            }
        }

        public bool IsPosted { get; set; }
     
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractLifeSpanReport != null) ? SaleContractLifeSpanReport.IsDeleted : false;
            }
            set
            {
                SaleContractLifeSpanReport.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractLifeSpanReport != null && SaleContractLifeSpanReport.CreatedBy > 0) ? SaleContractLifeSpanReport.CreatedBy : new int();
            }
            set
            {
                SaleContractLifeSpanReport.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractLifeSpanReport != null) ? SaleContractLifeSpanReport.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractLifeSpanReport.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractLifeSpanReport != null && SaleContractLifeSpanReport.ModifiedBy > 0) ? SaleContractLifeSpanReport.ModifiedBy : new int();
            }
            set
            {
                SaleContractLifeSpanReport.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractLifeSpanReport != null && SaleContractLifeSpanReport.ModifiedDate.HasValue) ? SaleContractLifeSpanReport.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractLifeSpanReport.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractLifeSpanReport != null && SaleContractLifeSpanReport.DeletedBy > 0) ? SaleContractLifeSpanReport.DeletedBy : new int();
            }
            set
            {
                SaleContractLifeSpanReport.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractLifeSpanReport != null && SaleContractLifeSpanReport.DeletedDate.HasValue) ? SaleContractLifeSpanReport.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractLifeSpanReport.DeletedDate = value;
            }
        }



        public string errorMessage { get; set; }
    }
}

