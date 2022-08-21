using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralMainTypeMasterViewModel : IGeneralMainTypeMasterViewModel
    {
        public GeneralMainTypeMasterViewModel()
        {
            GeneralMainTypeMasterDTO = new GeneralMainTypeMaster();
        }

        public GeneralMainTypeMaster GeneralMainTypeMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.ID > 0) ? GeneralMainTypeMasterDTO.ID : new int();
            }
            set
            {
                GeneralMainTypeMasterDTO.ID = value;
            }
        }

        [Display(Name="Type Description")]
        [Required(ErrorMessage="Type description should not be blank.")]
        public string TypeDesc
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.TypeDesc != "") ? GeneralMainTypeMasterDTO.TypeDesc : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.TypeDesc = value;
            }
        }

        [Display(Name="Type Short Description")]
        [Required(ErrorMessage="Type short description should not be blank.")]
        public string TypeShortDesc
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.TypeShortDesc != "") ? GeneralMainTypeMasterDTO.TypeShortDesc : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.TypeShortDesc = value;
            }
        }

        [Display(Name = "Refeance Table")]
        [Required(ErrorMessage = "Refeance table entity should not be blank.")]
        public string RefTableEntity
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.RefTableEntity != "") ? GeneralMainTypeMasterDTO.RefTableEntity : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.RefTableEntity = value;
            }
        }

        [Display(Name = "Refeance Table Key")]
        [Required(ErrorMessage = "Refeance table entity key should not be blank.")]
        public string RefTableEntityKey
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.RefTableEntityKey != "") ? GeneralMainTypeMasterDTO.RefTableEntityKey : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.RefTableEntityKey = value;
            }
        }

        public string MenuCode
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.MenuCode != "") ? GeneralMainTypeMasterDTO.MenuCode : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.MenuCode = value;
            }
        }

        public string ModuleCode
        {
            get 
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.ModuleCode != "") ? GeneralMainTypeMasterDTO.ModuleCode : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.ModuleCode = value;
            }
        }
        
        public bool IsFixed
        {
            get
            {
                return(GeneralMainTypeMasterDTO!= null && GeneralMainTypeMasterDTO.IsFixed != false) ? GeneralMainTypeMasterDTO.IsFixed : false;
            }
            set
            {
                GeneralMainTypeMasterDTO.IsFixed = value;
            }
        }



        //----------------------------GeneralSubTypeMaster Table Property.------------------------

        public int GeneralSubTypeMasterID
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.GeneralSubTypeMasterID > 0) ? GeneralMainTypeMasterDTO.GeneralSubTypeMasterID : new int();
            }
            set
            {
                GeneralMainTypeMasterDTO.GeneralSubTypeMasterID = value;
            }
        }

        public int GeneralMainTypeMasterID
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.GeneralMainTypeMasterID > 0) ? GeneralMainTypeMasterDTO.GeneralMainTypeMasterID : new int();
            }
            set
            {
                GeneralMainTypeMasterDTO.GeneralMainTypeMasterID = value;
            }
        }

        [Display(Name = "Sub Type Description")]
        [Required(ErrorMessage = "Sub type description should not be blank.")]
        public string SubTypeDesc
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.SubTypeDesc != "") ? GeneralMainTypeMasterDTO.SubTypeDesc : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.SubTypeDesc = value;
            }
        }

        [Display(Name = "Sub Short Description")]
        [Required(ErrorMessage = "Sub short description should not be blank.")]
        public string SubShortDesc
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.SubShortDesc != "") ? GeneralMainTypeMasterDTO.SubShortDesc : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.SubShortDesc = value;
            }
        }

        public int AccountID
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.AccountID > 0) ? GeneralMainTypeMasterDTO.AccountID : new int();
            }
            set
            {
                GeneralMainTypeMasterDTO.AccountID = value;
            }
        }

        public string RefTableEntityKeyValue
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.RefTableEntityKeyValue != "") ? GeneralMainTypeMasterDTO.RefTableEntityKeyValue : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.RefTableEntityKeyValue = value;
            }
        }

        [Display(Name = "Refreance Table Entity Key Value")]
        [Required(ErrorMessage = "Refreance table entity key Value should not be blank.")]
        public string RefTableEntityDisplayKey
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.RefTableEntityDisplayKey != "") ? GeneralMainTypeMasterDTO.RefTableEntityDisplayKey : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.RefTableEntityDisplayKey = value;
            }
        }

        [Required(ErrorMessage = "Key code should not be blank.")]
        public string KeyCode
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.KeyCode != "") ? GeneralMainTypeMasterDTO.KeyCode : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.KeyCode = value;
            }
        }

        public int PersonTypeID
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.PersonTypeID > 0) ? GeneralMainTypeMasterDTO.PersonTypeID : new int();
            }
            set
            {
                GeneralMainTypeMasterDTO.PersonTypeID = value;
            }
        }


        ///-----------------------Common Field-------------------------------

        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null) ? GeneralMainTypeMasterDTO.IsActive : false;
            }
            set
            {
                GeneralMainTypeMasterDTO.IsActive = value;
            }
        }
        
        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null) ? GeneralMainTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralMainTypeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int? CreatedBy
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.CreatedBy > 0) ? GeneralMainTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralMainTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime? CreatedDate
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null) ? GeneralMainTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralMainTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.ModifiedBy.HasValue) ? GeneralMainTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralMainTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.ModifiedDate.HasValue) ? GeneralMainTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralMainTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.DeletedBy.HasValue) ? GeneralMainTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralMainTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.DeletedDate.HasValue) ? GeneralMainTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralMainTypeMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.errorMessage != "") ? GeneralMainTypeMasterDTO.errorMessage : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.errorMessage = value;
            }
        }

        /// <summary>
        /// ------------------------------Extra Field--------------------------
        /// </summary>
        [Display(Name = "Menu")]
        [Required(ErrorMessage = "Menu should not be blank.")]
        public string MenuName
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.MenuName != "") ? GeneralMainTypeMasterDTO.MenuName : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.MenuName = value;
            }
        }

        [Display(Name = "Module")]
        [Required(ErrorMessage = "Module name should not be blank.")]
        public string ModuleName
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.ModuleName != "") ? GeneralMainTypeMasterDTO.ModuleName : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.ModuleName = value;
            }
        }

        [Required(ErrorMessage = "Transaction type should not be blank.")]
        public string TransactionType
        {
            get
            {
                return (GeneralMainTypeMasterDTO != null && GeneralMainTypeMasterDTO.TransactionType != "") ? GeneralMainTypeMasterDTO.TransactionType : string.Empty;
            }
            set
            {
                GeneralMainTypeMasterDTO.TransactionType = value;
            }
        }
        

    }
}
