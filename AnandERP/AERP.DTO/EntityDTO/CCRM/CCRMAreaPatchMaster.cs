using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;

namespace AERP.DTO
{
  public  class CCRMAreaPatchMaster :BaseDTO
    {
        public Int16 ID { get; set; }

        public string AreaPatchName { get; set; }
        public Int32 EmployeeMasterID { get; set; }
        public Int32 CCRMEngineersGroupMasterID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string errorMessage { get; set; }
        public string EmployeeName { get; set; }
        public string GroupName { get; set; }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeMiddleName
        {
            get;
            set;
        }
        public string EmployeeLastName
        {
            get;
            set;
        }
    }
}
