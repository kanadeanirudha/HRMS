using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAccountBalancesheetMasterViewModel
    {
        AccountBalancesheetMaster AccBalsheetMasterDTO { get; set; }
        List<AccountBalancesheetTypeMaster> AccountBalancesheetTypeMasterDTO { get; set; }
        Int16 ID { get; set; }
        string AccBalsheetCode { get; set; }
        string AccBalsheetHeadDesc { get; set; }
        Nullable<byte> AccBalsheetTypeID { get; set; }
        string CentreCode { get; set; }
        bool StatusFlag { get; set; }
        Nullable<bool> IsActive { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        string AccBalsheetTypeDesc { get; set; }
        string CentreName { get; set; }
    }

    public interface IAccountBalancesheetMasterBaseViewModel
    {
        List<AccountBalancesheetMaster> ListAccountBalancesheetMaster
        {
            get;
            set;
        }

        List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
        {
            get;
            set;
        }
    }
}
