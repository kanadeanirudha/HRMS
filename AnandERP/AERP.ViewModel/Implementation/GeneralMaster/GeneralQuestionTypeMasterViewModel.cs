
using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralQuestionTypeMasterViewModel : IGeneralQuestionTypeMasterViewModel
    {

        public GeneralQuestionTypeMasterViewModel()
        {
            GeneralQuestionTypeMasterDTO = new GeneralQuestionTypeMaster();
          //  RequestCodeList = new List<GeneralRequestMaster>();
           
        }

        //public List<GeneralRequestMaster> RequestCodeList { get; set; }
        //public IEnumerable<SelectListItem> RequestCodeListItems { get { return new SelectList(RequestCodeList, "RequestCode", "RequestName"); } }
      
        public GeneralQuestionTypeMaster GeneralQuestionTypeMasterDTO
        {
            get;
            set;
        }

        public byte  GeneralQuestionTypeMasterID
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null && GeneralQuestionTypeMasterDTO.GeneralQuestionTypeMasterID > 0) ? GeneralQuestionTypeMasterDTO.GeneralQuestionTypeMasterID : new byte();
            }
            set
            {
                GeneralQuestionTypeMasterDTO.GeneralQuestionTypeMasterID = value;
            }
        }

        [Required(ErrorMessage = "Question Type should not be blank.")]
        [Display(Name = "Question Type")]
        public string QuestionType
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null) ? GeneralQuestionTypeMasterDTO.QuestionType : string.Empty;
            }
            set
            {
                GeneralQuestionTypeMasterDTO.QuestionType = value;
            }
        }

        [Required(ErrorMessage = "Related With should not be blank.")]
        [Display(Name = "Related With")]
        public string RelatedWith
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null) ? GeneralQuestionTypeMasterDTO.RelatedWith : string.Empty;
            }
            set
            {
                GeneralQuestionTypeMasterDTO.RelatedWith = value;
            }
        }
       
        
        
         [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null && GeneralQuestionTypeMasterDTO.CreatedBy > 0) ? GeneralQuestionTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralQuestionTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null) ? GeneralQuestionTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralQuestionTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null) ? GeneralQuestionTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralQuestionTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null) ? GeneralQuestionTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralQuestionTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null) ? GeneralQuestionTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralQuestionTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null) ? GeneralQuestionTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralQuestionTypeMasterDTO.DeletedDate = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralQuestionTypeMasterDTO != null) ? GeneralQuestionTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralQuestionTypeMasterDTO.IsDeleted = value;
            }
        }

        public string errorMessage { get; set; }

       }
}


