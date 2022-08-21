using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DTO
{
    public class AccountPersonalDetails : BaseDTO
    {
        public int ID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public Nullable<int> AddressTypeID { get; set; }
        public string PersonAddress1 { get; set; }
        public string PlotNumber { get; set; }
        public string StreetName { get; set; }
        public Nullable<int> TahsilID { get; set; }
        public string Pincode { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string MailAddress { get; set; }
        public string WebAddress { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
