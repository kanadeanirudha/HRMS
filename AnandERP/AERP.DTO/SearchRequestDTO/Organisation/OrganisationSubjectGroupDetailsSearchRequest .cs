using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSubjectGroupDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public string ShortDescription
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public int OrgSemesterMstID
        {
            get;
            set;
        }
        public int CourseYearDetailID
        {
            get;
            set;
        }
        public int SubjectRuleGrpNumber
        {
            get;
            set;
        }
        public string CompulsoryOptionalFlag
        {
            get;
            set;
        }
        public string UniversityCode
        {
            get;
            set;
        }
        public string Pattern
        {
            get;
            set;
        }
        public string ElectiveGroupFlag
        {
            get;
            set;
        }
        public int OrgElectiveGrpID
        {
            get;
            set;
        }
        public string ElectiveSubGroupFlag
        {
            get;
            set;
        }
        public int OrgSubElectiveGrpID
        {
            get;
            set;
        }
        public string ElectiveSubjectCompFlag
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
        public string SearchType
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string ScopeIdentity
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int AdminRoleMasterID
        {
            get;
            set;
        }
        public int CurrentSessionID
        {
            get;
            set;
        }
        public string SortDirection { get; set; }
        public string SearchBy { get; set; }
    }
}
