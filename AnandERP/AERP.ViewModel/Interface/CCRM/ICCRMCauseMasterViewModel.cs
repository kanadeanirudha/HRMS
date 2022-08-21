using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
   public interface ICCRMCauseMasterViewModel
    {
        CCRMCauseMaster CCRMCauseMasterDTO
        {
            get;
            set;
        }
        Int32 ID { get; set; }
        string CauseTypeTitle { get; set; }
        string CauseTypeCode { get; set; }
        string CauseTypeDescription { get; set; }
        Int32 CCRMCauseMasterID { get; set; }
        string CauseTitle { get; set; }
        string CauseCode { get; set; }
        string CauseDescription { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
        string errorMessage { get; set; }
    }
}
