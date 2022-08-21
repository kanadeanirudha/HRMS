using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
   public interface ICCRMMachineMasterViewModel
    {
        CCRMMachineMaster CCRMMachineMasterDTO { get; set; }
        Int32 ID { get; set; }
        Int32 ItemNumber { get; set; }
        Int32 MachineFamilyMasterID { get; set; }
        byte MachineType { get; set; }
        byte ColorMono { get; set; }
        string PaperSize { get; set; }
        byte Warrenty { get; set; }
        decimal LifeInYears { get; set; }
        string lifeInCopies { get; set; }
        string PMPeriods { get; set; }
        bool Isreturnable { get; set; }
        byte Frequency { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
