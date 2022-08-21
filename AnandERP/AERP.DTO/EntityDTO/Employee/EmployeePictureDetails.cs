using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeePictureDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public byte[] EmployeePicture
        {
            get;
            set;
        }
        public string EmployeePicFilename
        {
            get;
            set;
        }
        public string EmployeePicType
        {
            get;
            set;
        }
        public string EmployeePicFileSize
        {
            get;
            set;
        }
        public string EmployeePicFileWidth
        {
            get;
            set;
        }
        public string EmployeePicFileHeight
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
        public string errorMessage { get; set; }
    }
}
