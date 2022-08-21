using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
   public interface ICCRMSymptomMasterViewModel
    {
        CCRMSymptomMaster CCRMSymptomMasterDTO
        {
            get;
            set;
        }
        Int32 ID { get; set; }
        string SymptomTypeTitle { get; set; }
        string SymptomTypeCode { get; set; }
        string SymptomTypeDescription { get; set; }
        Int32 CCRMSymptomMasterID { get; set; }
        string SymptomTitle { get; set; }
        string SymptomCode { get; set; }
        string SymptomDescription { get; set; }
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
