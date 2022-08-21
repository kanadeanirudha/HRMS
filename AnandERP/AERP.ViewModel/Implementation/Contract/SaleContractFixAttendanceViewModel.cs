using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractFixAttendanceViewModel : ISaleContractFixAttendanceViewModel
    {

        public SaleContractFixAttendanceViewModel()
        {
            SaleContractFixAttendanceDTO = new SaleContractFixAttendance();
            SaleContractSpanList = new List<SaleContractAttendance>();
            SaleContractFixAttendanceList = new List<SaleContractFixAttendance>();
        }

        public List<SaleContractAttendance> SaleContractSpanList { get; set; }
        public List<SaleContractFixAttendance> SaleContractFixAttendanceList { get; set; }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractSpanList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public SaleContractFixAttendance SaleContractFixAttendanceDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.ID > 0) ? SaleContractFixAttendanceDTO.ID : new Int64();
            }
            set
            {
                SaleContractFixAttendanceDTO.ID = value;
            }
        }
        [Display(Name ="Contract Number")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.SaleContractMasterID > 0) ? SaleContractFixAttendanceDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractFixAttendanceDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.CustomerBranchMasterID > 0) ? SaleContractFixAttendanceDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SaleContractFixAttendanceDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null) ? SaleContractFixAttendanceDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SaleContractFixAttendanceDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Customer")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.CustomerMasterID > 0) ? SaleContractFixAttendanceDTO.CustomerMasterID : new Int32();
            }
            set
            {
                SaleContractFixAttendanceDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Customer")]
        public string CustomerMasterName
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null) ? SaleContractFixAttendanceDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                SaleContractFixAttendanceDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null) ? SaleContractFixAttendanceDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractFixAttendanceDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Job Work Item")]
        public Int32 SaleContractFixItemID
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.SaleContractFixItemID > 0) ? SaleContractFixAttendanceDTO.SaleContractFixItemID : new Int32();
            }
            set
            {
                SaleContractFixAttendanceDTO.SaleContractFixItemID = value;
            }
        }
        [Display(Name = "Job Work Item")]
        public string SaleContractFixItemName
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null) ? SaleContractFixAttendanceDTO.SaleContractFixItemName : string.Empty;
            }
            set
            {
                SaleContractFixAttendanceDTO.SaleContractFixItemName = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.SaleContractBillingSpanID > 0) ? SaleContractFixAttendanceDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractFixAttendanceDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null) ? SaleContractFixAttendanceDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractFixAttendanceDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Total Days")]
        public decimal SaleContractFixItemQuantity
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.SaleContractFixItemQuantity > 0) ? SaleContractFixAttendanceDTO.SaleContractFixItemQuantity : new decimal();
            }
            set
            {
                SaleContractFixAttendanceDTO.SaleContractFixItemQuantity = value;
            }
        }
        [Display(Name = "Total Days")]
        public decimal SaleContractFixItemAttendance
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.SaleContractFixItemAttendance> 0) ? SaleContractFixAttendanceDTO.SaleContractFixItemAttendance : new decimal();
            }
            set
            {
                SaleContractFixAttendanceDTO.SaleContractFixItemAttendance = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null) ? SaleContractFixAttendanceDTO.IsDeleted : false;
            }
            set
            {
                SaleContractFixAttendanceDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.CreatedBy > 0) ? SaleContractFixAttendanceDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractFixAttendanceDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null) ? SaleContractFixAttendanceDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractFixAttendanceDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.ModifiedBy > 0) ? SaleContractFixAttendanceDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractFixAttendanceDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.ModifiedDate.HasValue) ? SaleContractFixAttendanceDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractFixAttendanceDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.DeletedBy > 0) ? SaleContractFixAttendanceDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractFixAttendanceDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractFixAttendanceDTO != null && SaleContractFixAttendanceDTO.DeletedDate.HasValue) ? SaleContractFixAttendanceDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractFixAttendanceDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLstringForFixItemData { get; set; }
    }
}

