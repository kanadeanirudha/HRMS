using AMS.DTO;
using System;

namespace AMS.ViewModel
{
  public  interface IGeneralSessionMasterViewModel
    {
        GeneralSessionMaster GeneralSessionMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string SessionName
        {
            get;
            set;
        }
        int SessionFrom
        {
            get;
            set;
        }
        int SessionUpto
        {
            get;
            set;
        }

        int SessionOrder
        {
            get;
            set;
        }

        bool CurrentFlag
        {
            get;
            set;
        }

        bool LockFlag
        {
            get;
            set;
        }  

        bool IsDeleted
        {
            get;
            set;
        }

        int CreatedBy
        {
            get;
            set;
        }

        DateTime CreatedDate
        {
            get;
            set;
        }

        int? ModifiedBy
        {
            get;
            set;
        }

        DateTime? ModifiedDate
        {
            get;
            set;
        }

        int? DeletedBy
        {
            get;
            set;
        }

        DateTime? DeletedDate
        {
            get;
            set;
        }
    }
}
