using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class ESICMonthlyUploadingFileViewModel
    {

        public ESICMonthlyUploadingFileViewModel()
        {
            ESICMonthlyUploadingFile = new ESICMonthlyUploadingFile();
            ESICMonthlyUploadingFileList = new List<ESICMonthlyUploadingFile>();
        }
        public List<ESICMonthlyUploadingFile> ESICMonthlyUploadingFileList { get; set; }

        public ESICMonthlyUploadingFile ESICMonthlyUploadingFile
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (ESICMonthlyUploadingFile != null && ESICMonthlyUploadingFile.ID > 0) ? ESICMonthlyUploadingFile.ID : new Int64();
            }
            set
            {
                ESICMonthlyUploadingFile.ID = value;
            }
        }
        public string ExcelFile
        {
            get
            {
                return (ESICMonthlyUploadingFile != null && ESICMonthlyUploadingFile.ExcelFile != null) ? ESICMonthlyUploadingFile.ExcelFile : string.Empty;
            }
            set
            {
                ESICMonthlyUploadingFile.ExcelFile = value;
            }
        }
        [Display(Name = "Month")]
        public byte MonthName
        {
            get
            {
                return (ESICMonthlyUploadingFile != null) ? ESICMonthlyUploadingFile.MonthName : new byte();
            }
            set
            {
                ESICMonthlyUploadingFile.MonthName = value;
            }
        }
        [Display(Name = "Year")]
        public string Monthyear
        {
            get
            {
                return (ESICMonthlyUploadingFile != null && ESICMonthlyUploadingFile.Monthyear != null) ? ESICMonthlyUploadingFile.Monthyear : string.Empty;
            }
            set
            {
                ESICMonthlyUploadingFile.Monthyear = value;
            }
        }

        public string CentreCode
        {
            get;
            set;
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (ESICMonthlyUploadingFile != null) ? ESICMonthlyUploadingFile.IsDeleted : false;
            }
            set
            {
                ESICMonthlyUploadingFile.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ESICMonthlyUploadingFile != null && ESICMonthlyUploadingFile.CreatedBy > 0) ? ESICMonthlyUploadingFile.CreatedBy : new int();
            }
            set
            {
                ESICMonthlyUploadingFile.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ESICMonthlyUploadingFile != null) ? ESICMonthlyUploadingFile.CreatedDate : DateTime.Now;
            }
            set
            {
                ESICMonthlyUploadingFile.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ESICMonthlyUploadingFile != null && ESICMonthlyUploadingFile.ModifiedBy > 0) ? ESICMonthlyUploadingFile.ModifiedBy : new int();
            }
            set
            {
                ESICMonthlyUploadingFile.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ESICMonthlyUploadingFile != null && ESICMonthlyUploadingFile.ModifiedDate.HasValue) ? ESICMonthlyUploadingFile.ModifiedDate : DateTime.Now;
            }
            set
            {
                ESICMonthlyUploadingFile.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ESICMonthlyUploadingFile != null && ESICMonthlyUploadingFile.DeletedBy > 0) ? ESICMonthlyUploadingFile.DeletedBy : new int();
            }
            set
            {
                ESICMonthlyUploadingFile.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ESICMonthlyUploadingFile != null && ESICMonthlyUploadingFile.DeletedDate.HasValue) ? ESICMonthlyUploadingFile.DeletedDate : DateTime.Now;
            }
            set
            {
                ESICMonthlyUploadingFile.DeletedDate = value;
            }
        }
        
        public string errorMessage { get; set; }
    }
}

