using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralPackageTypeViewModel : IGeneralPackageTypeViewModel
    {

        public GeneralPackageTypeViewModel()
        {
            GeneralPackageTypeDTO = new GeneralPackageType();

        }



        public GeneralPackageType GeneralPackageTypeDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (GeneralPackageTypeDTO != null && GeneralPackageTypeDTO.ID > 0) ? GeneralPackageTypeDTO.ID : new Int32();
            }
            set
            {
                GeneralPackageTypeDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Package Type should not be blank.")]
        [Display(Name = "Package Type")]
        public string PackageType
        {
            get
            {
                return (GeneralPackageTypeDTO != null) ? GeneralPackageTypeDTO.PackageType : string.Empty;
            }
            set
            {
                GeneralPackageTypeDTO.PackageType = value;
            }
        }

        [Required(ErrorMessage = "Height should not be blank.")]
        [Display(Name = "Height")]
        public decimal Height
        {
            get
            {
                return (GeneralPackageTypeDTO != null && GeneralPackageTypeDTO.Height > 0) ? GeneralPackageTypeDTO.Height : new decimal();
            }
            set
            {
                GeneralPackageTypeDTO.Height = value;
            }
        }

        [Required(ErrorMessage = "Length should not be blank.")]
        [Display(Name = "Length")]
        public decimal Length
        {
            get
            {
                return (GeneralPackageTypeDTO != null && GeneralPackageTypeDTO.Length > 0) ? GeneralPackageTypeDTO.Length : new decimal();
            }
            set
            {
                GeneralPackageTypeDTO.Length = value;
            }
        }
        [Required(ErrorMessage = "Width should not be blank.")]
        [Display(Name = "Width")]
        public decimal Width
        {
            get
            {
                return (GeneralPackageTypeDTO != null && GeneralPackageTypeDTO.Width > 0) ? GeneralPackageTypeDTO.Width : new decimal();
            }
            set
            {
                GeneralPackageTypeDTO.Width = value;
            }
        }
        [Required(ErrorMessage = "Weight should not be blank.")]
        [Display(Name = "Weight")]
        public decimal Weight
        {
            get
            {
                return (GeneralPackageTypeDTO != null && GeneralPackageTypeDTO.Weight > 0) ? GeneralPackageTypeDTO.Weight : new decimal();
            }
            set
            {
                GeneralPackageTypeDTO.Weight = value;
            }
        }
        [Required(ErrorMessage = "Volume should not be blank.")]
        [Display(Name = "Volume")]
        public decimal Volume
        {
            get
            {
                return (GeneralPackageTypeDTO != null && GeneralPackageTypeDTO.Volume > 0) ? GeneralPackageTypeDTO.Volume : new decimal();
            }
            set
            {
                GeneralPackageTypeDTO.Volume = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPackageTypeDTO != null) ? GeneralPackageTypeDTO.IsDeleted : false;
            }
            set
            {
                GeneralPackageTypeDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPackageTypeDTO != null && GeneralPackageTypeDTO.CreatedBy > 0) ? GeneralPackageTypeDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPackageTypeDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPackageTypeDTO != null) ? GeneralPackageTypeDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPackageTypeDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralPackageTypeDTO != null) ? GeneralPackageTypeDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPackageTypeDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralPackageTypeDTO != null) ? GeneralPackageTypeDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPackageTypeDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralPackageTypeDTO != null) ? GeneralPackageTypeDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPackageTypeDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralPackageTypeDTO != null) ? GeneralPackageTypeDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPackageTypeDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

