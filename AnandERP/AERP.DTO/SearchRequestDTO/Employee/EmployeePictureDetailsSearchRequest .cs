using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeePictureDetailsSearchRequest : Request
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
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
