using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralRunningNumbersForAccountViewModel : IGeneralRunningNumbersForAccountViewModel
    {

        public GeneralRunningNumbersForAccountViewModel()
        {
           GeneralRunningNumbersForAccountDTO = new GeneralRunningNumbersForAccount();
           ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
           MenuCodeList = new List<GeneralTaskModel>();
        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public List<GeneralTaskModel> MenuCodeList
        { get; set; }

        public IEnumerable<SelectListItem> MenuCodeListItems
        {
            get
            {
                return new SelectList(MenuCodeList, "MenuCode", "MenuName");
            }
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public string EntityLevel { get; set; }
        public string CentreName { get; set; }
     
        public GeneralRunningNumbersForAccount GeneralRunningNumbersForAccountDTO
        {
            get;
            set;
        }
     

        public int ID
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null && GeneralRunningNumbersForAccountDTO.ID > 0) ? GeneralRunningNumbersForAccountDTO.ID : new int();
            }
            set
            {
               GeneralRunningNumbersForAccountDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_RunningNumberDescription", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_RunningNumberDescription")]
        public string Description		
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.Description : string.Empty;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.Description = value;
            }
        }

        [Display(Name = "DisplayName_KeyField", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_KeyField")]
        public string KeyField		
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.KeyField : string.Empty;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.KeyField = value;
            }
        }
        public string CentreCode		
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.CentreCode : string.Empty;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.CentreCode = value;
            }
        }
        [Display(Name = "DisplayName_Seperator", ResourceType = typeof(Resources))]
        public string Seperator
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.Seperator : string.Empty;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.Seperator = value;
            }
        }
         [Display(Name = "DisplayName_Prefix", ResourceType = typeof(Resources))]
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_Prefix")]
        public string Prefix1		
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.Prefix1 : string.Empty;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.Prefix1 = value;
            }
        }

        public string TransactionDate	
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.TransactionDate : string.Empty;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.TransactionDate = value;
            }
        }


        [Display(Name = "DisplayName_DisplayFormat", ResourceType = typeof(Resources))]
        public string DisplayFormat
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.DisplayFormat : string.Empty;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.DisplayFormat = value;
            }
        }
        [Display(Name = "DisplayName_StartNumber", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_StartNumber")]
        public int StartNumber
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null && GeneralRunningNumbersForAccountDTO.StartNumber > 0) ? GeneralRunningNumbersForAccountDTO.StartNumber : new int();
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.StartNumber = value;
            }
        }
        public int CurrentCounter
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null && GeneralRunningNumbersForAccountDTO.CurrentCounter > 0) ? GeneralRunningNumbersForAccountDTO.CurrentCounter : new int();
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.CurrentCounter = value;
            }
        }

        public Int16 FinancialYearID
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null && GeneralRunningNumbersForAccountDTO.FinancialYearID > 0) ? GeneralRunningNumbersForAccountDTO.FinancialYearID : new Int16();
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.FinancialYearID = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.IsDeleted : false;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null && GeneralRunningNumbersForAccountDTO.CreatedBy > 0) ? GeneralRunningNumbersForAccountDTO.CreatedBy : new int();
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.DeletedBy : new int();
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.DeletedDate = value;
            }
        }

         [Display(Name = "DisplayName_FinancialYear", ResourceType = typeof(Resources))]
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_FinancialYear")]
        public string FinancialYear
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.FinancialYear : string.Empty;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.FinancialYear = value;
            }
        }
         public string XMLstring
        {
            get
            {
                return (GeneralRunningNumbersForAccountDTO != null) ? GeneralRunningNumbersForAccountDTO.XMLstring : string.Empty;
            }
            set
            {
                GeneralRunningNumbersForAccountDTO.XMLstring = value;
            }
        }
        public string errorMessage { get; set; }
       
        
    }
}

