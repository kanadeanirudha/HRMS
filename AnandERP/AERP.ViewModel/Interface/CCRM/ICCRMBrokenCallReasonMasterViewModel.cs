using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
  public  interface ICCRMBrokenCallReasonMasterViewModel
    {
        CCRMBrokenCallReasonMaster CCRMBrokenCallReasonMasterDTO { get; set; }
        byte ID { get; set; }

        string ReasonCode { get; set; }
        string ReasonDescription { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
