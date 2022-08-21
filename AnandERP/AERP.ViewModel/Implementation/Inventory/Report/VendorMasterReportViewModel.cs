using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class VendorMasterReportViewModel
    {
        public VendorMasterReportViewModel()
        {
            VendorMasterReportDTO = new VendorMasterReport();
            ListVendorMasterReport = new List<VendorMasterReport>();
            ListAllVendor = new List<VendorMasterReport>();
          
        }


        public List<VendorMasterReport> ListVendorMasterReport { get; set; }
        public List<VendorMasterReport> ListAllVendor { get; set; }
        
        public VendorMasterReport VendorMasterReportDTO { get; set; }

        [Display(Name = "SelectedVendorID")]
        public string SelectedVendorID { get; set; }

        public IEnumerable<SelectListItem> VendorNameListItem
        {
            get
            {
                return new SelectList(ListAllVendor, "VendorID", "VendorName");
            }
        }

      

        public Int16 ID
        {
            get
            {
                return (VendorMasterReportDTO != null && VendorMasterReportDTO.ID > 0) ? VendorMasterReportDTO.ID : new Int16();
            }
            set
            {
                VendorMasterReportDTO.ID= value;
            }
        }
        [Display(Name = "VendorName")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryCodeRequired")]
        public string VendorName
        {
            get
            {
                return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.VendorName : string.Empty;
            }
            set
            {
                VendorMasterReportDTO.VendorName = value;
            }
        }
        [Display(Name = "VendorNumber")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryCodeRequired")]
        public string VendorNumber
        {
            get
            {
                return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.VendorNumber : string.Empty;
            }
            set
            {
                VendorMasterReportDTO.VendorNumber = value;
            }
        }
        [Display(Name = "ContactPerson")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryCodeRequired")]
        public string ContactPerson
        {
            get
            {
                return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.ContactPerson : string.Empty;
            }
            set
            {
                VendorMasterReportDTO.ContactPerson = value;
            }
        }
        [Display(Name = "MerchandiseCategory")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryCodeRequired")]
        public string MerchandiseCategory
        {
            get
            {
                return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.MerchandiseCategory : string.Empty;
            }
            set
            {
                VendorMasterReportDTO.MerchandiseCategory = value;
            }
        }
        [Display(Name = "LeadTime")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryCodeRequired")]
        public string LeadTime
        {
            get
            {
                return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.LeadTime : string.Empty;
            }
            set
            {
                VendorMasterReportDTO.LeadTime = value;
            }
        }
        [Display(Name = "VendorRestriction")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryCodeRequired")]
        public decimal VendorRestriction
        {
            get
            {
                return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.VendorRestriction :new decimal();
            }
            set
            {
                VendorMasterReportDTO.VendorRestriction = value;
            }
        }
        public bool IsPosted
        {
            get
            {
                return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.IsPosted : false;
            }
            set
            {
                VendorMasterReportDTO.IsPosted = value;
            }
        }
        public string ReportFor
        {
            get
            {
                return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.ReportFor : string.Empty;
            }
            set
            {
                VendorMasterReportDTO.ReportFor = value;
            }
        }
        public string VendorReportList
        {
            get
            {
                return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.VendorReportList: string.Empty;
            }
            set
            {
                VendorMasterReportDTO.VendorReportList = value;
            }
        }
        //public string ListAllVendor
        //{
        //    get
        //    {
        //        return (VendorMasterReportDTO != null) ? VendorMasterReportDTO.ListAllVendor : string.Empty;
        //    }
        //    set
        //    {
        //        VendorMasterReportDTO.ListAllVendor = value;
        //    }
        //}

      
           

        public Int16 _VendorID { get; set; }
    }
    
}

