using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IGeneralCategoryMasterViewModel
    {
        GeneralCategoryMaster GeneralCategoryMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string CategoryName
        {
            get;
            set;
        }

        string CategoryCode
        {
            get;
            set;
        }

        string CategoryType
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
