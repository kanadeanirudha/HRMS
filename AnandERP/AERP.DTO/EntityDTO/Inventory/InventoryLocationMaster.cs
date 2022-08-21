using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class InventoryLocationMaster : BaseDTO
	{
        //---------------------------------------InventoryLocationMaster-----------------------------
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
        public int IssueFromLocationID
        {
            get;
            set;
        }
        public int AccBalanceSheetID
        {
            get;
            set;
        }
    public Int16 GeneralUnitsID { get; set; }
        public string LocationName
		{
			get;
			set;
		}
	
		public bool IsDeleted
		{
			get;
			set;
		}
		public int CreatedBy
		{
			get;
			set;
		}
		public DateTime CreatedDate
		{
			get;
			set;
		}
		public int ModifiedBy
		{
			get;
			set;
		}
		public DateTime ModifiedDate
		{
			get;
			set;
		}
		public int DeletedBy
		{
			get;
			set;
		}
		public DateTime DeletedDate
		{
			get;
			set;
		}

        public string errorMessage { get; set; }
        public string SelectedBalanceSheet { get; set; }
        public bool IsActive { get; set; }
	}
}
