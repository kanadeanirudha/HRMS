using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAccountHeadMasterViewModel
    {
        AccountHeadMaster AccountHeadMasterDTO { get; set; }
        byte ID { get; set; }
        string HeadCode { get; set; }
        string HeadName { get; set; }
        Nullable<int> PrintingSequence { get; set; }
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
