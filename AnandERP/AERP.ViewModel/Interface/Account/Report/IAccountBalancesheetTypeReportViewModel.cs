using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
    public interface IAccountBalancesheetTypeReportViewModel
    {
        AccountBalancesheetTypeReport AccountBalancesheetTypeReportDTO { get; set; }
         byte ID
        {
            get;
            set;
        }
         string AccBalsheetTypeCode
        {
            get;
            set;
        }
         string AccBalsheetTypeDesc
        {
            get;
            set;
        }
         bool IsActive
        {
            get;
            set;
        }
         bool IsDeleted
        {
            get;
            set;
        }
         int CreatedBy
        {
            get;
            set;
        }
         DateTime CreatedDate
        {
            get;
            set;
        }
         int? ModifiedBy
        {
            get;
            set;
        }
         DateTime? ModifiedDate
        {
            get;
            set;
        }
         int? DeletedBy
        {
            get;
            set;
        }
         DateTime? DeletedDate
        {
            get;
            set;
        }

    }
}
