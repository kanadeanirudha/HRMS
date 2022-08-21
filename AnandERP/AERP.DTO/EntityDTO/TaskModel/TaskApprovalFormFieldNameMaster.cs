using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class TaskApprovalFormFieldNameMaster : BaseDTO
	{
		public Int32 ID
		{
			get;
			set;
		}
        public string FormName
		{
			get;
			set;
		}
        public string TaskCode
		{
			get;
			set;
		}
        public string ViewName
        {
            get;
            set;
        }
        public string InsertUpdateProcedure
        {
            get;
            set;
        }
        public string XMLstring { get; set; }
        public Int32 TaskApprovalFormFieldNameDetailsID { get; set; }
        //For TaskApprovalFormFieldMasterDetail
        public Int32 TaskApprovalFormFieldMasterId
        {
            get;
            set;
        }
        public string LableName
        {
            get;
            set;
        }

        public Int16 SequenceNumber
        {
            get;
            set;
        }
        public Int16 ColumnNumber
        {
            get;
            set;
        }
        public String FieldName
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
        public bool StatusFlag
        {
            get;
            set;
        }
        public string errorMessage { get; set; }


       // public string Procedure { get; set; }

        //public object TaskApprovalFormFieldNameDetailsID { get; set; }
    }
}
