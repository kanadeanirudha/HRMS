using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class CCRMCallTrackViewModel
    {

        public CCRMCallTrackViewModel()
        {
            CCRMCallTrackDTO = new CCRMCallTrack();
        }

        public CCRMCallTrack CCRMCallTrackDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (CCRMCallTrackDTO != null && CCRMCallTrackDTO.ID > 0) ? CCRMCallTrackDTO.ID : new int();
            }
            set
            {
                CCRMCallTrackDTO.ID = value;
            }
        }

        public DateTime TrackDate
        {
            get
            {
                return (CCRMCallTrackDTO != null) ? CCRMCallTrackDTO.TrackDate : DateTime.Now;
            }
            set
            {
                CCRMCallTrackDTO.TrackDate = value;
            }
        }

        public byte TrackStatus
        {
            get
            {
                return (CCRMCallTrackDTO != null) ? CCRMCallTrackDTO.TrackStatus : new byte();
            }
            set
            {
                CCRMCallTrackDTO.TrackStatus = value;
            }
        }

        public string TrackStatusName
        {
            get
            {
                return (CCRMCallTrackDTO != null) ? CCRMCallTrackDTO.TrackStatusName : string.Empty;
            }
            set
            {
                CCRMCallTrackDTO.TrackStatusName = value;
            }
        }

        public string CallTicketNumber
        {

            get
            {
                return (CCRMCallTrackDTO != null) ? CCRMCallTrackDTO.CallTicketNumber : string.Empty;
            }
            set
            {
                CCRMCallTrackDTO.CallTicketNumber = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (CCRMCallTrackDTO != null) ? CCRMCallTrackDTO.VersionNumber : string.Empty;
            }
            set
            {
                CCRMCallTrackDTO.VersionNumber = value;
            }
        }

        public decimal Latitude
        {
            get
            {
                return (CCRMCallTrackDTO != null) ? CCRMCallTrackDTO.Latitude : new Decimal();
            }
            set
            {
                CCRMCallTrackDTO.Latitude = value;
            }
        }

        public decimal Longitude
        {
            get
            {
                return (CCRMCallTrackDTO != null) ? CCRMCallTrackDTO.Longitude : new Decimal();
            }
            set
            {
                CCRMCallTrackDTO.Longitude = value;
            }
        }

        public int UserID
        {
            get
            {
                return (CCRMCallTrackDTO != null) ? CCRMCallTrackDTO.UserId : new Int32();
            }
            set
            {
                CCRMCallTrackDTO.UserId = value;
            }
        }
    }
}
