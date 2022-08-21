using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralCounterPOSAndPosOperator : BaseDTO
	{
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

        public string GeneralUnitsName
        {
            get;
            set;
        }

        public Int16 GeneralCounterMasterId
        {
            get;
            set;
        }

        public string GeneralCounterMasterName
        {
            get;
            set;
        }

        public Int16 GeneralPOSMasterId
        {
            get;
            set;
        }

        public string GeneralPOSMasterDeviceCode
        {
            get;
            set;
        }

        public string DateFrom
        {
            get;
            set;
        }
        public string DateUpto
        {
            get;
            set;
        }
        public bool IsCurrent
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
        public string CentreCode { get; set; }

    }
}
