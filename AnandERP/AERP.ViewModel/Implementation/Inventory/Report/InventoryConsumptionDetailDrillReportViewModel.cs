using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryConsumptionDetailDrillReportViewModel
    {
        public InventoryConsumptionDetailDrillReportViewModel()
        {
            InventoryConsumptionDetailDrillReportDTO = new InventoryConsumptionDetailDrillReport();
            ListGeneralUnits = new List<InventoryConsumptionDetailDrillReport>(); 
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public List<InventoryConsumptionDetailDrillReport> ListGeneralUnits
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        {
            get
            {
                return new SelectList(ListGeneralUnits, "ID", "UnitName");
            }
        }
       
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public InventoryConsumptionDetailDrillReport InventoryConsumptionDetailDrillReportDTO { get; set; }

      
        [Display(Name = "From Date")]
        public string DateFrom
        {
            get
            {
                return (InventoryConsumptionDetailDrillReportDTO != null) ? InventoryConsumptionDetailDrillReportDTO.DateFrom : string.Empty;
            }
            set
            {
                InventoryConsumptionDetailDrillReportDTO.DateFrom = value;
            }
        }
      
        [Display(Name = "To Date")]
        public string DateTo
        {
            get
            {
                return (InventoryConsumptionDetailDrillReportDTO != null) ? InventoryConsumptionDetailDrillReportDTO.DateTo : string.Empty;
            }
            set
            {
                InventoryConsumptionDetailDrillReportDTO.DateTo = value;
            }
        }

        [Display(Name = "Granularity")]
        public string Granularity
        {
            get
            {
                return (InventoryConsumptionDetailDrillReportDTO != null) ? InventoryConsumptionDetailDrillReportDTO.Granularity : string.Empty;
            }
            set
            {
                InventoryConsumptionDetailDrillReportDTO.Granularity = value;
            }
        }

        [Display(Name = "Site")]
        public Int32 GeneralUnitsID
        {
            get
            {
                return (InventoryConsumptionDetailDrillReportDTO != null && InventoryConsumptionDetailDrillReportDTO.GeneralUnitsID > 0) ? InventoryConsumptionDetailDrillReportDTO.GeneralUnitsID : new Int32();
            }
            set
            {
                InventoryConsumptionDetailDrillReportDTO.GeneralUnitsID = value;
            }
        }       
           public bool IsPosted { get; set; }
          public List<InventoryConsumptionDetailDrillReport> ListAllGranularity { get; set; }
        
          public string GranularityName
          {
              get
              {
                  return (InventoryConsumptionDetailDrillReportDTO != null) ? InventoryConsumptionDetailDrillReportDTO.GranularityName : string.Empty;
              }
              set
              {
                  InventoryConsumptionDetailDrillReportDTO.GranularityName = value;
              }
          }
          public string GeneralUnitsName
          {
              get
              {
                  return (InventoryConsumptionDetailDrillReportDTO != null) ? InventoryConsumptionDetailDrillReportDTO.GeneralUnitsName : string.Empty;
              }
              set
              {
                  InventoryConsumptionDetailDrillReportDTO.GeneralUnitsName = value;
              }
          }
          public Int32 ProcessUnitID
          {
              get
              {
                  return (InventoryConsumptionDetailDrillReportDTO != null && InventoryConsumptionDetailDrillReportDTO.ProcessUnitID > 0) ? InventoryConsumptionDetailDrillReportDTO.ProcessUnitID : new Int32();
              }
              set
              {
                  InventoryConsumptionDetailDrillReportDTO.ProcessUnitID = value;
              }
          }
          public string SelectedGeneralUnitsID
          {
              get
              {
                  return (InventoryConsumptionDetailDrillReportDTO != null) ? InventoryConsumptionDetailDrillReportDTO.SelectedGeneralUnitsID : string.Empty;
              }
              set
              {
                  InventoryConsumptionDetailDrillReportDTO.SelectedGeneralUnitsID = value;
              }
          }
          public string CentreCode
          {
              get
              {
                  return (InventoryConsumptionDetailDrillReportDTO != null) ? InventoryConsumptionDetailDrillReportDTO.CentreCode : string.Empty;
              }
              set
              {
                  InventoryConsumptionDetailDrillReportDTO.CentreCode = value;
              }
          }
          public string CentreName
          {
              get
              {
                  return (InventoryConsumptionDetailDrillReportDTO != null) ? InventoryConsumptionDetailDrillReportDTO.CentreName : string.Empty;
              }
              set
              {
                  InventoryConsumptionDetailDrillReportDTO.CentreName = value;
              }
          }
    }
    
}

