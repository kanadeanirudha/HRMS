using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IAccountBalanceSheetMasterModel
    {
        AccountBalancesheetMaster AccBalsheetMasterDTO { get; set; }
        List<AccountBalancesheetTypeMaster> AccountBalancesheetTypeMasterDTO { get; set; }
        int ID { get; set; }
        string AccBalsheetCode { get; set; }
        string AccBalsheetHeadDesc { get; set; }
        Nullable<int> AccBalsheetTypeID { get; set; }
        string CentreCode { get; set; }
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
