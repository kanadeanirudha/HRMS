using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class GeneralUnitsStorageLocation : BaseDTO
	{
        //---------------------------------------GeneralUnitsStorageLocation-----------------------------
		public Int16 ID
		{
			get;
			set;
		}

        public Int16 GeneralUnitsID
        {
            get;
            set;
        }
        public string UnitName
        { 
            get; 
            set; 
        }
        public bool IsDefault
        {
            get;
            set;
        }
        public string LocationName
        {
            get;
            set;
        }
        public int InventoryLocationMasterID
        {
            get;
            set;
        }
        public int IsDefaultCount
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
        public string ActionOn { get; set; }
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public string XmlString
        {
            get;
            set;
        }
	}
}
