using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralQuestionTypeMaster : BaseDTO
    {
        public byte GeneralQuestionTypeMasterID
        {
            get;
            set;
        }

        public string QuestionType
        {
            get;
            set;
        }
        public String RelatedWith
        {
            get;
            set;
        }
       
          public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }

        public string errorMessage { get; set; }
        // public string MenuCode { get; set; }
    }
}
