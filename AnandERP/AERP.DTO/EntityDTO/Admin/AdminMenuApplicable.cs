using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AdminMenuApplicable : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string MenuCode
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }

        public string MenuApplicableTo
        {
            get;
            set;
        }

        public DateTime EnableDate
        {
            get;
            set;
        }

        public DateTime DisableDate
        {
            get;
            set;
        }

        public string DisablePurpose
        {
            get;
            set;
        }

        public bool IsActive
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

        public int? ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
