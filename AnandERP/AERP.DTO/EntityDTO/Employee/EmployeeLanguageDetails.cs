using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeLanguageDetails : BaseDTO
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
        public int LanguageID
        {
            get;
            set;
        }
        public string LanguageName
        {
            get;
            set;
        }
        public string CanRead
        {
            get;
            set;
        }
        public string CanWrite
        {
            get;
            set;
        }
        public string CanSpeak
        {
            get;
            set;
        }
        public string SelectedIDs
        {
            get;
            set;
        }
        //public string Fluency
        //{
        //    get;
        //    set;
        //}
        //public string Competency
        //{
        //    get;
        //    set;
        //}
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

        public string EmployeeName { get; set; }

        public string EmployeeCode { get; set; }
    }
}
