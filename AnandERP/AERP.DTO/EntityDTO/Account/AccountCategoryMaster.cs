using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountCategoryMaster : BaseDTO
    {
        //public int ID
        //{
        //    get;
        //    set;
        //}
        //public string CategoryCode
        //{
        //    get;
        //    set;
        //}

        //public string CategoryDescription
        //{
        //    get;
        //    set;
        //}

        //public int HeadID
        //{
        //    get;
        //    set;
        //}

        //public int PrintingSequence
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
        
        
        public Nullable<byte> HeadID
        {
            get;
            set;
        }
        public string HeadName
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
        public string CategoryDescriptionHead
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
