using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralTransactionMasterViewModel : IGeneralTransactionMasterViewModel
    {

        public GeneralTransactionMasterViewModel()
        {
            GeneralTransactionMasterDTO = new GeneralTransactionMaster();

        }



        public GeneralTransactionMaster GeneralTransactionMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralTransactionMasterDTO != null && GeneralTransactionMasterDTO.ID > 0) ? GeneralTransactionMasterDTO.ID : new Int16();
            }
            set
            {
                GeneralTransactionMasterDTO.ID = value;
            }
        }


        [Required(ErrorMessage = "Transaction Type should not be blank.")]
        [Display(Name = "Transaction Type")]
        public string TransactionType
        {
            get
            {
                return (GeneralTransactionMasterDTO != null) ? GeneralTransactionMasterDTO.TransactionType : string.Empty;
            }
            set
            {
                GeneralTransactionMasterDTO.TransactionType = value;
            }
        }

       
        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (GeneralTransactionMasterDTO != null) ? GeneralTransactionMasterDTO.IsActive : false;
            }
            set
            {
                GeneralTransactionMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralTransactionMasterDTO != null) ? GeneralTransactionMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralTransactionMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralTransactionMasterDTO != null && GeneralTransactionMasterDTO.CreatedBy > 0) ? GeneralTransactionMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralTransactionMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralTransactionMasterDTO != null) ? GeneralTransactionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralTransactionMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralTransactionMasterDTO != null) ? GeneralTransactionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralTransactionMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralTransactionMasterDTO != null) ? GeneralTransactionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralTransactionMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralTransactionMasterDTO != null) ? GeneralTransactionMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralTransactionMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralTransactionMasterDTO != null) ? GeneralTransactionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralTransactionMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

