using AERP.Base.DTO;
namespace AERP.DTO
{
	public class PurchaseRequirementMasterSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public string PurchaseRequirementNumber
		{
			get;
			set;
		}
        public string TransDate
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
        public string SearchWord
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
        public int AdminRoleMasterID
		{
			get;
			set;
		}
        public string EntityLevel
        {
            get;
            set;
        }
        public int PersonID { get; set; }
        public int TaskNotificationMasterID { get; set; }
        public int GeneralTaskReportingDetailsID { get; set; }

    }
}
