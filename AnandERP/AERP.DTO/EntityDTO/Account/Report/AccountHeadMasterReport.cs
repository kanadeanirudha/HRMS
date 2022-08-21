using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DTO
{
    public class AccountHeadMasterReport: BaseDTO
    {

        public byte ID
        {
            get;
            set;
        }
        public string HeadCode
        {
            get;
            set;
        }
        public int AccBalsheetMstID
        {
            get;
            set;
        }
        public string HeadName
        {
            get;
            set;
        }
        public Nullable<int> PrintingSequence
        {
            get;
            set;
        }
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
        public bool IsPosted { get; set; }
    }
}
