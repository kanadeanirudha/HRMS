using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountBalancesheetMaster : BaseDTO
    {

        public AccountBalancesheetTypeMaster AccountBalancesheetTypeMasterDTO 
        { 
            get; 
            set; 
        }
        //public int ID
        //{
        //    get;
        //    set;
        //}

        //public string AccBalsheetCode 
        //{ 
        //    get;
        //    set; 
        //}
        //public string AccBalsheetHeadDesc 
        //{ 
        //    get; 
        //    set; 
        //}
        //public int AccBalsheetTypeID 
        //{ 
        //    get; 
        //    set; 
        //}
        //public string CentreCode 
        //{ 
        //    get; 
        //    set; 
        //}
        //public bool IsActive 
        //{ 
        //    get; 
        //    set; 
        //}
        //public int CreatedBy 
        //{ 
        //    get; 
        //    set; 
        //}
        //public DateTime CreatedDate 
        //{ 
        //    get; 
        //    set; 
        //}
        //public int ModifiedBy 
        //{ 
        //    get; 
        //    set; 
        //}
        //public DateTime ModifiedDate 
        //{ 
        //    get; 
        //    set; 
        //}
        //public int DeletedBy 
        //{ 
        //    get; 
        //    set; 
        //}
        //public DateTime DeletedDate 
        //{ 
        //    get; 
        //    set; 
        //}
        //public bool IsDeleted 
        //{ 
        //    get; 
        //    set; 
        //}


        public string AccBalsheetTypeDesc
        {
            get;
            set;
        }
        public Int16 ID
        {
            get;
            set;
        }
        public string AccBalsheetCode
        {
            get;
            set;
        }
        public string AccBalsheetHeadDesc
        {
            get;
            set;
        }
        public Nullable<byte> AccBalsheetTypeID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public bool StatusFlag { get; set; }
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
        public string CentreName { get; set; }
        // Property given below added for multiple select list used in Account Master Form
        public Int16 AccountID { get; set; }

        public string errorMessage { get; set; }


    }
}
