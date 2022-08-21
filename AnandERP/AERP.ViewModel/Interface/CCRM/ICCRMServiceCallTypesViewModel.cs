using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
   public class ICCRMServiceCallTypesViewModel
    {
        CCRMServiceCallTypes CCRMServiceCallTypesDTO { get; set; }
        Int32 ID { get; set; }

        string FeedbackName { get; set; }
        string FeedbackPoints { get; set; }
        bool ISCalculateResponceTime { get; set; }
        bool ISPMCall { get; set; }
        bool ISServiceReportRequired { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
