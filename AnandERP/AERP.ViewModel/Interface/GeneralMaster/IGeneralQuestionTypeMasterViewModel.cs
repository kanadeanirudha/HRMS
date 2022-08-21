
using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralQuestionTypeMasterViewModel
    {
        GeneralQuestionTypeMaster GeneralQuestionTypeMasterDTO
        {
            get;
            set;
        }

        byte GeneralQuestionTypeMasterID
        {
            get;
            set;
        }
        string QuestionType
        {
            get;
            set;
        }

        string RelatedWith
        {
            get;
            set;
        }
       
        
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        string errorMessage { get; set; }
       // List<GeneralRequestMaster> RequestCodeList { get; set; }
    }
}
