using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EnterpriseDrillThroughReport : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string EmployeeCode
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }
        public string OtherEmailID
        {
            get;
            set;
        }
        public string NameTitle
        {
            get;
            set;
        }
        public string EmployeeFullName
        {
            get;
            set;
        }
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
        public int DepartmentID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }  
        public string errorMessage
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public string custom1
        {
            get;
            set;
        }
        public string custom2
        {
            get;
            set;
        }        
    }
}
