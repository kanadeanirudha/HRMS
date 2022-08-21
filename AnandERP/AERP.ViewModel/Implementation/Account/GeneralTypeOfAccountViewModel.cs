using AERP.Common;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public class GeneralTypeOfAccountViewModel : IGeneralTypeOfAccountViewModel
    {
        public GeneralTypeOfAccountViewModel()
        {
            GeneralTypeOfAccountDTO = new GeneralTypeOfAccount();
            NameList = new List <GeneralTypeOfAccount>();

        }
         public List<GeneralTypeOfAccount> NameList { get; set; }
         public IEnumerable<SelectListItem> NameListItems { get { return new SelectList(NameList, "Code", "Name"); } }
      
        
     
        public GeneralTypeOfAccount GeneralTypeOfAccountDTO { get; set; }
        public Int16 ID
        {
            get {
                return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.ID > 0) ? GeneralTypeOfAccountDTO.ID : new Int16();
                }
            set { GeneralTypeOfAccountDTO.ID = value; }
        }

        //public Int16 GeneralTypeOfAccountID
        //{
        //    get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.GeneralTypeOfAccountID > 0) ? GeneralTypeOfAccountDTO.GeneralTypeOfAccountID : new Int16(); }
        //    set { GeneralTypeOfAccountDTO.GeneralTypeOfAccountID = value; }
        //}
       
        [Display(Name ="Account Type")]
        //[Required(ErrorMessage = "Account Type Should not Be Blank")]
        public String Name
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.Name != null) ? GeneralTypeOfAccountDTO.Name : String.Empty; }
            set { GeneralTypeOfAccountDTO.Name = value; }
        }

     
        public String DisplayFor
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.DisplayFor != null) ? GeneralTypeOfAccountDTO.DisplayFor : String.Empty; }
            set { GeneralTypeOfAccountDTO.DisplayFor = value; }
        }

        [Required(ErrorMessage = "Account Type Should not Be Blank")]
        public String AccountCode
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.AccountCode != null) ? GeneralTypeOfAccountDTO.AccountCode : String.Empty; }
            set { GeneralTypeOfAccountDTO.AccountCode = value; }
        }
        public bool IsActive
        {
            get { return (GeneralTypeOfAccountDTO != null) ? GeneralTypeOfAccountDTO.IsActive : false; }
            set { GeneralTypeOfAccountDTO.IsActive = value; }
        }

        //General Type Of Account Map with Account 
        public Int32 GeneralTypeOfAccountMapWithAccountID
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.GeneralTypeOfAccountMapWithAccountID > 0) ? GeneralTypeOfAccountDTO.GeneralTypeOfAccountMapWithAccountID : new Int32(); }
            set { GeneralTypeOfAccountDTO.GeneralTypeOfAccountMapWithAccountID = value; }
        }
        public Int16 GeneralTypeOfAccountId
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.GeneralTypeOfAccountId > 0) ? GeneralTypeOfAccountDTO.GeneralTypeOfAccountId : new Int16(); }
            set { GeneralTypeOfAccountDTO.GeneralTypeOfAccountId = value; }
        }
        public Int16 AccountMasterId
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.AccountMasterId > 0) ? GeneralTypeOfAccountDTO.AccountMasterId : new Int16(); }
            set { GeneralTypeOfAccountDTO.AccountMasterId = value; }
        }
          [Display(Name = "Accounts")]
        public string AccountName
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.AccountName != null) ? GeneralTypeOfAccountDTO.AccountName : string.Empty; }
            set { GeneralTypeOfAccountDTO.AccountName = value; }
        }

        public Int32 CreatedBy
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.CreatedBy > 0) ? GeneralTypeOfAccountDTO.CreatedBy : new Int32(); }
            set { GeneralTypeOfAccountDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.CreatedDate != null) ? GeneralTypeOfAccountDTO.CreatedDate : String.Empty; }
            set { GeneralTypeOfAccountDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.ModifiedBy > 0) ? GeneralTypeOfAccountDTO.ModifiedBy : new Int32(); }
            set { GeneralTypeOfAccountDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.ModifiedDate != null) ? GeneralTypeOfAccountDTO.ModifiedDate : String.Empty; }
            set { GeneralTypeOfAccountDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.DeletedBy > 0) ? GeneralTypeOfAccountDTO.DeletedBy : new Int32(); }
            set { GeneralTypeOfAccountDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (GeneralTypeOfAccountDTO != null && GeneralTypeOfAccountDTO.DeletedDate != null) ? GeneralTypeOfAccountDTO.DeletedDate : String.Empty; }
            set { GeneralTypeOfAccountDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (GeneralTypeOfAccountDTO != null) ? GeneralTypeOfAccountDTO.IsDeleted : false; }
            set { GeneralTypeOfAccountDTO.IsDeleted = value; }
        }
    }
}
