using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;


namespace AERP.DTO
{
  public  class CCRMContractMaster :BaseDTO
    {
        public Int32 ID { get; set; }

        public string ContractNo { get; set; }
        public string ContractDate { get; set; }
        public Int32 CustomerMasterID { get; set; }
        public string CustomerName { get; set; }
        public string MIFAddress { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerAddress { get; set; }
        public string Colour { get; set; }
        public string PaperSize { get; set; }
        public Int32 ContractTypeId { get; set; }
        public string ContractType { get; set; }
        public string ContractOpDate { get; set; }
        public string ContractClosingDate { get; set; }
        public Int32 ContractPeriod { get; set; }
        public Int32 MIFMasterId { get; set; }
        public string MIFName { get; set; }
        public Int32 ModelId { get; set; }
        public string ModelNo { get; set; }
        public string SerialNo { get; set; }
        public decimal RentalAmt { get; set; }
        public Int32 StartReadA4Mono { get; set; }
        public Int32 StartReadA4Col { get; set; }
        public Int32 StartReadA3Mono { get; set; }
        public Int32 StartReadA3Col { get; set; }
        public Int32 EndReadA4Mono { get; set; }
        public Int32 EndReadA4Col { get; set; }
        public Int32 EndReadA3Mono { get; set; }
        public Int32 EndReadA3Col { get; set; }
        public decimal RentPerCopyA4Mono { get; set; }
        public decimal RentPerCopyA4Col { get; set; }
        public decimal RentPerCopyA3Col { get; set; }
        public decimal RentPerCopyA3Mono { get; set; }
        public byte ContractStatus { get; set; }
        public string ContractTypeName { get; set; }
        public decimal ContractValue { get; set; }
        public decimal BilledValue { get; set; }
        public Int32 FreeCopiesA4Mono { get; set; }
        public Int32 FreeCopiesA3Mono { get; set; }
        public Int32 FreeCopiesA4Col { get; set; }
        public Int32 FreeCopiesA3Col { get; set; }
        public Int32 MinCopiesA4Mono { get; set; }
        public Int32 MinCopiesA4Col { get; set; }
        public Int32 MinCopiesA3Mono { get; set; }
        public Int32 MinCopiesA3Col { get; set; }
        public Int32 TotalFreeA4Mono { get; set; }
        public Int32 TotalFreeA4Col { get; set; }
        public Int32 TotalFreeA3Mono { get; set; }
        public Int32 TotalFreeA3Col { get; set; }
        public Int32 InitFreeCopiesA4Mono { get; set; }
        public Int32 InitFreeCopiesA3Mono { get; set; }
        public Int32 InitFreeCopiesA4Col { get; set; }
        public Int32 InitFreeCopiesA3Col { get; set; }
        public decimal WastePerc { get; set; }
        public decimal STComponent { get; set; }
        public decimal STAmount { get; set; }
        public decimal VATComponent { get; set; }
        public decimal VATAmount { get; set; }
        public decimal VATPerc { get; set; }
        public Int32 PMPeriod { get; set; }
        public Int32 CallsAllowed { get; set; }
        public string CustOrderNo { get; set; }
        public string CustOrderDate { get; set; }
        public string BillType { get; set; }
        public Int32 BillTypeId { get; set; }
        public byte ApplicableMonth { get; set; }
        public string Remarks { get; set; }
        public string CloseDate { get; set; }
        public decimal BasicCharges { get; set; }
        public decimal AnnualCharges { get; set; }
        public Int32 AnnChrBillMonth { get; set; }
        public Int32 FinancialyearID { get; set; }
        public Int32 OrderNo { get; set; }
       
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public Int32 ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public string ContractName { get; set; }
        public bool Jan { get; set; }
        public bool Feb { get; set; }
        public bool Mar { get; set; }
        public bool Apr { get; set; }
        public bool May { get; set; }
        public bool Jun { get; set; }
        public bool Jul { get; set; }
        public bool Aug { get; set; }
        public bool Sep { get; set; }
        public bool Oct { get; set; }
        public bool Nov { get; set; }
        public bool Dec { get; set; }
    }
}
