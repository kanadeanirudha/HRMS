using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;


namespace AERP.ViewModel
{
   public interface ICCRMLocationTypeMasterViewModel
    {
        CCRMLocationTypeMaster CCRMLocationTypeMasterDTO { get; set; }
        Int32 ID { get; set; }

        string LocationTypeCode { get; set; }
        byte LocationType { get; set; }
        string LocationTypeDesc { get; set; }
        decimal ResponseTime { get; set; }
        string ResponseUnit { get; set; }
        decimal CallCharges { get; set; }
        decimal Distance { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
