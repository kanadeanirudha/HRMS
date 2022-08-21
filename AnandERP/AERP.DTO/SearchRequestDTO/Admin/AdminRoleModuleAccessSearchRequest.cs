using AERP.Base.DTO;

namespace AERP.DTO
{
    public class AdminRoleModuleAccessSearchRequest : Request
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

        public string MonitoringLevel
        {
            get;
            set;
        }

        public int AdminRoleMasterID
        {
            get;
            set;
        }

        public string EntityType
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get;
            set;
        }

        public int AdmSnPostID
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
