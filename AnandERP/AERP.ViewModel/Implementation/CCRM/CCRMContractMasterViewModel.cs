using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
   public class CCRMContractMasterViewModel :ICCRMContractMasterViewModel
    {
        public CCRMContractMasterViewModel()
        {
            CCRMContractMasterDTO = new CCRMContractMaster();
        }
        public CCRMContractMaster CCRMContractMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMContractMasterDTO != null && CCRMContractMasterDTO.ID > 0) ? CCRMContractMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.ID = value;
            }
        }
        [Display(Name = "Contract No")]
     
        public string ContractNo
        {
            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractNo : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.ContractNo = value;
            }
        }
        [Display(Name = "Contract Date")]
        public string ContractDate
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractDate : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.ContractDate = value;
            }
        }
        [Display(Name = "MIF Address")]
        public string MIFAddress
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.MIFAddress : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.MIFAddress = value;
            }
        }
        [Display(Name = "Customer Address")]
        public string CustomerAddress
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.CustomerAddress : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.CustomerAddress = value;
            }
        }
        [Display(Name = "Colour/Mono")]
        public string Colour
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Colour : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.Colour = value;
            }
        }
        [Display(Name = "Paper Size")]
        public string PaperSize
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.PaperSize : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.PaperSize = value;
            }
        }
        [Display(Name = "CustomerMaster ID")]
        public Int32 CustomerMasterID
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.CustomerMasterID : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.CustomerName : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.CustomerName = value;
            }
        }
        [Display(Name = "Customer Code")]
        public string CustomerCode
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.CustomerCode : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.CustomerCode = value;
            }
        }
        public Int32 ContractTypeId
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractTypeId : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.ContractTypeId = value;
            }
        }
        [Display(Name = "Contract Type")]
       // [Required(ErrorMessage = "Contract Type Required")]
        public string ContractType
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractType : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.ContractType = value;
            }
        }
        [Display(Name = "Contract Op Date")]
        public string ContractOpDate
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractOpDate : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.ContractOpDate = value;
            }
        }
        [Display(Name = "Contract Closing Date")]
        public string ContractClosingDate
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractClosingDate : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.ContractClosingDate = value;
            }
        }
        [Display(Name = "Contract Period")]
        public Int32 ContractPeriod
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractPeriod : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.ContractPeriod = value;
            }
        }
        public Int32 MIFMasterId
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.MIFMasterId : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.MIFMasterId = value;
            }
        }
        [Display(Name = "MIF Name")]
        public string MIFName
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.MIFName = value;
            }
        }
        [Display(Name = "Model No")]
        public string ModelNo
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.ModelNo = value;
            }
        }
        [Display(Name = "Serial No")]
        //[Required(ErrorMessage = "Serial No Required")]
        public string SerialNo
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.SerialNo = value;
            }
        }
        [Display(Name = "Rental Amt")]
        public decimal RentalAmt
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.RentalAmt : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.RentalAmt = value;
            }
        }
        public Int32 StartReadA4Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.StartReadA4Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.StartReadA4Mono = value;
            }
        }
        public Int32 StartReadA4Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.StartReadA4Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.StartReadA4Col = value;
            }
        }
        public Int32 StartReadA3Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.StartReadA3Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.StartReadA3Mono = value;
            }
        }
        public Int32 StartReadA3Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.StartReadA3Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.StartReadA3Col = value;
            }
        }
        public Int32 EndReadA4Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.EndReadA4Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.EndReadA4Mono = value;
            }
        }
        public Int32 EndReadA4Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.EndReadA4Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.EndReadA4Col = value;
            }
        }
        public Int32 EndReadA3Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.EndReadA3Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.EndReadA3Mono = value;
            }
        }
        public Int32 EndReadA3Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.EndReadA3Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.EndReadA3Col = value;
            }
        }
        public decimal RentPerCopyA4Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.RentPerCopyA4Mono : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.RentPerCopyA4Mono = value;
            }
        }
        public decimal RentPerCopyA4Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.RentPerCopyA4Col : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.RentPerCopyA4Col = value;
            }
        }
        public decimal RentPerCopyA3Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.RentPerCopyA3Col : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.RentPerCopyA3Col = value;
            }
        }
        public decimal RentPerCopyA3Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.RentPerCopyA3Mono : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.RentPerCopyA3Mono = value;
            }
        }
        [Display(Name = "Contract Status")]
        public byte ContractStatus
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractStatus : new byte();
            }
            set
            {
                CCRMContractMasterDTO.ContractStatus = value;
            }
        }

        [Display(Name = "Contract Type Name")]
        public string ContractTypeName
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractTypeName :string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.ContractTypeName = value;
            }
        }

        [Display(Name = "Contract Value")]
        public decimal ContractValue
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractValue : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.ContractValue = value;
            }
        }
        [Display(Name = "Billed Value")]
        public decimal BilledValue
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.BilledValue : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.BilledValue = value;
            }
        }
        public Int32 FreeCopiesA4Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.FreeCopiesA4Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.FreeCopiesA4Mono = value;
            }
        }
        public Int32 FreeCopiesA3Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.FreeCopiesA3Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.FreeCopiesA3Mono = value;
            }
        }
        public Int32 FreeCopiesA4Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.FreeCopiesA4Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.FreeCopiesA4Col = value;
            }
        }
        public Int32 FreeCopiesA3Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.FreeCopiesA3Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.FreeCopiesA3Col = value;
            }
        }
        public Int32 MinCopiesA4Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.MinCopiesA4Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.MinCopiesA4Mono = value;
            }
        }
        public Int32 MinCopiesA4Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.MinCopiesA4Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.MinCopiesA4Col = value;
            }
        }
        public Int32 MinCopiesA3Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.MinCopiesA3Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.MinCopiesA3Mono = value;
            }
        }
        public Int32 MinCopiesA3Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.MinCopiesA3Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.MinCopiesA3Col = value;
            }
        }
        public Int32 TotalFreeA4Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.TotalFreeA4Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.TotalFreeA4Mono = value;
            }
        }
        public Int32 TotalFreeA4Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.TotalFreeA4Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.TotalFreeA4Col = value;
            }
        }
        public Int32 TotalFreeA3Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.TotalFreeA3Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.TotalFreeA3Mono = value;
            }
        }
        public Int32 TotalFreeA3Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.TotalFreeA3Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.TotalFreeA3Col = value;
            }
        }
        public Int32 InitFreeCopiesA4Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.InitFreeCopiesA4Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.InitFreeCopiesA4Mono = value;
            }
        }
        public Int32 InitFreeCopiesA3Mono
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.InitFreeCopiesA3Mono : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.InitFreeCopiesA3Mono = value;
            }
        }
        public Int32 InitFreeCopiesA4Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.InitFreeCopiesA4Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.InitFreeCopiesA4Col = value;
            }
        }
        public Int32 InitFreeCopiesA3Col
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.InitFreeCopiesA3Col : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.InitFreeCopiesA3Col = value;
            }
        }
        [Display(Name = "Waste%")]
        public decimal WastePerc
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.WastePerc : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.WastePerc = value;
            }
        }
        public decimal STComponent
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.STComponent : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.STComponent = value;
            }
        }
        public decimal STAmount
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.STAmount : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.STAmount = value;
            }
        }
        public decimal VATComponent
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.VATComponent : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.VATComponent = value;
            }
        }
        public decimal VATAmount
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.VATAmount : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.VATAmount = value;
            }
        }
        [Display(Name = "VAT Perc")]
        public decimal VATPerc
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.VATPerc : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.VATPerc = value;
            }
        }
        [Display(Name = "PM Period")]
        public Int32 PMPeriod
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.PMPeriod : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.PMPeriod = value;
            }
        }
        [Display(Name = "Calls Allowed")]
        public Int32 CallsAllowed
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.CallsAllowed : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.CallsAllowed = value;
            }
        }
        [Display(Name = "Cust Order NO")]
        public string CustOrderNo
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.CustOrderNo : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.CustOrderNo = value;
            }
        }
        [Display(Name = "Cust Order Date")]
        public string CustOrderDate
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.CustOrderDate : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.CustOrderDate = value;
            }
        }
        //[Required(ErrorMessage = "Bill Type  Required.")]
        [Display(Name = "Bill Type")]
        public string BillType
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.BillType : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.BillType = value;
            }
        }
        public Int32 BillTypeId
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.BillTypeId : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.BillTypeId = value;
            }
        }
        [Display(Name = "Applicable Month")]
        public byte ApplicableMonth
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ApplicableMonth : new byte();
            }
            set
            {
                CCRMContractMasterDTO.ApplicableMonth = value;
            }
        }
        public string Remarks
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Remarks : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.Remarks = value;
            }
        }
        [Display(Name = "Close Date")]
        public string CloseDate
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.CloseDate : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.CloseDate = value;
            }
        }
        [Display(Name = "Basic Charges")]
        public decimal BasicCharges
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.BasicCharges : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.BasicCharges = value;
            }
        }
        [Display(Name = "Annual Charges")]
        public decimal AnnualCharges
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.AnnualCharges : new decimal();
            }
            set
            {
                CCRMContractMasterDTO.AnnualCharges = value;
            }
        }
        public Int32 AnnChrBillMonth
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.AnnChrBillMonth : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.AnnChrBillMonth = value;
            }
        }
        [Display(Name = "Financial year")]
        public Int32 FinancialyearID
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.FinancialyearID : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.FinancialyearID = value;
            }
        }
        [Display(Name = "Order No")]
        public Int32 OrderNo
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.OrderNo : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.OrderNo = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMContractMasterDTO != null && CCRMContractMasterDTO.CreatedBy > 0) ? CCRMContractMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMContractMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMContractMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMContractMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMContractMasterDTO != null && CCRMContractMasterDTO.ModifiedBy.HasValue) ? CCRMContractMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMContractMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMContractMasterDTO != null && CCRMContractMasterDTO.ModifiedDate.HasValue) ? CCRMContractMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMContractMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMContractMasterDTO != null && CCRMContractMasterDTO.DeletedBy.HasValue) ? CCRMContractMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMContractMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMContractMasterDTO != null && CCRMContractMasterDTO.DeletedDate.HasValue) ? CCRMContractMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMContractMasterDTO.DeletedDate = value;
            }
        }
        public Int32 ItemNumber
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ItemNumber : new Int32();
            }
            set
            {
                CCRMContractMasterDTO.ItemNumber = value;
            }
        }
       
        public string ItemDescription
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.ItemDescription = value;
            }
        }
        public string ContractName
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.ContractName : string.Empty;
            }
            set
            {
                CCRMContractMasterDTO.ContractName = value;
            }
        }
        public bool Jan
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Jan : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Jan = value;
            }
        }
        public bool Feb
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Feb : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Feb = value;
            }
        }
        public bool Mar
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Mar : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Mar = value;
            }
        }
        public bool Apr
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Apr : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Apr = value;
            }
        }
        public bool May
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.May : new bool();
            }
            set
            {
                CCRMContractMasterDTO.May = value;
            }
        }
        public bool Jun
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Jun : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Jun = value;
            }
        }
        public bool Jul
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Jul : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Jul = value;
            }
        }
        public bool Aug
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Aug : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Aug = value;
            }
        }
        public bool Sep
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Sep : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Sep = value;
            }
        }
        public bool Oct
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Oct : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Oct = value;
            }
        }
        public bool Nov
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Nov : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Nov = value;
            }
        }
        public bool Dec
        {

            get
            {
                return (CCRMContractMasterDTO != null) ? CCRMContractMasterDTO.Dec : new bool();
            }
            set
            {
                CCRMContractMasterDTO.Dec = value;
            }
        }
    }
}
