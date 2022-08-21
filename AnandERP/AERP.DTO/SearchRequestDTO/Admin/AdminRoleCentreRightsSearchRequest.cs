using AERP.Base.DTO;

namespace AERP.DTO
{
    public class AdminRoleCentreRightsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int AdminRoleMasterID
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
