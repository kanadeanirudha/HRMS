using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IOrderingAndDeliveryDayViewModel
    {
        OrderingAndDeliveryDay OrderingAndDeliveryDayDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        bool sunday
        {
            get;
            set;
        }

        bool monday
        {
            get;
            set;
        }
        bool tuesday
        {
            get;
            set;
        }

        bool wednesday
        {
            get;
            set;
        }
        bool thursday
        {
            get;
            set;
        }

        bool friday
        {
            get;
            set;
        }
        bool saturday
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
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
