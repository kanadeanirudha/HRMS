using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class OrganisationCentrewiseDepartmentSearchRequest : Request
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
        public string CentreCode
        {
            get;
            set;
        }
        public bool ActiveFlag
        {
            get;
            set;
        }
        public int DepartmentSeqNo
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
