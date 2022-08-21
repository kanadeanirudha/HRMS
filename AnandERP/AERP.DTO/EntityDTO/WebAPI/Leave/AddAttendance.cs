using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AddAttendance : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }
        public string XML
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }

        public string VersionNumber
        {
            get;
            set;
        }
    }
}
