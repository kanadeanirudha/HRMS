using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;


namespace AERP.DTO
{
   public class CCRMMachineMaster :BaseDTO
    {
        public Int32 ID { get; set; }
        public Int32 ItemNumber { get; set; }
        public Int32 MachineFamilyMasterID { get; set; }
        public byte MachineType { get; set; }
        public byte ColorMono { get; set; }
        public string PaperSize { get; set; }
        public byte Warrenty { get; set; }
        public decimal LifeInYears { get; set; }
        public string lifeInCopies { get; set; }
        public string PMPeriods { get; set; }
        public bool Isreturnable { get; set; }
        public byte Frequency { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public string ItemDescription { get; set; }
        public string MachineFamilyName { get; set; }
    }
}
