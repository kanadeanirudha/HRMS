using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DTO
{
	public class OrganisationCentrewiseSessionSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public int SessionID
		{
			get;
			set;
		}
		public string SessionFromDate
		{
			get;
			set;
		}
		public string SessionUptoDate
		{
			get;
			set;
		}
		public string ActiveSessionType
		{
			get;
			set;
		}
		public string ActiveSessionFlag
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
		public string LockStatus
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
        public int AllSession
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
	}
}

