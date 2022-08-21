using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
 
    public class GeneralSessionMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int SessionFrom
        {
            get;
            set;
        }
        public int SessionUpto
        {
            get;
            set;
        }

        public int SessionOrder
        {
            get;
            set;
        }

        public string SessionName
        {
            get;
            set;
        }

        public bool CurrentFlag
        {
            get;
            set;
        }

        public bool LockFlag
        {
            get;
            set;
        }        

        public bool IsDeleted
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int? ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int? DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string ActionMode { get; set; }
        public string errorMessage { get; set; }

    }
}
