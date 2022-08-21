using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AERP.DTO
{
    public class AccountSessionMasterReport : BaseDTO
    {
        public Int16 ID { get; set; }
        public string SessionName { get; set; }
        public string SessionStartDatetime { get; set; }
        public string SessionEndDatetime { get; set; }
        public bool DefaultFlag { get; set; }
        public string Account_System { get; set; }
        public bool IsActive { get; set; }
     
    }
}
