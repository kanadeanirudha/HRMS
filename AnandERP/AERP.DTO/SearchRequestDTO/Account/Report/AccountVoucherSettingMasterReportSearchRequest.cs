using AERP.Base.DTO;

namespace AERP.DTO
{
    public class AccountVoucherSettingMasterReportSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int BalanesheetMstID
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
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

        public int EndRow
        {
            get;
            set;
        }

        public int RowLength
        {
            get;
            set;
        }
    }
}
