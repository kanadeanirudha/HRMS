using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeQualificationSearchRequest : Request
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
        public string FromYear
        {
            get;
            set;
        }
        public string UptoYear
        {
            get;
            set;
        }
        public string YearOfPassing
        {
            get;
            set;
        }
        public string PassingDivision
        {
            get;
            set;
        }
        public byte NoOfAttempts
        {
            get;
            set;
        }
        public string NameOfInstitution
        {
            get;
            set;
        }
        public int EducationID
        {
            get;
            set;
        }
        public string EducationYear
        {
            get;
            set;
        }
        public int BoardUniversityID
        {
            get;
            set;
        }
        public double AggregatePercentage
        {
            get;
            set;
        }
        public double FinalYearPercentage
        {
            get;
            set;
        }
        public byte Rank
        {
            get;
            set;
        }
        public string Remark
        {
            get;
            set;
        }
        public string SpecailisationIn
        {
            get;
            set;
        }
        public bool IsActive
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
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
    }
}
