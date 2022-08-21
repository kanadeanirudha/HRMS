using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
  

    public class AccountBalancesheetMasterViewModel : IAccountBalancesheetMasterViewModel
    {

        public AccountBalancesheetMasterViewModel()
        {
            AccBalsheetMasterDTO = new AccountBalancesheetMaster();
            ListAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();

            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public AccountBalancesheetMaster AccBalsheetMasterDTO { get; set; }
        public List<AccountBalancesheetMaster> ListAccountBalancesheetMaster
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public string SelectedCentreCode
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public Int16 ID
        {
            get
            {
                return (AccBalsheetMasterDTO != null && AccBalsheetMasterDTO.ID > 0) ? AccBalsheetMasterDTO.ID : new Int16();
            }
            set
            {
                AccBalsheetMasterDTO.ID = value;
            }
        }

        [Display(Name = "Account Balancesheet Code")]
        [Required(ErrorMessage ="Account Balancesheet Code Required")]
        public string AccBalsheetCode
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.AccBalsheetCode : string.Empty;
            }
            set
            {
                AccBalsheetMasterDTO.AccBalsheetCode = value;
            }
        }

        [Display(Name = "Account Balancesheet Head Description")]
        [Required(ErrorMessage ="Account Balancesheet Head Description Required")]
        public string AccBalsheetHeadDesc
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.AccBalsheetHeadDesc : string.Empty;
            }
            set
            {
                AccBalsheetMasterDTO.AccBalsheetHeadDesc = value;
            }
        }

        [Display(Name = "Sheet Type ID")]
        public Nullable<byte> AccBalsheetTypeID
        {
            get
            {
                return (AccBalsheetMasterDTO != null && AccBalsheetMasterDTO.AccBalsheetTypeID > 0) ? AccBalsheetMasterDTO.AccBalsheetTypeID : new byte();
            }
            set
            {
                AccBalsheetMasterDTO.AccBalsheetTypeID = value;
            }
        }

        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                AccBalsheetMasterDTO.CentreCode = value;
            }
        }

        [Display(Name = "IsActive")]
        public Nullable<bool> IsActive
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.IsActive : false;
            }
            set
            {
                AccBalsheetMasterDTO.IsActive = value;
            }
        }

        public bool StatusFlag
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.StatusFlag : false;
            }
            set
            {
                AccBalsheetMasterDTO.StatusFlag = value;
            }
        }
        [Display(Name = "Created By")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccBalsheetMasterDTO != null && AccBalsheetMasterDTO.CreatedBy > 0) ? AccBalsheetMasterDTO.CreatedBy : new int();
            }
            set
            {
                AccBalsheetMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AccBalsheetMasterDTO.CreatedDate = value;
            }
        }

        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccBalsheetMasterDTO != null && AccBalsheetMasterDTO.ModifiedBy > 0) ? AccBalsheetMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AccBalsheetMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AccBalsheetMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccBalsheetMasterDTO != null && AccBalsheetMasterDTO.DeletedBy > 0) ? AccBalsheetMasterDTO.DeletedBy : new int();
            }
            set
            {
                AccBalsheetMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Deleted Date")]
        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AccBalsheetMasterDTO.DeletedDate = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.IsDeleted : false;
            }
            set
            {
                AccBalsheetMasterDTO.IsDeleted = value;
            }
        }


        public List<AccountBalancesheetTypeMaster> AccountBalancesheetTypeMasterDTO
        {
            get;
            set;
        }

        [Display(Name = "Account Balancesheet Type")]
        public string AccBalsheetTypeDesc
        {
            get
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.AccBalsheetTypeDesc : string.Empty;
            }
            set
            {
                AccBalsheetMasterDTO.AccBalsheetTypeDesc = value;
            }
        }

        [Display(Name = "Centre Name")]
        public string CentreName
        {
            get 
            {
                return (AccBalsheetMasterDTO != null) ? AccBalsheetMasterDTO.CentreName : string.Empty; 
            }
            set 
            { 
                AccBalsheetMasterDTO.CentreName = value; 
            }
        }
        public string CentreCodeWithName
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }

}
