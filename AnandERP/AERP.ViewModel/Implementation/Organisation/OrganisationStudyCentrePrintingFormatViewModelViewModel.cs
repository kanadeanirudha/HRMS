using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
namespace AERP.ViewModel
{
    public class OrganisationStudyCentrePrintingFormatViewModel : IOrganisationStudyCentrePrintingFormatViewModel
    {

        public OrganisationStudyCentrePrintingFormatViewModel()
        {


            OrganisationStudyCentrePrintingFormatDTO = new OrganisationStudyCentrePrintingFormat();
        }

        public OrganisationStudyCentrePrintingFormat OrganisationStudyCentrePrintingFormatDTO
        {
            get;
            set;
        }

        public List<OrganisationStudyCentrePrintingFormat> ListOrganisationStudyCentrePrintingFormat
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null && OrganisationStudyCentrePrintingFormatDTO.ID > 0) ? OrganisationStudyCentrePrintingFormatDTO.ID : new int();
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.ID = value;
            }
        }

        //[Display(Name = "DisplayName_WeekDescription", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_WeekDescriptionRequired")]
        public string CentreCode
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.CentreCode = value;
            }
        }

        public string CentreName
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.CentreName : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.CentreName = value;
            }
        }

        public string CentrePrintingLine
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.CentrePrintingLine : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.CentrePrintingLine = value;
            }
        }
         [Display(Name = "Printing Line1")]
        public string PrintingLine1
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.PrintingLine1 : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.PrintingLine1 = value;
            }
        }
         [Display(Name = "Printing Line2")]
        public string PrintingLine2
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.PrintingLine2 : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.PrintingLine2 = value;
            }
        }
         [Display(Name = "Printing Line3")]
        public string PrintingLine3
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.PrintingLine3 : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.PrintingLine3 = value;
            }
        }
        [Display(Name = "Printing Line4")]
        public string PrintingLine4
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.PrintingLine4 : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.PrintingLine4 = value;
            }
        }

        #region File Upload

        [Display(Name = "Internet URL")]
        public string Url { get; set; }

        public bool IsUrl { get; set; }

        [Display(Name = "Flickr image")]
        public string Flickr { get; set; }

        public bool IsFlickr { get; set; }

        //[Display(Name = "Local file")]
        //[Required(ErrorMessage = "Please select the photo")]
        public HttpPostedFileBase LogoFile { get; set; }
       
        public bool IsFile { get; set; }

        [Range(0, int.MaxValue)]
        public int X { get; set; }

        [Range(0, int.MaxValue)]
        public int Y { get; set; }

        [Range(1, int.MaxValue)]
        public int Width { get; set; }

        [Range(1, int.MaxValue)]
        public int Height { get; set; }

         [Display(Name = "Logo")]
        public byte[] Logo
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.Logo : new byte[1];         //review this       
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.Logo = value;
            }
        }


        public string LogoType
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.LogoType : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.LogoType = value;
            }
        }


        public string LogoFilename
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.LogoFilename : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.LogoFilename = value;
            }
        }

        public string LogoFileWidth
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.LogoFileWidth : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.LogoFileWidth = value;
            }
        }


        public string LogoFileHeight
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.LogoFileHeight : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.LogoFileHeight = value;
            }
        }


        public string LogoFileSize
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.LogoFileSize : string.Empty;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.LogoFileSize = value;
            }
        }
        #endregion File Upload
        [Display(Name = "StatusFlag")]
        public bool StatusFlag
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.StatusFlag : false;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.StatusFlag = value;
            }
        }



       

         [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.IsDeleted : false;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null && OrganisationStudyCentrePrintingFormatDTO.CreatedBy > 0) ? OrganisationStudyCentrePrintingFormatDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null) ? OrganisationStudyCentrePrintingFormatDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null && OrganisationStudyCentrePrintingFormatDTO.ModifiedBy.HasValue) ? OrganisationStudyCentrePrintingFormatDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null && OrganisationStudyCentrePrintingFormatDTO.ModifiedDate.HasValue) ? OrganisationStudyCentrePrintingFormatDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null && OrganisationStudyCentrePrintingFormatDTO.DeletedBy.HasValue) ? OrganisationStudyCentrePrintingFormatDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationStudyCentrePrintingFormatDTO != null && OrganisationStudyCentrePrintingFormatDTO.DeletedDate.HasValue) ? OrganisationStudyCentrePrintingFormatDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationStudyCentrePrintingFormatDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }

    }
}
