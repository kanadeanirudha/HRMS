using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DTO
{
    public class GeneralGroupMaster : BaseDTO
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
        public string GroupDependentObject
        {
            get;
            set;
        }
        public int JobProfileID
        {
            get;
            set;
        }
        public string JobProfileDescription
        {
            get;
            set;
        }        
        public bool IsActive
        {
            get;
            set;
        }
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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }

        public string ErrorMessage { get; set; }


        #region ----------------EmployeeGroupDetails-----------------

        public int EmployeeGroupDetailsID
        {
            get;
            set;
        }
        public int DependentObjectID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public string Department 
        {
            get;
            set;
        }       
        public string Designation
        {
            get;
            set;
        }
        public string PayScale
        {
            get;
            set;
        }
        #endregion
    }
}
