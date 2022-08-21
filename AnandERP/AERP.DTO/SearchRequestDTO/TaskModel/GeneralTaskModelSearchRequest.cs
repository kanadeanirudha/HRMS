using AERP.Base.DTO;
namespace AERP.DTO
{
	public class GeneralTaskModelSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public string TaskCode
		{
			get;
			set;
		}
		public string TaskDescription
		{
			get;
			set;
		}
		public string MenuCode
		{
			get;
			set;
		}
		public string TaskModelApplicableTo
		{
			get;
			set;
		}
		public bool IsActive
		{
			get;
			set;
		}
		public string LinkMenuCode
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
        public int StatusFlag { get; set; }
	}
}
