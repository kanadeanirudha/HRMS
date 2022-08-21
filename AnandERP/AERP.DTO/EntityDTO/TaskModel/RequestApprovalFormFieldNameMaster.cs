using System;
using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class RequestApprovalFormFieldNameMaster : BaseDTO
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
        public string RequestCode
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
        //For RequestApprovalFormFieldNameDetails
        public Int32 RequestApprovalFormFieldNameDetailsID { get; set; }
        public Int32 RequestApprovalFormFieldNameMasterID { get; set; }
        public Int32 RequestApprovalFormFieldMasterId
        {
            get;
            set;
        }
        public String LableName      { get; set; }
        public byte SequenceNumber   { get; set; }
        public byte ColumnNumber     { get; set; }
        public String FieldName      { get; set; }
        public String XMLString      { get; set; }
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


       // public object RequestApprovalFormFieldMasterID { get; set; }
    }
}
