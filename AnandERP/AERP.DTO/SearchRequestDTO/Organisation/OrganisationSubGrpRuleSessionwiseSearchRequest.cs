using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSubGrpRuleSessionwiseSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int SubjectRuleGrpNumber
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public int CourseYearSemesterID
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
