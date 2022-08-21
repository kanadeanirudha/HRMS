using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface IInventoryExcelUploadViewModel
    {
        string ExcelFile
        {
            get;
            set;
        }
    }
}
