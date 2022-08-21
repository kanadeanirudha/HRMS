using AERP.Base.DTO;

namespace AERP.DTO
{
    public class AccountBalancesheetTypeReportSearchRequest : Request
    {
        public byte ID
        {
            get;
            set;
        }

        public string AccountBalancesheetTypeCode
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
    }
}