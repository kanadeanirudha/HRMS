using AERP.DTO;
using System;

namespace AERP.ViewModel
{
    public interface IAccountSessionMasterReportViewModel
    {
        AccountSessionMasterReport AccountSessionMasterReportDTO
        {
            get;
            set;
        }
        Int16 ID { get; set; }
        string SessionName { get; set; }
        string SessionStartDatetime { get; set; }
        string SessionEndDatetime { get; set; }
        bool DefaultFlag { get; set; }
        string Account_System { get; set; }
        bool IsActive { get; set; }
      
    }
}
