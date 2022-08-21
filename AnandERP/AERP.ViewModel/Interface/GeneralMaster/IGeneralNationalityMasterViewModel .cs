using AERP.DTO;
using System;
namespace AERP.ViewModel
{
    public interface IGeneralNationalityMasterViewModel
    {
        GeneralNationalityMaster GeneralNationalityMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }

        bool DefaultFlag
        {
            get;
            set;
        }
        bool IsUserDefined
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
