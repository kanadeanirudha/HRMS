using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AERP.Common;
using AERP.DTO;

using System.Collections;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
   public class CCRMMIFReportViewModel
    {
        public CCRMMIFReportViewModel()
        {
            CCRMMIFReportDTO = new CCRMMIFReport();


        }
        public CCRMMIFReport CCRMMIFReportDTO { get; set; }
        public Int32 ID
        {
            get
            {
                return (CCRMMIFReportDTO != null && CCRMMIFReportDTO.ID > 0) ? CCRMMIFReportDTO.ID : new Int32();
            }
            set
            {
                CCRMMIFReportDTO.ID = value;
            }
        }
        public string MIFTitle
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.MIFTitle : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.MIFTitle = value;
            }
        }
        
        public string MIFAddress
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.MIFAddress : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.MIFAddress = value;
            }
        }
       
        public string ModelNo
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.ModelNo = value;
            }
        }
       
        public string SerialNo
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.SerialNo = value;
            }
        }
        public Int16 MachineFamilyID
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.MachineFamilyID : new Int16();
            }
            set
            {
                CCRMMIFReportDTO.MachineFamilyID = value;
            }
        }
        public Int32 CCRMLocationTypeID
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.CCRMLocationTypeID : new Int32();
            }
            set
            {
                CCRMMIFReportDTO.CCRMLocationTypeID = value;
            }
        }
        public string InstallationDate
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.InstallationDate : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.InstallationDate = value;
            }
        }
        public Int32 InstalledById
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.InstalledById : new Int32();
            }
            set
            {
                CCRMMIFReportDTO.InstalledById = value;
            }
        }
        public string WarantyExpiryDate
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.WarantyExpiryDate : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.WarantyExpiryDate = value;
            }
        }
        public string AreaPatchName
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.AreaPatchName : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.AreaPatchName = value;
            }
        }
        public Int16 CCRMAreaPatchMasterID
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.CCRMAreaPatchMasterID : new Int16();
            }
            set
            {
                CCRMMIFReportDTO.CCRMAreaPatchMasterID = value;
            }
        }
        [Display(Name = " Group ")]
        public Int32 CCRMEngineersGroupMasterID
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.CCRMEngineersGroupMasterID : new Int32();
            }
            set
            {
                CCRMMIFReportDTO.CCRMEngineersGroupMasterID = value;
            }
        }
        public string Status
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.Status : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.Status = value;
            }
        }
        public bool IsPosted
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.IsPosted : false;
            }
            set
            {
                CCRMMIFReportDTO.IsPosted = value;
            }
        }
        public string ContractType
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.ContractType : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.ContractType = value;
            }
        }
        public Int32 ContractTypeId
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.ContractTypeId : new Int32();
            }
            set
            {
                CCRMMIFReportDTO.ContractTypeId = value;
            }
        }
        public Int32 EngineerID
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.EngineerID : new Int32();
            }
            set
            {
                CCRMMIFReportDTO.EngineerID = value;
            }
        }
        public string EnggName
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.EnggName : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.EnggName = value;
            }
        }
        public string Category
        {
            get
            {
                return (CCRMMIFReportDTO != null) ? CCRMMIFReportDTO.Category : string.Empty;
            }
            set
            {
                CCRMMIFReportDTO.Category = value;
            }
        }
    }
}
