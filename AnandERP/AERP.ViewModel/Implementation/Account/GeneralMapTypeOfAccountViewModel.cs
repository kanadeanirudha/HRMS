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

    public class GeneralMapTypeOfAccountViewModel : IGeneralMapTypeOfAccountViewModel
    {
        public GeneralMapTypeOfAccountViewModel()
        {
            GeneralMapTypeOfAccountDTO = new GeneralMapTypeOfAccount();
            GeneralMapTypeOfAccountListForAccountType = new List<GeneralTypeOfAccount>();
        }

        public GeneralMapTypeOfAccount GeneralMapTypeOfAccountDTO { get; set; }
        public List<GeneralTypeOfAccount> GeneralMapTypeOfAccountListForAccountType { get; set; }
        public List<GeneralTaskReportingDetails> UserModuleList
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListUserModuleMaster
        {
            get
            {
                return new SelectList(UserModuleList, "ModuleCode", "ModuleName");
            }
        }

        public List<UserMainMenuMaster> ListUserMenuMaster
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetUserMenuName
        {
            get
            {
                return new SelectList(ListUserMenuMaster, "MenuCode", "MenuName");
            }
        }



        public Int32 ID
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null && GeneralMapTypeOfAccountDTO.ID > 0) ? GeneralMapTypeOfAccountDTO.ID : new Int32();
            }
            set
            {
                GeneralMapTypeOfAccountDTO.ID = value;
            }
        }
        public Int16 GeneralTypeOfAccountId
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null && GeneralMapTypeOfAccountDTO.GeneralTypeOfAccountId > 0) ? GeneralMapTypeOfAccountDTO.GeneralTypeOfAccountId : new Int16();
            }
            set
            {
                GeneralMapTypeOfAccountDTO.GeneralTypeOfAccountId = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.XMLstring : string.Empty;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.XMLstring = value;
            }
        }
        public string MenuCode
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.MenuCode : string.Empty;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.MenuCode = value;
            }
        }
        [Display(Name = "Module")]
        public string ModuleName
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.ModuleName : string.Empty;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.ModuleName = value;
            }
        }

        [Display(Name = "Account Name")]
        public string AccName
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.AccName : string.Empty;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.AccName = value;
            }
        }
        [Display(Name = "Menu")]
        public string MenuName
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.MenuName : string.Empty;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.MenuName = value;
            }
        }
        public string ControlName
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.ControlName : string.Empty;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.ControlName = value;
            }
        }
        [Display(Name = "Debit/Credit")]
        public byte DebitCreditStatus
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.DebitCreditStatus : new byte();
            }
            set
            {
                GeneralMapTypeOfAccountDTO.DebitCreditStatus = value;
            }
        }
        public int UserMainMenuMasterID
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null && GeneralMapTypeOfAccountDTO.UserMainMenuMasterID > 0) ? GeneralMapTypeOfAccountDTO.UserMainMenuMasterID : new int();
            }
            set
            {
                GeneralMapTypeOfAccountDTO.UserMainMenuMasterID = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.IsDeleted : false;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null && GeneralMapTypeOfAccountDTO.CreatedBy > 0) ? GeneralMapTypeOfAccountDTO.CreatedBy : new int();
            }
            set
            {
                GeneralMapTypeOfAccountDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralMapTypeOfAccountDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.DeletedBy : new int();
            }
            set
            {
                GeneralMapTypeOfAccountDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralMapTypeOfAccountDTO != null) ? GeneralMapTypeOfAccountDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralMapTypeOfAccountDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

      
    }
}
