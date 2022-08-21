using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class InventoryExcelUploadViewModel : IInventoryExcelUploadViewModel
    {
        public InventoryExcelUploadViewModel()
        {
            InventoryExcelUploadDTO = new InventoryExcelUpload();
        }

        public InventoryExcelUpload InventoryExcelUploadDTO
        {
            get;
            set;
        }

        public string ExcelFile
        {
            get
            {
                return (InventoryExcelUploadDTO != null && InventoryExcelUploadDTO.ExcelFile != null) ? InventoryExcelUploadDTO.ExcelFile : string.Empty;
            }
            set
            {
                InventoryExcelUploadDTO.ExcelFile = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (InventoryExcelUploadDTO != null && InventoryExcelUploadDTO.XMLstring != null) ? InventoryExcelUploadDTO.XMLstring : string.Empty;
            }
            set
            {
                InventoryExcelUploadDTO.XMLstring = value;
            }
        }

        public string errorMessage 
        { 
            get; 
            set;
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryExcelUploadDTO != null) ? InventoryExcelUploadDTO.CreatedBy : new int();
            }
            set
            {
                InventoryExcelUploadDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryExcelUploadDTO != null) ? InventoryExcelUploadDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryExcelUploadDTO.CreatedDate = value;
            }
        }


    }
}
