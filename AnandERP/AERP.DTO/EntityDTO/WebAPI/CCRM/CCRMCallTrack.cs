using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class CCRMCallTrack : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string CallTicketNumber
        {
            get;
            set;
        }

        public DateTime TrackDate
        {
            get;
            set;
        }

        public byte TrackType
        {
            get;
            set;
        }

        public byte TrackStatus
        {
            get;
            set;
        }

        public decimal Latitude
        {
            get;
            set;
        }

        public decimal Longitude
        {
            get;
            set;
        }

        public string VersionNumber
        {
            get;
            set;
        }
        public string TrackStatusName
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
    }
}
