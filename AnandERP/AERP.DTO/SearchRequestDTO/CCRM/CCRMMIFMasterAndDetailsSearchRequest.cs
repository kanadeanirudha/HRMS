using AERP.Base.DTO;


namespace AERP.DTO
{
   public class CCRMMIFMasterAndDetailsSearchRequest :Request
    {
        public int CCRMMIFMasterAndDetailsID
        {
            get;
            set;
        }
        public int GetListOfOperatorByID
        {
            get;
            set;
        }
        public int CCRMMIFCallOperatorDetailsID
        {
            get;
            set;
        }
        public int CustomerMasterID
        {
            get;
            set;
        }
        public int MIFMasterID
        {
            get;
            set;
        }
        public string CustomerName
        {
            get;
            set;
        }
        public string CustomerCode
        {
            get;
            set;
        }
        public string SearchWord
        {
            get; set;
        }
        
        public bool IsDeleted
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

        public int EndRow
        {
            get;
            set;
        }

        public int RowLength
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
