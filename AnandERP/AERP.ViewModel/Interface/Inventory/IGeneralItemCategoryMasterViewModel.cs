using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralItemCategoryMasterViewModel
    {
        GeneralItemCategoryMaster GeneralItemCategoryMasterDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        string ItemCategoryDescription
        {
            get;
            set;
        }
        string ItemCategoryCode
        {
            get;
            set;
        }
        Int16 MarchandiseGroupID
        {
            get;
            set;
        }
        Int16 MerchandiseDepartmentID
        {
            get;
            set;
        }
        Int16 MerchandiseCategoryID
        {
            get;
            set;
        }
        Int16 MarchandiseSubCategoryID
        {
            get;
            set;
        }
        Int16 MarchandiseBaseCatgoryID
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
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
