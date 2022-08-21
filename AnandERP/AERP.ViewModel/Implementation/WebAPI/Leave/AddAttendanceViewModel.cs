using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class AddAttendanceViewModel
    {

        public AddAttendanceViewModel()
        {
            AddAttendanceDTO = new AddAttendance();


        }
     
        public AddAttendance AddAttendanceDTO
        {
            get;
            set;
        }
        public string VersionNumber
        {

            get
            {
                return (AddAttendanceDTO != null) ? AddAttendanceDTO.VersionNumber : string.Empty;
            }
            set
            {
                AddAttendanceDTO.VersionNumber = value;
            }
        }

        public int CreatedBy
        {

            get
            {
                return (AddAttendanceDTO != null) ? AddAttendanceDTO.CreatedBy : new Int32();
            }
            set
            {
                AddAttendanceDTO.CreatedBy = value;
            }
        }

        public string XML
        {

            get
            {
                return (AddAttendanceDTO != null) ? AddAttendanceDTO.XML : string.Empty;
            }
            set
            {
                AddAttendanceDTO.XML = value;
            }
        }
    }
}
