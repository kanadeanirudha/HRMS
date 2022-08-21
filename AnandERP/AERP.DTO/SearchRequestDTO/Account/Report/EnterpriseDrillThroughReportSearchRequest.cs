using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EnterpriseDrillThroughReportSearchRequest : Request
    {
        public int DepartmentID
        {
            get;
            set;
        }
        public string EmployeeCode
        {
            get;
            set;
        }
        public string CentreCode
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
        public string MrOrMrs
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
    }
}
