using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationDepartmentBranchSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public string Remark
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
    }
}
