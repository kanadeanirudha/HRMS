using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{


    public interface IAccountCategoryMasterReportViewModel
    {
        AccountCategoryMasterReport AccountCategoryMasterReportDTO { get; set; }
        Int16 ID 
        { 
            get; 
            set; 
        }
        string CategoryCode
        {
            get;
            set;
        }
        string CategoryDescription
        {
            get;
            set;
        }
        string CategoryDescriptionHead
        {
            get;
            set;
        }
        Nullable<byte> HeadID
        {
            get;
            set;
        }
        Nullable<Int16> PrintingSequence
        {
            get;
            set;
        }
        Nullable<bool> IsActive
        {
            get;
            set;
        }
        Nullable<int> CreatedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> CreatedDate
        {
            get;
            set;
        }
        Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> ModifiedDate
        {
            get;
            set;
        }
        Nullable<int> DeletedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> DeletedDate
        {
            get;
            set;
        }
        Nullable<bool> IsDeleted
        {
            get;
            set;
        }
    }
}
