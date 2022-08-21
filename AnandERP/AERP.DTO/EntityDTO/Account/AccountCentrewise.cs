using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DTO
{
    public class AccountCentrewise: BaseDTO
    {
        /// <summary>
        /// Row Unique ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Account ID
        /// </summary>
        public Nullable<int> AccountID { get; set; }

        /// <summary>
        /// Account Center Code
        /// </summary>
        public string Centrecode { get; set; }

        /// <summary>
        /// Set status of record is currently active or not
        /// </summary>
        public Nullable<bool> IsActive { get; set; }

        /// <summary>
        /// User id of person who created the record
        /// </summary>
        public Nullable<int> CreatedBy { get; set; }

        /// <summary>
        /// Creation date of record
        /// </summary>
        public Nullable<System.DateTime> CreatedDate { get; set; }

        /// <summary>
        /// User id of person who modified the record
        /// </summary>
        public Nullable<int> ModifiedBy { get; set; }

        /// <summary>
        /// Modification date of record
        /// </summary>
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        /// <summary>
        /// User id of person who deleted the record
        /// </summary>
        public Nullable<int> DeletedBy { get; set; }

        /// <summary>
        /// Deletion date of record
        /// </summary>
        public Nullable<System.DateTime> DeletedDate { get; set; }

        /// <summary>
        /// Status for deletion of record
        /// </summary>
        public Nullable<bool> IsDeleted { get; set; }
    }
}
