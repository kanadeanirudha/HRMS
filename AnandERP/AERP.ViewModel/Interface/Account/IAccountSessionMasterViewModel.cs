using AERP.DTO;
using System;

namespace AERP.ViewModel
{
    public interface IAccountSessionMasterViewModel
    {
        AccountSessionMaster AccountSessionMasterDTO
        {
            get;
            set;
        }
         Int16 ID { get; set; }
         string SessionStartDatetime { get; set; }
         string SessionEndDatetime { get; set; }
         bool DefaultFlag { get; set; }
         string Account_System { get; set; }
         bool IsActive { get; set; }
         Nullable<int> CreatedBy { get; set; }
         Nullable<System.DateTime> CreatedDate { get; set; }
         Nullable<int> ModifiedBy { get; set; }
         Nullable<System.DateTime> ModifiedDate { get; set; }
         Nullable<int> DeletedBy { get; set; }
         Nullable<System.DateTime> DeletedDate { get; set; }
         Nullable<bool> IsDeleted { get; set; }
         Nullable<int> OldSessionID { get; set; }
    }
}
