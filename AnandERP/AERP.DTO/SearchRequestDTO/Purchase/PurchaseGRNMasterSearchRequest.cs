using AERP.Base.DTO;
namespace AERP.DTO
{
	public class PurchaseGRNMasterSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
        public int AdminRoleID
        {
            get;
            set;
        }
        public int PurchaseOrderMasterID
        {
            get;
            set;
        }
		public string PurchaseGRNNumber
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
        public int VendorID
        {
            get;
            set;
        }
        public int PersonID { get; set; }
        public int TaskNotificationMasterID { get; set; }

        public byte POStatus { get; set; }
        public int ItemNumber { get; set; }

        public string MonthName { get; set; }
        public string MonthYear { get; set; }

    }
}
