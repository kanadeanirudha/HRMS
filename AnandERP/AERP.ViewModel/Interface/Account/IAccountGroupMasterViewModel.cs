using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAccountGroupMasterViewModel
    {
        AccountGroupMaster AccountGroupMasterDTO { get; set; }
        Int16 ID { get; set; }
        string GroupCode { get; set; }
        string GroupDescription { get; set; }
        string GroupDescriptionCategory { get; set; }
        Nullable<Int16> CategoryID { get; set; }
        string BackDatedEntriesFlag { get; set; }
        Nullable<Int16> PrintingSequence { get; set; }
        Nullable<bool> IsActive { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
        Nullable<bool> IsDeleted { get; set; }
    }
}
