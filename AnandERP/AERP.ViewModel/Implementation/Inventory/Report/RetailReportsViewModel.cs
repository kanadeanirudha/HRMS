using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class RetailReportsViewModel
    {
        public RetailReportsViewModel()
        {
            RetailReportsDTO = new RetailReports();
            ListGeneralUnits = new List<GeneralUnits>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public List<GeneralUnits> ListGeneralUnits
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        {
            get
            {
                return new SelectList(ListGeneralUnits, "ID", "UnitName");
            }
        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public RetailReports RetailReportsDTO { get; set; }


        [Display(Name = "From Date")]
        public string DateFrom
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.DateFrom : string.Empty;
            }
            set
            {
                RetailReportsDTO.DateFrom = value;
            }
        }

        [Display(Name = "To Date")]
        public string DateTo
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.DateTo : string.Empty;
            }
            set
            {
                RetailReportsDTO.DateTo = value;
            }
        }

        [Display(Name = "Granularity")]
        public string Granularity
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.Granularity : string.Empty;
            }
            set
            {
                RetailReportsDTO.Granularity = value;
            }
        }

        [Display(Name = "Site")]
        public Int32 GeneralUnitsID
        {
            get
            {
                return (RetailReportsDTO != null && RetailReportsDTO.GeneralUnitsID > 0) ? RetailReportsDTO.GeneralUnitsID : new Int32();
            }
            set
            {
                RetailReportsDTO.GeneralUnitsID = value;
            }
        }
        [Display(Name = "Store")]
        public Int32 GeneralUnitsID1
        {
            get
            {
                return (RetailReportsDTO != null && RetailReportsDTO.GeneralUnitsID1 > 0) ? RetailReportsDTO.GeneralUnitsID1 : new Int32();
            }
            set
            {
                RetailReportsDTO.GeneralUnitsID1 = value;
            }
        }

        public int SRNo
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.SRNo : new int();
            }
            set
            {
                RetailReportsDTO.SRNo = value;
            }
        }
        [Display(Name = "Centre")]
        public string CentreCode
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.CentreCode : string.Empty;
            }
            set
            {
                RetailReportsDTO.CentreCode = value;
            }
        }
        public bool IsPosted { get; set; }


        [Display(Name = "Payment Mode")]
        public string PaymentMode
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.PaymentMode : string.Empty;
            }
            set
            {
                RetailReportsDTO.PaymentMode = value;
            }
        }
        public string CounterName
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.CounterName : string.Empty;
            }
            set
            {
                RetailReportsDTO.CounterName = value;
            }
        }
        public decimal card
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.card : new decimal();
            }
            set
            {
                RetailReportsDTO.card = value;
            }
        }
        public decimal SalesQuantity
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.SalesQuantity : new decimal();
            }
            set
            {
                RetailReportsDTO.SalesQuantity = value;
            }
        }
        public decimal cash
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.cash : new decimal();
            }
            set
            {
                RetailReportsDTO.cash = value;
            }
        }
        public decimal TotalCard
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.TotalCard : new decimal();
            }
            set
            {
                RetailReportsDTO.TotalCard = value;
            }
        }
        public decimal TotalCash
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.TotalCash : new decimal();
            }
            set
            {
                RetailReportsDTO.TotalCash = value;
            }
        }
        [Display(Name = "Discount %")]
        public string DiscountInPercent
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.DiscountInPercent : string.Empty;
            }
            set
            {
                RetailReportsDTO.DiscountInPercent = value;
            }
        }

        public string type
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.type : string.Empty;
            }
            set
            {
                RetailReportsDTO.type = value;
            }
        }
        public string GeneralUnitsList
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.GeneralUnitsList : string.Empty;
            }
            set
            {
                RetailReportsDTO.GeneralUnitsList = value;
            }
        }
        public string GranularityList
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.GranularityList : string.Empty;
            }
            set
            {
                RetailReportsDTO.GranularityList = value;
            }
        }

        public decimal CashToday
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.CashToday : new decimal();
            }
            set
            {
                RetailReportsDTO.CashToday = value;
            }
        }
        public decimal CashTillLast
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.CashTillLast : new decimal();
            }
            set
            {
                RetailReportsDTO.CashTillLast = value;
            }
        }
        public decimal TotalCashSale
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.TotalCashSale : new decimal();
            }
            set
            {
                RetailReportsDTO.TotalCashSale = value;
            }
        }
        public decimal CardToday
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.CardToday : new decimal();
            }
            set
            {
                RetailReportsDTO.CardToday = value;
            }
        }
        public decimal CardTillLast
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.CardTillLast : new decimal();
            }
            set
            {
                RetailReportsDTO.CardTillLast = value;
            }
        }
        public decimal TotalCardSale
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.TotalCardSale : new decimal();
            }
            set
            {
                RetailReportsDTO.TotalCardSale = value;
            }
        }
        public decimal TotalSale
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.TotalSale : new decimal();
            }
            set
            {
                RetailReportsDTO.TotalSale = value;
            }
        }
        public string BillNumber
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.CentreCode : string.Empty;
            }
            set
            {
                RetailReportsDTO.CentreCode = value;
            }
        }
        public decimal BillAmount
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.BillAmount : new decimal();
            }
            set
            {
                RetailReportsDTO.BillAmount = value;
            }
        }
        public decimal TotalBillAmount
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.TotalBillAmount : new decimal();
            }
            set
            {
                RetailReportsDTO.TotalBillAmount = value;
            }
        }

        public string GlobalInvoiceNumber
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.GlobalInvoiceNumber : string.Empty;
            }
            set
            {
                RetailReportsDTO.GlobalInvoiceNumber = value;
            }
        }
        public string LocalInvoiceNumber
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.LocalInvoiceNumber : string.Empty;
            }
            set
            {
                RetailReportsDTO.LocalInvoiceNumber = value;
            }
        }
        public decimal DiscountAmount
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.DiscountAmount : new decimal();
            }
            set
            {
                RetailReportsDTO.DiscountAmount = value;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.TotalPrice : new decimal();
            }
            set
            {
                RetailReportsDTO.TotalPrice = value;
            }
        }
        public string Item
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.Item : string.Empty;
            }
            set
            {
                RetailReportsDTO.Item = value;
            }
        }
        public decimal ConsumptionQuantity
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.ConsumptionQuantity : new decimal();
            }
            set
            {
                RetailReportsDTO.ConsumptionQuantity = value;
            }
        }
        public decimal ConsumptionAmount
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.ConsumptionAmount : new decimal();
            }
            set
            {
                RetailReportsDTO.ConsumptionAmount = value;
            }
        }
        public decimal WastageQuantity
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.WastageQuantity : new decimal();
            }
            set
            {
                RetailReportsDTO.WastageQuantity = value;
            }
        }
        public decimal WastageAmount
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.WastageAmount : new decimal();
            }
            set
            {
                RetailReportsDTO.WastageAmount = value;
            }
        }
        public List<RetailReports> ListAllGranularity { get; set; }

        public string GranularityName
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.GranularityName : string.Empty;
            }
            set
            {
                RetailReportsDTO.GranularityName = value;
            }
        }
        public string GeneralUnitsName
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.GeneralUnitsName : string.Empty;
            }
            set
            {
                RetailReportsDTO.GeneralUnitsName = value;
            }
        }
        [Display(Name = "Centre")]
        public string CentreName
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.CentreName : string.Empty;
            }
            set
            {
                RetailReportsDTO.CentreName = value;
            }
        }
        public bool StatusFlag
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.StatusFlag : false;
            }
            set
            {
                RetailReportsDTO.StatusFlag = value;
            }
        }
        public string DiscountType
        {
            get
            {
                return (RetailReportsDTO != null) ? RetailReportsDTO.DiscountType : string.Empty;
            }
            set
            {
                RetailReportsDTO.DiscountType = value;
            }
        }
    }

}

