using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class AccountSessionMasterReportSearchRequest : Request
    {
        public Int16 ID
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }
     
    }
}

