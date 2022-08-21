using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Web;


namespace AERP.ViewModel
{
    public class EmployeePictureDetailsViewModel
    {

        public EmployeePictureDetailsViewModel()
        {
            EmployeePictureDetailsDTO = new EmployeePictureDetails();
        }

        public EmployeePictureDetails EmployeePictureDetailsDTO
        {
            get;
            set;
        }


        public int EmployeeID
        {
            get
            {
                return (EmployeePictureDetailsDTO != null && EmployeePictureDetailsDTO.EmployeeID > 0) ? EmployeePictureDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeePictureDetailsDTO.EmployeeID = value;
            }
        }

        public byte[] EmployeePicture
        {
            get
            {
                return (EmployeePictureDetailsDTO != null) ? EmployeePictureDetailsDTO.EmployeePicture : new byte[1];         //review this       
            }
            set
            {
                EmployeePictureDetailsDTO.EmployeePicture = value;
            }
        }

        [Display(Name = "Employee Pic File name")] 
        public string EmployeePicFilename
        {
            get
            {
                return (EmployeePictureDetailsDTO != null) ? EmployeePictureDetailsDTO.EmployeePicFilename : string.Empty;
            }
            set
            {
                EmployeePictureDetailsDTO.EmployeePicFilename = value;
            }
        }

        [Display(Name = "Employee Pic Type")]   
        public string EmployeePicType
        {
            get
            {
                return (EmployeePictureDetailsDTO != null) ? EmployeePictureDetailsDTO.EmployeePicType : string.Empty;
            }
            set
            {
                EmployeePictureDetailsDTO.EmployeePicType = value;
            }
        }


        [Display(Name = "Employee Pic File Size")]     
        public string EmployeePicFileSize
        {
            get
            {
                return (EmployeePictureDetailsDTO != null) ? EmployeePictureDetailsDTO.EmployeePicFileSize : string.Empty;
            }
            set
            {
                EmployeePictureDetailsDTO.EmployeePicFileSize = value;
            }
        }


        [Display(Name = "Employee Pic File Width")]
        public string EmployeePicFileWidth
        {
            get
            {
                return (EmployeePictureDetailsDTO != null) ? EmployeePictureDetailsDTO.EmployeePicFileWidth : string.Empty;
            }
            set
            {
                EmployeePictureDetailsDTO.EmployeePicFileWidth = value;
            }
        }


        [Display(Name = "Employee Pic File Height")]
        public string EmployeePicFileHeight
        {
            get
            {
                return (EmployeePictureDetailsDTO != null) ? EmployeePictureDetailsDTO.EmployeePicFileHeight : string.Empty;
            }
            set
            {
                EmployeePictureDetailsDTO.EmployeePicFileHeight = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (EmployeePictureDetailsDTO != null) ? EmployeePictureDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeePictureDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeePictureDetailsDTO != null) ? EmployeePictureDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeePictureDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeePictureDetailsDTO != null && EmployeePictureDetailsDTO.CreatedBy > 0) ? EmployeePictureDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeePictureDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeePictureDetailsDTO != null) ? EmployeePictureDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeePictureDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeePictureDetailsDTO != null && EmployeePictureDetailsDTO.ModifiedBy.HasValue) ? EmployeePictureDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeePictureDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeePictureDetailsDTO != null && EmployeePictureDetailsDTO.ModifiedDate.HasValue) ? EmployeePictureDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeePictureDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeePictureDetailsDTO != null && EmployeePictureDetailsDTO.DeletedBy.HasValue) ? EmployeePictureDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeePictureDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeePictureDetailsDTO != null && EmployeePictureDetailsDTO.DeletedDate.HasValue) ? EmployeePictureDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeePictureDetailsDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

        [Display(Name = "Internet URL")]
        public string Url { get; set; }

        public bool IsUrl { get; set; }

        [Display(Name = "Flickr image")]
        public string Flickr { get; set; }

        public bool IsFlickr { get; set; }

        [Display(Name = "Local file")]
        [Required(ErrorMessage = "Please select the photo")]
        public HttpPostedFileBase File { get; set; }
        public int ID
        {
            get
            {
                return (EmployeePictureDetailsDTO != null && EmployeePictureDetailsDTO.ID > 0) ? EmployeePictureDetailsDTO.ID : new int();
            }
            set
            {
                EmployeePictureDetailsDTO.ID = value;
            }
        }

        public bool IsFile { get; set; }

        [Range(0, int.MaxValue)]
        public int X { get; set; }

        [Range(0, int.MaxValue)]
        public int Y { get; set; }

        [Range(1, int.MaxValue)]
        public int Width { get; set; }

        [Range(1, int.MaxValue)]
        public int Height { get; set; }



    }
}
