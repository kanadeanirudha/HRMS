using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountCategoryMasterReport : BaseDTO
    {
        

        public Int16 ID
        {
            get;
            set;
        }
        public string CategoryCode
        {
            get;
            set;
        }
        public string CategoryDescription
        {
            get;
            set;
        }
        public string HeadName { get; set; }
        public int AccountBalsheetMstID { get; set; }
        
        public Nullable<byte> HeadID
        {
            get;
            set;
        }
        public Nullable<Int16> PrintingSequence
        {
            get;
            set;
        }
        public int AccBalsheetMstId
        {
            get;
            set;
        }
        public string AccBalsheetName { get; set; }
        public bool IsPosted { get; set; }
        public Nullable<bool> IsActive
        {
            get;
            set;
        }
        public Nullable<int> CreatedBy
        {
            get;
            set;
        }
        public Nullable<System.DateTime> CreatedDate
        {
            get;
            set;
        }
        public Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        public Nullable<System.DateTime> ModifiedDate
        {
            get;
            set;
        }
        public Nullable<int> DeletedBy
        {
            get;
            set;
        }
        public Nullable<System.DateTime> DeletedDate
        {
            get;
            set;
        }
        public Nullable<bool> IsDeleted
        {
            get;
            set;
        }
        public string ReportingRoot
        {
            get;
            set;
        }
        public string CategoryDescriptionHead
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
