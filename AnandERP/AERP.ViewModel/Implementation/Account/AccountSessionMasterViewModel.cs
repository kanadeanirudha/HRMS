using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
    public class AccountSessionMasterViewModel : IAccountSessionMasterViewModel
    {
        public AccountSessionMasterViewModel()
       {
           AccountSessionMasterDTO = new AccountSessionMaster();
            GetBalncesheetList = new List<AccountSessionMaster>();
        }
        public List<AccountSessionMaster> GetBalncesheetList { get; set; }

        public IEnumerable<SelectListItem> GetBalncesheetListDetails
        {
            get
            {
                return new SelectList(GetBalncesheetList, "AccBalsheetMasterID", "AccBalsheetHeadDesc");
            }
        }
        public AccountSessionMaster AccountSessionMasterDTO { get; set; }
        public Int16 ID
        {
            get
            {
                return (AccountSessionMasterDTO != null && AccountSessionMasterDTO.ID > 0) ? AccountSessionMasterDTO.ID : new Int16();
            }
            set
            {
                AccountSessionMasterDTO.ID = value;
            }
        }

        [Display(Name = "Session Start Date")]
        [Required(ErrorMessage ="Session Start Date Required")]
        public string SessionStartDatetime
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.SessionStartDatetime : string.Empty;
            }
            set
            {
                AccountSessionMasterDTO.SessionStartDatetime = value;
            }
        }

        [Display(Name = "Session End Date")]
        [Required(ErrorMessage ="Session End Date Required")]
        public string SessionEndDatetime
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.SessionEndDatetime : string.Empty;
            }
            set
            {
                AccountSessionMasterDTO.SessionEndDatetime = value;
            }
        }
        public bool DefaultFlag
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.DefaultFlag : false;
            }
            set
            {
                AccountSessionMasterDTO.DefaultFlag = value;
            }
        }

        [Display(Name = "Account System")]
        public string Account_System
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.Account_System : string.Empty;
            }
            set
            {
                AccountSessionMasterDTO.Account_System = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.IsActive : false;
            }
            set
            {
                AccountSessionMasterDTO.IsActive = value;
            }
        }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> OldSessionID { get; set; }

        //for YEAR END jOB
        //From and Upto Date For Next Date
        public string NextSessionYearFromDatetime
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.NextSessionYearFromDatetime : string.Empty;
            }
            set
            {
                AccountSessionMasterDTO.NextSessionYearFromDatetime = value;
            }
        }
        public string NextSessionYearUptoDatetime
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.NextSessionYearUptoDatetime : string.Empty;
            }
            set
            {
                AccountSessionMasterDTO.NextSessionYearUptoDatetime = value;
            }
        }
        //From and Upto Date For Current Date
        public string CurrenntSessionYearFromDatetime
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.CurrenntSessionYearFromDatetime : string.Empty;
            }
            set
            {
                AccountSessionMasterDTO.CurrenntSessionYearFromDatetime = value;
            }
        }
        public string CurrenntSessionYearUptoDatetime
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.CurrenntSessionYearUptoDatetime : string.Empty;
            }
            set
            {
                AccountSessionMasterDTO.CurrenntSessionYearUptoDatetime = value;
            }
        }
        public bool IsCarryForward
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.IsCarryForward : false;
            }
            set
            {
                AccountSessionMasterDTO.IsCarryForward = value;
            }
        }
        public string CentreListXML
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.CentreListXML : string.Empty;
            }
            set
            {
                AccountSessionMasterDTO.CentreListXML = value;
            }
        }
        public byte OutPutFlag
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.OutPutFlag : new byte();
            }
            set
            {
                AccountSessionMasterDTO.OutPutFlag = value;
            }
        }
        public int CurrentYearSessionID
        {
            get
            {
                return (AccountSessionMasterDTO != null && AccountSessionMasterDTO.CurrentYearSessionID > 0) ? AccountSessionMasterDTO.CurrentYearSessionID : new int();
            }
            set
            {
                AccountSessionMasterDTO.CurrentYearSessionID = value;
            }
        }
        public int NextYearSessionID
        {
            get
            {
                return (AccountSessionMasterDTO != null && AccountSessionMasterDTO.NextYearSessionID > 0) ? AccountSessionMasterDTO.NextYearSessionID : new int();
            }
            set
            {
                AccountSessionMasterDTO.NextYearSessionID = value;
            }
        }
        public byte YearEndTypeFlag
        {
            get
            {
                return (AccountSessionMasterDTO != null) ? AccountSessionMasterDTO.YearEndTypeFlag : new byte();
            }
            set
            {
                AccountSessionMasterDTO.YearEndTypeFlag = value;
            }
        }

    }
}
