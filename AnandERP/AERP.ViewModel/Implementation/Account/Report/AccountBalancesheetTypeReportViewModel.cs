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
    /// View Model of table AccountBalancesheetTypeReport
    /// </summary>
    /// 

   public class AccountBalancesheetTypeReportViewModel : IAccountBalancesheetTypeReportViewModel
    {
       public AccountBalancesheetTypeReportViewModel()
       {
           AccountBalancesheetTypeReportDTO = new AccountBalancesheetTypeReport();
       }

       public AccountBalancesheetTypeReport AccountBalancesheetTypeReportDTO { get; set; }

       public byte ID
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null && AccountBalancesheetTypeReportDTO.ID > 0) ? AccountBalancesheetTypeReportDTO.ID : new byte();
           }
           set
           {
               AccountBalancesheetTypeReportDTO.ID = value;
           }
       }

       [Display(Name = "DisplayName_AccBalsheetTypeCode", ResourceType = typeof(AERP.Common.Resources))]
       [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AccBalsheetTypeCodeRequired")]
       public string AccBalsheetTypeCode
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null) ? AccountBalancesheetTypeReportDTO.AccBalsheetTypeCode : string.Empty;
           }
           set
           {
               AccountBalancesheetTypeReportDTO.AccBalsheetTypeCode = value;
           }
       }

       [Display(Name = "DisplayName_AccBalsheetTypeDesc", ResourceType = typeof(AERP.Common.Resources))]
       [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AccBalsheetTypeDescRequired")]
       public string AccBalsheetTypeDesc
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null) ? AccountBalancesheetTypeReportDTO.AccBalsheetTypeDesc : string.Empty;
           }
           set
           {
               AccountBalancesheetTypeReportDTO.AccBalsheetTypeDesc = value;
           }
       }

       [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
       public bool IsActive
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null) ? AccountBalancesheetTypeReportDTO.IsActive : false;
           }
           set
           {
               AccountBalancesheetTypeReportDTO.IsActive = value;
           }
       }

       public int CreatedBy
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null && AccountBalancesheetTypeReportDTO.CreatedBy > 0) ? AccountBalancesheetTypeReportDTO.CreatedBy : new int();
           }
           set
           {
               AccountBalancesheetTypeReportDTO.CreatedBy = value;
           }
       }

       public DateTime CreatedDate
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null) ? AccountBalancesheetTypeReportDTO.CreatedDate : DateTime.Now;
           }
           set
           {
               AccountBalancesheetTypeReportDTO.CreatedDate = value;
           }
       }

       public int? ModifiedBy
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null && AccountBalancesheetTypeReportDTO.ModifiedBy > 0) ? AccountBalancesheetTypeReportDTO.ModifiedBy : new int();
           }
           set
           {
               AccountBalancesheetTypeReportDTO.ModifiedBy = value;
           }
       }

       public DateTime? ModifiedDate
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null) ? AccountBalancesheetTypeReportDTO.ModifiedDate : DateTime.Now;
           }
           set
           {
               AccountBalancesheetTypeReportDTO.ModifiedDate = value;
           }
       }

       public int? DeletedBy
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null && AccountBalancesheetTypeReportDTO.DeletedBy > 0) ? AccountBalancesheetTypeReportDTO.DeletedBy : new int();
           }
           set
           {
               AccountBalancesheetTypeReportDTO.DeletedBy = value;
           }
       }

       public DateTime? DeletedDate
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null) ? AccountBalancesheetTypeReportDTO.DeletedDate : DateTime.Now;
           }
           set
           {
               AccountBalancesheetTypeReportDTO.DeletedDate = value;
           }
       }

       public bool IsDeleted
       {
           get
           {
               return (AccountBalancesheetTypeReportDTO != null) ? AccountBalancesheetTypeReportDTO.IsDeleted : false;
           }
           set
           {
               AccountBalancesheetTypeReportDTO.IsDeleted = value;
           }
       }
    }
}
