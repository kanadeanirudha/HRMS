using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AccountCategoryMasterReportViewModel
    {

        public AccountCategoryMasterReportViewModel()
        {
            AccountCategoryMasterReportDTO = new AccountCategoryMasterReport();
            ListAccountHeadMasterReport = new List<AccountHeadMasterReport>();
            ListAccountCategoryMasterReport = new List<AccountCategoryMasterReport>();
        }

        public List<AccountHeadMasterReport> ListAccountHeadMasterReport { get; set; }

        public List<AccountCategoryMasterReport> ListAccountCategoryMasterReport { get; set; }

        [Display(Name = "Head")]
        public string SelectedHeadID { get; set; }

        [Display(Name = "Category")]
        public string SelectedCategoryID { get; set; }

        public IEnumerable<SelectListItem> AccountHeadMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountHeadMasterReport, "ID", "HeadName");
            }
        }

        public IEnumerable<SelectListItem> AccountCategoryMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountCategoryMasterReport, "ID", "CategoryDescription");
            }
        }

        public AccountCategoryMasterReport AccountCategoryMasterReportDTO { get; set; }

        public Int16 ID
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null && AccountCategoryMasterReportDTO.ID > 0) ? AccountCategoryMasterReportDTO.ID : new Int16();
            }
            set
            {
                AccountCategoryMasterReportDTO.ID = value;
            }
        }

        [Display(Name = "Category Code")]
        public string CategoryCode
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.CategoryCode : string.Empty;
            }
            set
            {
                AccountCategoryMasterReportDTO.CategoryCode = value;
            }
        }

        [Display(Name = "Category Description")]
        [Required(ErrorMessage ="Category Description Required")]
        public string CategoryDescription
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.CategoryDescription : string.Empty;
            }
            set
            {
                AccountCategoryMasterReportDTO.CategoryDescription = value;
            }
        }
        public int AccountBalsheetMstID
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.AccountBalsheetMstID : new int();
            }
            set
            {
                AccountCategoryMasterReportDTO.AccountBalsheetMstID = value;
            }
        }
        public string CategoryDescriptionHead
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.CategoryDescriptionHead : string.Empty;
            }
            set
            {
                AccountCategoryMasterReportDTO.CategoryDescriptionHead = value;
            }
        }

        public string HeadName
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.HeadName : string.Empty;
            }
            set
            {
                AccountCategoryMasterReportDTO.HeadName = value;
            }
        }

        [Display(Name = "Head")]
        public Nullable<byte> HeadID
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null && AccountCategoryMasterReportDTO.HeadID > 0) ? AccountCategoryMasterReportDTO.HeadID : new byte();
            }
            set
            {
                AccountCategoryMasterReportDTO.HeadID = value;
            }
        }

        [Display(Name = "Printing Sequence")]
        public Nullable<Int16> PrintingSequence
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null && AccountCategoryMasterReportDTO.PrintingSequence > 0) ? AccountCategoryMasterReportDTO.PrintingSequence : new Int16();
            }
            set
            {
                AccountCategoryMasterReportDTO.PrintingSequence = value;
            }
        }

        public Nullable<bool> IsActive
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.IsActive : false;
            }
            set
            {
                AccountCategoryMasterReportDTO.IsActive = value;
            }
        }
        public int AccBalsheetMstId
        {
            get { return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.AccBalsheetMstId : new int(); }
            set { AccountCategoryMasterReportDTO.AccBalsheetMstId = value; }
        }
        public string AccBalsheetName
        {
            get { return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.AccBalsheetName : string.Empty; }
            set { AccountCategoryMasterReportDTO.AccBalsheetName = value; }
        }
        public bool IsPosted
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.IsPosted : false;
            }
            set
            {
                AccountCategoryMasterReportDTO.IsPosted = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null && AccountCategoryMasterReportDTO.CreatedBy > 0) ? AccountCategoryMasterReportDTO.CreatedBy : new int();
            }
            set
            {
                AccountCategoryMasterReportDTO.CreatedBy = value;
            }
        }


        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.CreatedDate : null;
            }
            set
            {
                AccountCategoryMasterReportDTO.CreatedDate = value;
            }
        }


        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null && AccountCategoryMasterReportDTO.ModifiedBy > 0) ? AccountCategoryMasterReportDTO.ModifiedBy : new int();
            }
            set
            {
                AccountCategoryMasterReportDTO.ModifiedBy = value;
            }
        }


        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.ModifiedDate : null;
            }
            set
            {
                AccountCategoryMasterReportDTO.ModifiedDate = value;
            }
        }

        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null && AccountCategoryMasterReportDTO.DeletedBy > 0) ? AccountCategoryMasterReportDTO.DeletedBy : new int();
            }
            set
            {
                AccountCategoryMasterReportDTO.DeletedBy = value;
            }
        }


        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.DeletedDate : null;
            }
            set
            {
                AccountCategoryMasterReportDTO.DeletedDate = value;
            }
        }

        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountCategoryMasterReportDTO != null) ? AccountCategoryMasterReportDTO.IsDeleted : false;
            }
            set
            {
                AccountCategoryMasterReportDTO.IsDeleted = value;
            }
        }

        
    }
}
