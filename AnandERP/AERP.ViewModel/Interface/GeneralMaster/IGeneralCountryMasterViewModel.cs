using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralCountryMasterViewModel
    {
        GeneralCountryMaster GeneralCountryMasterDTO
        {
            get;
            set;
        }
         int ID { get; set; }
         string CountryName { get; set; }
         string ContryCode { get; set; }
         bool DefaultFlag { get; set; }
         bool IsUserDefined { get; set; }
         Nullable<int> SeqNo { get; set; }
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
