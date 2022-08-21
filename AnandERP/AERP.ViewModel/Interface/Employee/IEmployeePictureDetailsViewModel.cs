using AERP.DTO;
using System;
using System.Collections.Generic;


namespace AERP.ViewModel
{
    public interface IEmployeePictureDetailsViewModel
    {

        EmployeePictureDetails EmployeePictureDetailsDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        int EmployeeID
        {
            get;
            set;
        }
        byte[] EmployeePicture
        {
            get;
            set;
        }
        string EmployeePicFilename
        {
            get;
            set;
        }
        string EmployeePicType
        {
            get;
            set;
        }
        string EmployeePicFileSize
        {
            get;
            set;
        }
        string EmployeePicFileWidth
        {
            get;
            set;
        }
        string EmployeePicFileHeight
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
