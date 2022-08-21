using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class GeneralRequestMaster : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}

        public string RequestCode
		{
			get;
			set;
		}
        public string RequestDescription
		{
			get;
			set;
		}
        public string MenuCode
        {
            get;
            set;
        }
        public string RequestApprovalBasedTable
        {
            get;
            set;
        }
        public string RequestApprovalParamPrimaryKey
        {
            get;
            set;
        }
        public string LinkMenuCode
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
       // public string MenuCode { get; set; }
	}
}
