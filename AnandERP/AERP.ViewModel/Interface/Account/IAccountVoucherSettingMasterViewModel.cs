using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IAccountVoucherSettingMasterViewModel
    {
        AccountVoucherSettingMaster AccountVoucherSettingMasterDTO { get; set; }
        int ID { get; set; }
        Nullable<int> AccSessionID { get; set; }
        string TransactionType { get; set; }
        string TransactionTypeCode { get; set; }
        Nullable<int> VoucherNumber { get; set; }
        Nullable<int> AccBalsheetMstID { get; set; }
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
