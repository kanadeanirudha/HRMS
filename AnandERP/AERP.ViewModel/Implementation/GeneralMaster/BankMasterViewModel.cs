using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class BankMasterViewModel : IBankMasterViewModel
    {

        public BankMasterViewModel()
        {
            BankMasterDTO = new BankMaster();
        }

        public BankMaster BankMasterDTO
        {
            get;
            set;
        }

        public byte ID
        {
            get
            {
                return (BankMasterDTO != null && BankMasterDTO.ID > 0) ? BankMasterDTO.ID : new byte();
            }
            set
            {
                BankMasterDTO.ID = value;
            }
        }

        [Display(Name = "Sequence No")]
        [Required(ErrorMessage = "Sequence No Required")]
        public Nullable<int> SeqNo
        {
            get
            {
                return (BankMasterDTO != null && BankMasterDTO.SeqNo > 0) ? BankMasterDTO.SeqNo : new int();
            }
            set
            {
                BankMasterDTO.SeqNo = value;
            }
        }
        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Bank Name Required")]
        public string BankName
        {
            get
            {
                return (BankMasterDTO != null) ? BankMasterDTO.BankName : string.Empty;
            }
            set
            {
                BankMasterDTO.BankName = value;
            }
        }

        [Display(Name = "Bank IFSC Code")]
        [Required(ErrorMessage = "Bank IFSC Code Required")]
        public string BankIFSCCode
        {
            get
            {
                return (BankMasterDTO != null) ? BankMasterDTO.BankIFSCCode : string.Empty;
            }
            set
            {
                BankMasterDTO.BankIFSCCode = value;
            }
        }

        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "Account Number Required")]
        public string AccountNumber
        {
            get
            {
                return (BankMasterDTO != null) ? BankMasterDTO.AccountNumber : string.Empty;
            }
            set
            {
                BankMasterDTO.AccountNumber = value;
            }
        }

        [Display(Name = "Default Flag")]
        public bool DefaultFlag
        {
            get
            {
                return (BankMasterDTO != null) ? BankMasterDTO.DefaultFlag : false;
            }
            set
            {
                BankMasterDTO.DefaultFlag = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (BankMasterDTO != null) ? BankMasterDTO.IsUserDefined : false;
            }
            set
            {
                BankMasterDTO.IsUserDefined = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (BankMasterDTO != null) ? BankMasterDTO.IsDeleted : false;
            }
            set
            {
                BankMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (BankMasterDTO != null && BankMasterDTO.CreatedBy > 0) ? BankMasterDTO.CreatedBy : new int();
            }
            set
            {
                BankMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (BankMasterDTO != null) ? BankMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                BankMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int? ModifiedBy
        {
            get
            {
                return (BankMasterDTO != null && BankMasterDTO.ModifiedBy.HasValue) ? BankMasterDTO.ModifiedBy : new int();
            }
            set
            {
                BankMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (BankMasterDTO != null && BankMasterDTO.ModifiedDate.HasValue) ? BankMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                BankMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int? DeletedBy
        {
            get
            {
                return (BankMasterDTO != null && BankMasterDTO.DeletedBy.HasValue) ? BankMasterDTO.DeletedBy : new int();
            }
            set
            {
                BankMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (BankMasterDTO != null && BankMasterDTO.DeletedDate.HasValue) ? BankMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                BankMasterDTO.DeletedDate = value;
            }
        }

        public string SelectedCountryID
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}

