using AERP.Base.DTO;

namespace AERP.DTO
{
    public class AdminMenuApplicableSearchRequest : Request
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

        public bool IsActive
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
