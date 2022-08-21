using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
    /// <summary>
    /// View Model of table AccBalancesheetTypeMaster
    /// </summary>
    /// 

   public class AccountBalancesheetTypeMasterViewModel : IAccountBalancesheetTypeMasterViewModel
    {
       public AccountBalancesheetTypeMasterViewModel()
       {
           AccountBalancesheetTypeMasterDTO = new AccountBalancesheetTypeMaster();
       }

       public AccountBalancesheetTypeMaster AccountBalancesheetTypeMasterDTO { get; set; }

       public byte ID
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null && AccountBalancesheetTypeMasterDTO.ID > 0) ? AccountBalancesheetTypeMasterDTO.ID : new byte();
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.ID = value;
           }
       }
        [Display(Name = "Account Balancesheet Type")]
       public Int16 AccBalsheetType
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null && AccountBalancesheetTypeMasterDTO.AccBalsheetType > 0) ? AccountBalancesheetTypeMasterDTO.AccBalsheetType : new Int16();
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.AccBalsheetType = value;
           }
       }     

       [Display(Name = "Account Balancesheet Type Code")]
       [Required(ErrorMessage ="Account Balancesheet Type Code Required")]
       public string AccBalsheetTypeCode
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null) ? AccountBalancesheetTypeMasterDTO.AccBalsheetTypeCode : string.Empty;
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.AccBalsheetTypeCode = value;
           }
       }

       [Display(Name = "Account Balancesheet Type Desc")]
       [Required(ErrorMessage ="Account Balancesheet Type Description Required")]
       public string AccBalsheetTypeDesc
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null) ? AccountBalancesheetTypeMasterDTO.AccBalsheetTypeDesc : string.Empty;
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.AccBalsheetTypeDesc = value;
           }
       }

       [Display(Name = "Is Active")]
       public bool IsActive
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null) ? AccountBalancesheetTypeMasterDTO.IsActive : false;
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.IsActive = value;
           }
       }

       public int CreatedBy
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null && AccountBalancesheetTypeMasterDTO.CreatedBy > 0) ? AccountBalancesheetTypeMasterDTO.CreatedBy : new int();
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.CreatedBy = value;
           }
       }

       public DateTime CreatedDate
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null) ? AccountBalancesheetTypeMasterDTO.CreatedDate : DateTime.Now;
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.CreatedDate = value;
           }
       }

       public int? ModifiedBy
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null && AccountBalancesheetTypeMasterDTO.ModifiedBy > 0) ? AccountBalancesheetTypeMasterDTO.ModifiedBy : new int();
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.ModifiedBy = value;
           }
       }

       public DateTime? ModifiedDate
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null) ? AccountBalancesheetTypeMasterDTO.ModifiedDate : DateTime.Now;
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.ModifiedDate = value;
           }
       }

       public int? DeletedBy
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null && AccountBalancesheetTypeMasterDTO.DeletedBy > 0) ? AccountBalancesheetTypeMasterDTO.DeletedBy : new int();
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.DeletedBy = value;
           }
       }

       public DateTime? DeletedDate
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null) ? AccountBalancesheetTypeMasterDTO.DeletedDate : DateTime.Now;
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.DeletedDate = value;
           }
       }

       public bool IsDeleted
       {
           get
           {
               return (AccountBalancesheetTypeMasterDTO != null) ? AccountBalancesheetTypeMasterDTO.IsDeleted : false;
           }
           set
           {
               AccountBalancesheetTypeMasterDTO.IsDeleted = value;
           }
       }
    }
}
