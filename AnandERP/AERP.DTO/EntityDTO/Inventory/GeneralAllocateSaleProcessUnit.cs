using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class GeneralAllocateSaleProcessUnit : BaseDTO
	{
        //---------------------------------------General Allocate SaleProcessUnit-----------------------------
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
        public Int16 SalesUnitID
        {
            get;
            set;
        }

        public Int16  SalesUnitProssessID
        {
            get;
            set;
        }
        public string UnitName
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string ProcessUnitName
        {
            get;
            set;
        }
        public string AllocatedFromDate 
        { 
            get;
           set;
        }
        public string AllocatedUptoDate
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
	}
}
