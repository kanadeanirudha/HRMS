using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
  public  interface ICCRMServiceMasterViewModel
    {
        CCRMServiceMaster CCRMServiceMasterDTO { get; set; }
        Int32 ID { get; set; }

        string ServiceDetails { get; set; }
        string ServiceDescription { get; set; }
        decimal CallCharges { get; set; }
        byte ServiceType { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
