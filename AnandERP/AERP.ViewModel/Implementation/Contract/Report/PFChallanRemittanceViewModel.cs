using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class PFChallanRemittanceViewModel
    {

        public PFChallanRemittanceViewModel()
        {
            PFChallanRemittance = new PFChallanRemittance();
            PFChallanRemittanceList = new List<PFChallanRemittance>();
            PFChallanRemittanceDetailListForparticulars = new List<PFChallanRemittance>();
            PFChallanRemittanceDTO = new PFChallanRemittance();

        }
        public PFChallanRemittance PFChallanRemittanceDTO
        { get; set; }

        public List<PFChallanRemittance> PFChallanRemittanceList { get; set; }
        public List<PFChallanRemittance> PFChallanRemittanceDetailListForparticulars { get; set; }

        public PFChallanRemittance PFChallanRemittance
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (PFChallanRemittance != null && PFChallanRemittance.ID > 0) ? PFChallanRemittance.ID : new Int64();
            }
            set
            {
                PFChallanRemittance.ID = value;
            }
        }
        [Display(Name = "From Date")]
        public string FromDate
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.FromDate : string.Empty;
            }
            set
            {
                PFChallanRemittance.FromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string UptoDate
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.UptoDate : string.Empty;
            }
            set
            {
                PFChallanRemittance.UptoDate = value;
            }
        }
        [Display(Name = "Month")]
        public string MonthName
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.MonthName : string.Empty;
            }
            set
            {
                PFChallanRemittance.MonthName = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.MonthYear : string.Empty;
            }
            set
            {
                PFChallanRemittance.MonthYear = value;
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
                return (PFChallanRemittance != null) ? PFChallanRemittance.IsDeleted : false;
            }
            set
            {
                PFChallanRemittance.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (PFChallanRemittance != null && PFChallanRemittance.CreatedBy > 0) ? PFChallanRemittance.CreatedBy : new int();
            }
            set
            {
                PFChallanRemittance.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.CreatedDate : DateTime.Now;
            }
            set
            {
                PFChallanRemittance.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (PFChallanRemittance != null && PFChallanRemittance.ModifiedBy > 0) ? PFChallanRemittance.ModifiedBy : new int();
            }
            set
            {
                PFChallanRemittance.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (PFChallanRemittance != null && PFChallanRemittance.ModifiedDate.HasValue) ? PFChallanRemittance.ModifiedDate : DateTime.Now;
            }
            set
            {
                PFChallanRemittance.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (PFChallanRemittance != null && PFChallanRemittance.DeletedBy > 0) ? PFChallanRemittance.DeletedBy : new int();
            }
            set
            {
                PFChallanRemittance.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (PFChallanRemittance != null && PFChallanRemittance.DeletedDate.HasValue) ? PFChallanRemittance.DeletedDate : DateTime.Now;
            }
            set
            {
                PFChallanRemittance.DeletedDate = value;
            }
        }

        [Display(Name = "Reference Number")]
        public string ReferenceNumber
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.ReferenceNumber : string.Empty;
            }
            set
            {
                PFChallanRemittance.ReferenceNumber = value;
            }
        }
        [Display(Name = "Payment Mode")]
        public byte PaymentMode
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.PaymentMode : new byte();
            }
            set
            {
                PFChallanRemittance.PaymentMode = value;
            }
        }
        [Display(Name = "Transaction Date")]
        public string TransactionDate
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.TransactionDate : string.Empty;
            }
            set
            {
                PFChallanRemittance.TransactionDate = value;
            }
        }
        [Display(Name = "Challan Remmittance Date")]
        public string ChallanRemmittanceDate
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.ChallanRemmittanceDate : string.Empty;
            }
            set
            {
                PFChallanRemittance.ChallanRemmittanceDate = value;
            }
        }
        [Display(Name = "Acc01")]
        public decimal Acc01
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.Acc01 : new decimal();
            }
            set
            {
                PFChallanRemittance.Acc01 = value;
            }
        }
        [Display(Name = "Acc02")]
        public decimal Acc02
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.Acc02 : new decimal();
            }
            set
            {
                PFChallanRemittance.Acc02 = value;
            }
        }
        [Display(Name = "Acc10")]
        public decimal Acc10
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.Acc10 : new decimal();
            }
            set
            {
                PFChallanRemittance.Acc10 = value;
            }
        }
        [Display(Name = "Acc22")]
        public decimal Acc22
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.Acc22 : new decimal();
            }
            set
            {
                PFChallanRemittance.Acc22 = value;
            }
        }
        [Display(Name = "Acc21")]
        public decimal Acc21
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.Acc21 : new decimal();
            }
            set
            {
                PFChallanRemittance.Acc21 = value;
            }
        }
        [Display(Name = "Total Amount Remited")]
        public decimal TotalAmountRemited
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.TotalAmountRemited : new decimal();
            }
            set
            {
                PFChallanRemittance.TotalAmountRemited = value;
            }
        }
        
        public string errorMessage { get; set; }
        

        public string PFAmountInWords
        {
            get
            {
                return (PFChallanRemittance != null) ? PFChallanRemittance.PFAmountInWords : string.Empty;
            }
            set
            {
                PFChallanRemittance.PFAmountInWords = value;
            }
        }

        
    }
}

