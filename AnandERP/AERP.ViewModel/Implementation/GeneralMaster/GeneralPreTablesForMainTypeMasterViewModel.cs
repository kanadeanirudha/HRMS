using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralPreTablesForMainTypeMasterViewModel : IGeneralPreTablesForMainTypeMasterViewModel
    {
        public GeneralPreTablesForMainTypeMasterViewModel()
        {
            GeneralPreTablesForMainTypeMasterDTO = new GeneralPreTablesForMainTypeMaster();
        }

        public GeneralPreTablesForMainTypeMaster GeneralPreTablesForMainTypeMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.ID > 0) ? GeneralPreTablesForMainTypeMasterDTO.ID : new int();
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.ID = value;
            }
        }

        public string RefTableEntity
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.RefTableEntity != "") ? GeneralPreTablesForMainTypeMasterDTO.RefTableEntity : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.RefTableEntity = value;
            }
        }

        public string RefTableEntityKey
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.RefTableEntityKey != "") ? GeneralPreTablesForMainTypeMasterDTO.RefTableEntityKey : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.RefTableEntityKey = value;
            }
        }

        public string RefTableEntityDisplayKey
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.RefTableEntityDisplayKey != "") ? GeneralPreTablesForMainTypeMasterDTO.RefTableEntityDisplayKey : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.RefTableEntityDisplayKey = value;
            }
        }

        public string MenuCode
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.MenuCode != "") ? GeneralPreTablesForMainTypeMasterDTO.MenuCode : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.MenuCode = value;
            }
        }

        public string ModuleCode
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.ModuleCode != "") ? GeneralPreTablesForMainTypeMasterDTO.ModuleCode : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.ModuleCode = value;
            }
        }
        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null) ? GeneralPreTablesForMainTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.CreatedBy > 0) ? GeneralPreTablesForMainTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null) ? GeneralPreTablesForMainTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.ModifiedBy.HasValue) ? GeneralPreTablesForMainTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.ModifiedDate.HasValue) ? GeneralPreTablesForMainTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.DeletedBy.HasValue) ? GeneralPreTablesForMainTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.DeletedDate.HasValue) ? GeneralPreTablesForMainTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.DeletedDate = value;
            }
        }

        //----------------Extra Property-------------------------
        public string errorMessage { get; set; }

        [Display(Name="Module Name")]
        [Required(ErrorMessage = "Please select module name. ")]
        public string ModuleName {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.ModuleName != "") ? GeneralPreTablesForMainTypeMasterDTO.ModuleName : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.ModuleName = value;
            }
        }

        [Display(Name = "Menu Name")]
        [Required(ErrorMessage = "Please select menu name. ")]
        public string MenuName
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.MenuName != "") ? GeneralPreTablesForMainTypeMasterDTO.MenuName : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.MenuName = value;
            }
        }

        [Display(Name = "Table Name")]
        [Required(ErrorMessage = "Please select table name. ")]
        public string TableName
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.TableName != "") ? GeneralPreTablesForMainTypeMasterDTO.TableName : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.TableName = value;
            }
        }

        [Display(Name = "Primary Key")]
        [Required(ErrorMessage = "Please select primary key. ")]
        public string TablePrimeryKey
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.TablePrimeryKey != "") ? GeneralPreTablesForMainTypeMasterDTO.TablePrimeryKey : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.TablePrimeryKey = value;
            }
        }

        [Display(Name = "Display Field")]
        [Required(ErrorMessage = "Please select display feild. ")]
        public string DisplayField
        {
            get
            {
                return (GeneralPreTablesForMainTypeMasterDTO != null && GeneralPreTablesForMainTypeMasterDTO.DisplayField != "") ? GeneralPreTablesForMainTypeMasterDTO.DisplayField : string.Empty;
            }
            set
            {
                GeneralPreTablesForMainTypeMasterDTO.DisplayField = value;
            }
        }

    }
}
