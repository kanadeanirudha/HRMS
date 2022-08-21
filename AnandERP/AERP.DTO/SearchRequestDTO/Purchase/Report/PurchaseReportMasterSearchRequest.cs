using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class PurchaseReportMasterSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
        
        public string TransDate
		{
			get;
			set;
		}
        public int BalancesheetID
        {
            get;
            set;
        }
        public string LocationNameListXml
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

        public Int16 GeneralUnitsID
        {
            get;
            set;
        }
        public int ItemNumber { get; set; }
        public string GeneralUnitsName
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
    }
}
