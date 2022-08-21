using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractJobWorkDataViewModel : ISaleContractJobWorkDataViewModel
    {

        public SaleContractJobWorkDataViewModel()
        {
            SaleContractJobWorkDataDTO = new SaleContractJobWorkData();
            SaleContractSpanList = new List<SaleContractAttendance>();
            SaleContractJobWorkDataList = new List<SaleContractJobWorkData>();
        }

        public List<SaleContractAttendance> SaleContractSpanList { get; set; }
        public List<SaleContractJobWorkData> SaleContractJobWorkDataList { get; set; }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractSpanList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public SaleContractJobWorkData SaleContractJobWorkDataDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.ID > 0) ? SaleContractJobWorkDataDTO.ID : new Int64();
            }
            set
            {
                SaleContractJobWorkDataDTO.ID = value;
            }
        }
        [Display(Name ="Contract Number")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.SaleContractMasterID > 0) ? SaleContractJobWorkDataDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractJobWorkDataDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.CustomerBranchMasterID > 0) ? SaleContractJobWorkDataDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SaleContractJobWorkDataDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null) ? SaleContractJobWorkDataDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SaleContractJobWorkDataDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Customer")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.CustomerMasterID > 0) ? SaleContractJobWorkDataDTO.CustomerMasterID : new Int32();
            }
            set
            {
                SaleContractJobWorkDataDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Customer")]
        public string CustomerMasterName
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null) ? SaleContractJobWorkDataDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                SaleContractJobWorkDataDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null) ? SaleContractJobWorkDataDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractJobWorkDataDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Job Work Item")]
        public Int32 SaleContractJobWorkItemID
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.SaleContractJobWorkItemID > 0) ? SaleContractJobWorkDataDTO.SaleContractJobWorkItemID : new Int32();
            }
            set
            {
                SaleContractJobWorkDataDTO.SaleContractJobWorkItemID = value;
            }
        }
        [Display(Name = "Job Work Item")]
        public string SaleContractJobWorkItemName
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null) ? SaleContractJobWorkDataDTO.SaleContractJobWorkItemName : string.Empty;
            }
            set
            {
                SaleContractJobWorkDataDTO.SaleContractJobWorkItemName = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.SaleContractBillingSpanID > 0) ? SaleContractJobWorkDataDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractJobWorkDataDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null) ? SaleContractJobWorkDataDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractJobWorkDataDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Quantity")]
        public decimal Quantity
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.Quantity > 0) ? SaleContractJobWorkDataDTO.Quantity : new Int64();
            }
            set
            {
                SaleContractJobWorkDataDTO.Quantity = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null) ? SaleContractJobWorkDataDTO.IsDeleted : false;
            }
            set
            {
                SaleContractJobWorkDataDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.CreatedBy > 0) ? SaleContractJobWorkDataDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractJobWorkDataDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null) ? SaleContractJobWorkDataDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractJobWorkDataDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.ModifiedBy > 0) ? SaleContractJobWorkDataDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractJobWorkDataDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.ModifiedDate.HasValue) ? SaleContractJobWorkDataDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractJobWorkDataDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.DeletedBy > 0) ? SaleContractJobWorkDataDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractJobWorkDataDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractJobWorkDataDTO != null && SaleContractJobWorkDataDTO.DeletedDate.HasValue) ? SaleContractJobWorkDataDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractJobWorkDataDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLstringForJobWorkData { get; set; }
    }
}

