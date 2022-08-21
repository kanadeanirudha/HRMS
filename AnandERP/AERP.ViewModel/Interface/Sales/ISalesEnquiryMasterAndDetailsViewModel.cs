using AERP.DTO;
using System;
using System.Collections.Generic;
namespace AERP.ViewModel
{
    interface ISalesEnquiryMasterAndDetailsViewModel
    {
        //**********SalesEnquiryMasterAndDetails**********//
       
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

        bool IsDeleted
        {
            get;
            set;
        }
        string errorMessage { get; set; }

    }
}
