using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractEmployeeAdvancesViewModel : ISaleContractEmployeeAdvancesViewModel
    {

        public SaleContractEmployeeAdvancesViewModel()
        {
            SaleContractEmployeeAdvancesDTO = new SaleContractEmployeeAdvances();
        }

        public SaleContractEmployeeAdvances SaleContractEmployeeAdvancesDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.ID > 0) ? SaleContractEmployeeAdvancesDTO.ID : new Int64();
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.ID = value;
            }
        }
        [Display(Name = "Contract Employee")]
        [Required(ErrorMessage = "Contract Employee")]
        public Int32 ContractEmployeeMasterID
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.ContractEmployeeMasterID > 0) ? SaleContractEmployeeAdvancesDTO.ContractEmployeeMasterID : new Int32();
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.ContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Contract Employee")]
        [Required(ErrorMessage = "Contract Employee")]
        public string ContractEmployeeMasterName
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null) ? SaleContractEmployeeAdvancesDTO.ContractEmployeeMasterName : string.Empty;
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.ContractEmployeeMasterName = value;
            }
        }
        [Display(Name = "Transaction Date")]
        [Required(ErrorMessage = "Transaction Date")]
        public string TransactionDate
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null) ? SaleContractEmployeeAdvancesDTO.TransactionDate : string.Empty;
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.TransactionDate = value;
            }
        }
        [Display(Name = "Advance Amount")]
        [Required(ErrorMessage = "Advance Amount")]
        public decimal AdvanceAmount
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.AdvanceAmount > 0) ? SaleContractEmployeeAdvancesDTO.AdvanceAmount : new decimal();
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.AdvanceAmount = value;
            }
        }
        [Display(Name = "Payment Mode")]
        [Required(ErrorMessage = "Payment Mode")]
        public byte PaymentMode
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.PaymentMode > 0) ? SaleContractEmployeeAdvancesDTO.PaymentMode : new byte();
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.PaymentMode = value;
            }
        }
        [Display(Name = "Refund Amount")]
        public decimal RefundAmount
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.RefundAmount > 0) ? SaleContractEmployeeAdvancesDTO.RefundAmount : new decimal();
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.RefundAmount = value;
            }
        }
        [Display(Name = "Is Refund")]
        public byte IsRefund
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null) ? SaleContractEmployeeAdvancesDTO.IsRefund : new byte();
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.IsRefund = value;
            }
        }
        [Display(Name = "Refund Date")]
        public string RefundDate
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null) ? SaleContractEmployeeAdvancesDTO.RefundDate : string.Empty;
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.RefundDate = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null) ? SaleContractEmployeeAdvancesDTO.IsDeleted : false;
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.CreatedBy > 0) ? SaleContractEmployeeAdvancesDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null) ? SaleContractEmployeeAdvancesDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.ModifiedBy > 0) ? SaleContractEmployeeAdvancesDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.ModifiedDate.HasValue) ? SaleContractEmployeeAdvancesDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.DeletedBy > 0) ? SaleContractEmployeeAdvancesDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractEmployeeAdvancesDTO != null && SaleContractEmployeeAdvancesDTO.DeletedDate.HasValue) ? SaleContractEmployeeAdvancesDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractEmployeeAdvancesDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

