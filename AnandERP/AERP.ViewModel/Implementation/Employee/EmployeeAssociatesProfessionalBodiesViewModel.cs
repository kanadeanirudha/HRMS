using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class EmployeeAssociatesProfessionalBodiesViewModel : IEmployeeAssociatesProfessionalBodiesViewModel
    {

        public EmployeeAssociatesProfessionalBodiesViewModel()
        {
            EmployeeAssociatesProfessionalBodiesDTO = new EmployeeAssociatesProfessionalBodies();
        }

        public EmployeeAssociatesProfessionalBodies EmployeeAssociatesProfessionalBodiesDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null && EmployeeAssociatesProfessionalBodiesDTO.ID > 0) ? EmployeeAssociatesProfessionalBodiesDTO.ID : new int();
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null) ? EmployeeAssociatesProfessionalBodiesDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.EmployeeID = value;
            }
        }


        [Display(Name = "DisplayName_ActivityName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ActivityNameRequired")]
        public string ActivityName
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null) ? EmployeeAssociatesProfessionalBodiesDTO.ActivityName : string.Empty;
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.ActivityName = value;
            }
        }

        [Display(Name = "DisplayName_FromPeriod", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_FromPeriodRequired")]
        public string FromPeriod
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null) ? EmployeeAssociatesProfessionalBodiesDTO.FromPeriod : string.Empty;
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.FromPeriod = value;
            }
        }


        [Display(Name = "DisplayName_UptoPeriod", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_UptoPeriodRequired")]
        public string UptoPeriod
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null) ? EmployeeAssociatesProfessionalBodiesDTO.UptoPeriod : string.Empty;
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.UptoPeriod = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null) ? EmployeeAssociatesProfessionalBodiesDTO.IsDeleted : false;
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null && EmployeeAssociatesProfessionalBodiesDTO.CreatedBy > 0) ? EmployeeAssociatesProfessionalBodiesDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null) ? EmployeeAssociatesProfessionalBodiesDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null && EmployeeAssociatesProfessionalBodiesDTO.ModifiedBy.HasValue) ? EmployeeAssociatesProfessionalBodiesDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null && EmployeeAssociatesProfessionalBodiesDTO.ModifiedDate.HasValue) ? EmployeeAssociatesProfessionalBodiesDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null && EmployeeAssociatesProfessionalBodiesDTO.DeletedBy.HasValue) ? EmployeeAssociatesProfessionalBodiesDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeAssociatesProfessionalBodiesDTO != null && EmployeeAssociatesProfessionalBodiesDTO.DeletedDate.HasValue) ? EmployeeAssociatesProfessionalBodiesDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeAssociatesProfessionalBodiesDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

