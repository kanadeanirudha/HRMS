using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralPurchaseGroupMasterViewModel : IGeneralPurchaseGroupMasterViewModel
    {
        public GeneralPurchaseGroupMasterViewModel()
        {
            GeneralPurchaseGroupMasterDTO = new GeneralPurchaseGroupMaster();
           
        }

        public GeneralPurchaseGroupMaster GeneralPurchaseGroupMasterDTO { get; set; }

        public Int16 ID
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null && GeneralPurchaseGroupMasterDTO.ID > 0) ? GeneralPurchaseGroupMasterDTO.ID : new Int16();
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.ID = value;
            }
        }

        [Display(Name = "Purchase Group Name")]
        [Required(ErrorMessage = "Purchase Group name should not be blank.")]
        public string PurchaseGroupName
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null) ? GeneralPurchaseGroupMasterDTO.PurchaseGroupName : string.Empty;
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.PurchaseGroupName = value;
            }
        }

        [Display(Name = "Purchase Group Code")]
        [Required(ErrorMessage = "Purchase Group code should not be blank.")]
        public string PurchaseGroupCode
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null) ? GeneralPurchaseGroupMasterDTO.PurchaseGroupCode : string.Empty;
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.PurchaseGroupCode = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null) ? GeneralPurchaseGroupMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null && GeneralPurchaseGroupMasterDTO.CreatedBy > 0) ? GeneralPurchaseGroupMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null) ? GeneralPurchaseGroupMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null) ? GeneralPurchaseGroupMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null) ? GeneralPurchaseGroupMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null) ? GeneralPurchaseGroupMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralPurchaseGroupMasterDTO != null) ? GeneralPurchaseGroupMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPurchaseGroupMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }


    }
}
