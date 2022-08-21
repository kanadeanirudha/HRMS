using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountGroupMasterReport : BaseDTO
    {
       
        public Int16 ID
        {
            get;
            set;
        }
     
        public string GroupCode
        {
            get;
            set;
        }
        public string HeadName
        {
            get;
            set;
        }
        public string GroupDescription
        {
            get;
            set;
        }
        public string CategoryDescription
        {
            get;
            set;
        }
        public Nullable<Int16> CategoryID
        {
            get;
            set;
        }
        public string BackDatedEntriesFlag
        {
            get;
            set;
        }
        public Nullable<Int16> PrintingSequence
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
        public string GroupDescriptionCategory
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
