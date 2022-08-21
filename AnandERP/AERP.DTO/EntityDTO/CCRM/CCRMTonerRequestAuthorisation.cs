using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;

namespace AERP.DTO
{
   public class CCRMTonerRequestAuthorisation:BaseDTO
    {
        public Int32 ID { get; set; }

        public string CallTktNo { get; set; }
        public string CallDate { get; set; }
        public string SerialNo { get; set; }
        public Int32 MIFID { get; set; }
        public string MIFName { get; set; }
        public string ModelNo { get; set; }
        public Int16 MachineFamilyID { get; set; }
        public string MachineFamilyName { get; set; }
        public string ContractCode { get; set; }
        public Int32 ContractID { get; set; }
        public string PartNO { get; set; }
        public Int32 BalanceQuantity { get; set; }
        public string PartName { get; set; }
        public Int32 CallId { get; set; }
        public string CallerName { get; set; }
        public string CallerPh { get; set; }
        public string ItemName { get; set; }
        public string ItemCategoryCode { get; set; }
        public Int32 CurrentMeterRead { get; set; }
        public Int32 Quantity { get; set; }
        public bool FOC { get; set; }
        public string LastCallDate { get; set; }
        public Int32 LastCallNo { get; set; }
        public Int32 LastQuantity { get; set; }
        public Int32 LastMtrRead { get; set; }
        public Int32 Consumption { get; set; }
        public string Remarks { get; set; }
        public Int32 StandardCopy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public Int32 ContractTypeID { get; set; }
        public string ItemDescription { get; set; }
        public Int32 PartNOID { get; set; }
        public Int32 CallNo { get; set; }
        public Int32 ItemNumber { get; set; }
        public byte Authorised { get; set; }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public bool Date { get; set; }
    }
}
