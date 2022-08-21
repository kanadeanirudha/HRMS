using AERP.Base.DTO;

namespace AERP.DTO
{
    public class OrganisationDepartmentMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }

        public string CentreCode
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
        public int AdminRoleMasterID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public string EntityLevel { get; set; }
        public string SearchWord
        {
            get;
            set;
        }


        public string DepartmentID { get; set; }

        public string CourseYearID { get; set; }
    }
}

