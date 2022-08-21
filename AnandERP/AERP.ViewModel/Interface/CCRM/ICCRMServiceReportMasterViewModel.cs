using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
  public  interface ICCRMServiceReportMasterViewModel
    {
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
