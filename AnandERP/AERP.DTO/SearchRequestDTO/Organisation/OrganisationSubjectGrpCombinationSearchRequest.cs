using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSubjectGrpCombinationSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int SubjectGroupID
        {
            get;
            set;
        }
        public Int16 SubjectTypeNumber
        {
            get;
            set;
        }
        public string ActiveFlag
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
