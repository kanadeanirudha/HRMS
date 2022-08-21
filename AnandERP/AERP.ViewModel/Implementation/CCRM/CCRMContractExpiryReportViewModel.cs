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
   public class CCRMContractExpiryReportViewModel
    {
        public CCRMContractExpiryReportViewModel()
        {
            CCRMContractExpiryReportDTO = new CCRMContractExpiryReport();
           

        }
        public CCRMContractExpiryReport CCRMContractExpiryReportDTO { get; set; }
        public Int32 ID
        {
            get
            {
                return (CCRMContractExpiryReportDTO != null && CCRMContractExpiryReportDTO.ID > 0) ? CCRMContractExpiryReportDTO.ID : new Int16();
            }
            set
            {
                CCRMContractExpiryReportDTO.ID = value;
            }
        }
        [Display(Name = "MIF Name")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryCodeRequired")]
        public string MIFName
        {
            get
            {
                return (CCRMContractExpiryReportDTO != null) ? CCRMContractExpiryReportDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMContractExpiryReportDTO.MIFName = value;
            }
        }
        [Display(Name = "Serial No")]
       
        public string SerialNo
        {
            get
            {
                return (CCRMContractExpiryReportDTO != null) ? CCRMContractExpiryReportDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMContractExpiryReportDTO.SerialNo = value;
            }
        }
        [Display(Name = "Contarct")]

        public string Contarct
        {
            get
            {
                return (CCRMContractExpiryReportDTO != null) ? CCRMContractExpiryReportDTO.Contarct : string.Empty;
            }
            set
            {
                CCRMContractExpiryReportDTO.Contarct = value;
            }
        }
        [Display(Name = "Expiry Date")]

        public string ExpiryDate
        {
            get
            {
                return (CCRMContractExpiryReportDTO != null) ? CCRMContractExpiryReportDTO.ExpiryDate : string.Empty;
            }
            set
            {
                CCRMContractExpiryReportDTO.ExpiryDate = value;
            }
        }
       

        public bool Close
        {
            get
            {
                return (CCRMContractExpiryReportDTO != null) ? CCRMContractExpiryReportDTO.Close : new bool(); ;
            }
            set
            {
                CCRMContractExpiryReportDTO.Close = value;
            }
        }

    }
}
