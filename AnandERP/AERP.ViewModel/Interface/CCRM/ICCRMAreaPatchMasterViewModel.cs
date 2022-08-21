using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;


namespace AERP.ViewModel
{
   public interface ICCRMAreaPatchMasterViewModel
    {
        CCRMAreaPatchMaster CCRMAreaPatchMasterDTO { get; set; }
        Int16 ID { get; set; }

        string AreaPatchName { get; set; }
        Int32 EmployeeMasterID { get; set; }
        Int32 CCRMEngineersGroupMasterID { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
