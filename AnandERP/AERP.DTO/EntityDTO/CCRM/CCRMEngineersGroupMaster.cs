using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class CCRMEngineersGroupMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string GroupName
        {
            get;
            set;
        }
        public int CCRMEngineersGroupDetailsID { get; set; }
        public Int32 CCRMEngineersGroupMasterID { get; set; }
        public int EmployeeMasterID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
