using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AERP.DTO
{
    public class AccountSessionMaster : BaseDTO
    {
        public Int16 ID { get; set; }
        public string SessionStartDatetime { get; set; }
        public string SessionEndDatetime { get; set; }
        public string SessionName { get; set; }
        public bool DefaultFlag { get; set; }
        public string Account_System { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> OldSessionID { get; set; }
        public string errorMessage { get; set; }
        
        //For Year End Job
        //From and Upto Date For Current Date
        public string CurrenntSessionYearFromDatetime { get; set; }
        public string CurrenntSessionYearUptoDatetime { get; set; }
        //From and Upto Date For Next Date
        public string NextSessionYearFromDatetime { get; set; }
        public string NextSessionYearUptoDatetime { get; set; }

        public bool IsCarryForward { get; set; }
        public byte OutPutFlag { get; set; }

        public int CurrentYearSessionID { get; set; }
        public int NextYearSessionID { get; set; }
        public string CentreListXML { get; set; }

        public int AccBalsheetMasterID { get; set; }
        public string AccBalsheetHeadDesc { get; set; }

        public byte YearEndTypeFlag { get; set; }

    }
}
