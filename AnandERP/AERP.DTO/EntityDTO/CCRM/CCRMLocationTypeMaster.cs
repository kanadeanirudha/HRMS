using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;

namespace AERP.DTO
{
   public class CCRMLocationTypeMaster :BaseDTO
    {
        public Int32 ID { get; set; }

        public string LocationTypeCode { get; set; }
        public byte LocationType { get; set; }
        public string LocationTypeDesc { get; set; }
        public decimal ResponseTime { get; set; }
        public string ResponseUnit { get; set; }
        public decimal CallCharges { get; set; }
        public decimal Distance { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
    }
}
