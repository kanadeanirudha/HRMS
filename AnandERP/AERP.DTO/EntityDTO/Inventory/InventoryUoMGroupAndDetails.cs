using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class InventoryUoMGroupAndDetails : BaseDTO
	{
        //Properties of InventoryUoMGroup 

        public Int16 InventoryUoMGroupID
		{
			get;
			set;
		}
        public string GroupCode
		{
			get;
			set;
		}
        public string GroupDescription
		{
			get;
			set;
		}
        public string BaseUomCode
        {
            get;
            set;
        }
        //InventoryUoMGroupDetails

        public Int16 InventoryUoMGroupDetailsID
        {
            get;
            set;
        }
        //public string GroupCode
        //{
        //    get;
        //    set;
        //}
        public string AlternativeUomName
        {
            get;
            set;
        }
        public string AlternativeUomCode
        {
            get;
            set;
        }
        public decimal AlternativeQuantity 
        {
            get;
            set;
        }
        //public string BaseUomCode
        //{
        //    get;
        //    set;
        //}
        public decimal BaseUoMQuantity
        {
            get;
            set;
        }
        public decimal BasePriceReducedBy
        {
            get;
            set;
        }
        public Int16 UsedFor
        {
            get;
            set;
        }
       //Common Properties
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
	}
}
