using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class RetailDrillDownReportViewModel
    {
        public RetailDrillDownReportViewModel()
        {
            RetailDrillDownReportDTO = new RetailDrillDownReport();
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
        public RetailDrillDownReport RetailDrillDownReportDTO { get; set; }

        [Display(Name = "Centre")]
        public string CentreName
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.CentreName : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.CentreName = value;
            }
        }
        [Display(Name = "From Date")]
        public string DateFrom
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.DateFrom : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.DateFrom = value;
            }
        }

        [Display(Name = "To Date")]
        public string DateTo
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.DateTo : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.DateTo = value;
            }
        }

        [Display(Name = "Granularity")]
        public string Granularity
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.Granularity : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.Granularity = value;
            }
        }

        [Display(Name = "Site")]
        public Int32 GeneralUnitsID
        {
            get
            {
                return (RetailDrillDownReportDTO != null && RetailDrillDownReportDTO.GeneralUnitsID > 0) ? RetailDrillDownReportDTO.GeneralUnitsID : new Int32();
            }
            set
            {
                RetailDrillDownReportDTO.GeneralUnitsID = value;
            }
        }
        [Display(Name = "Store")]
        public Int32 GeneralUnitsID1
        {
            get
            {
                return (RetailDrillDownReportDTO != null && RetailDrillDownReportDTO.GeneralUnitsID1 > 0) ? RetailDrillDownReportDTO.GeneralUnitsID1 : new Int32();
            }
            set
            {
                RetailDrillDownReportDTO.GeneralUnitsID1 = value;
            }
        }

        public int SRNo
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.SRNo : new int();
            }
            set
            {
                RetailDrillDownReportDTO.SRNo = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.CentreCode : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.CentreCode = value;
            }
        }
        public bool IsPosted { get; set; }


        [Display(Name = "Payment Mode")]
        public string PaymentMode
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.PaymentMode : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.PaymentMode = value;
            }
        }
        public string CounterName
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.CounterName : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.CounterName = value;
            }
        }
        public decimal card
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.card : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.card = value;
            }
        }
        public decimal SalesQuantity
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.SalesQuantity : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.SalesQuantity = value;
            }
        }
        public decimal cash
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.cash : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.cash = value;
            }
        }
        public decimal TotalCard
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.TotalCard : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.TotalCard = value;
            }
        }
        public decimal TotalCash
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.TotalCash : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.TotalCash = value;
            }
        }
        [Display(Name = "Discount %")]
        public string DiscountInPercent
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.DiscountInPercent : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.DiscountInPercent = value;
            }
        }

        public string type
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.type : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.type = value;
            }
        }
        public string GeneralUnitsList
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.GeneralUnitsList : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.GeneralUnitsList = value;
            }
        }
        public string GranularityList
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.GranularityList : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.GranularityList = value;
            }
        }

        public decimal CashToday
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.CashToday : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.CashToday = value;
            }
        }
        public decimal CashTillLast
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.CashTillLast : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.CashTillLast = value;
            }
        }
        public decimal TotalCashSale
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.TotalCashSale : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.TotalCashSale = value;
            }
        }
        public decimal CardToday
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.CardToday : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.CardToday = value;
            }
        }
        public decimal CardTillLast
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.CardTillLast : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.CardTillLast = value;
            }
        }
        public decimal TotalCardSale
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.TotalCardSale : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.TotalCardSale = value;
            }
        }
        public decimal TotalSale
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.TotalSale : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.TotalSale = value;
            }
        }
        public string BillNumber
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.CentreCode : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.CentreCode = value;
            }
        }
        public decimal BillAmount
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.BillAmount : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.BillAmount = value;
            }
        }
        public decimal TotalBillAmount
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.TotalBillAmount : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.TotalBillAmount = value;
            }
        }

        public string GlobalInvoiceNumber
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.GlobalInvoiceNumber : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.GlobalInvoiceNumber = value;
            }
        }
        public string LocalInvoiceNumber
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.LocalInvoiceNumber : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.LocalInvoiceNumber = value;
            }
        }
        public decimal DiscountAmount
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.DiscountAmount : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.DiscountAmount = value;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.TotalPrice : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.TotalPrice = value;
            }
        }
        public string Item
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.Item : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.Item = value;
            }
        }
        public decimal ConsumptionQuantity
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.ConsumptionQuantity : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.ConsumptionQuantity = value;
            }
        }
        public decimal ConsumptionAmount
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.ConsumptionAmount : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.ConsumptionAmount = value;
            }
        }
        public decimal WastageQuantity
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.WastageQuantity : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.WastageQuantity = value;
            }
        }
        public decimal WastageAmount
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.WastageAmount : new decimal();
            }
            set
            {
                RetailDrillDownReportDTO.WastageAmount = value;
            }
        }
        public List<RetailDrillDownReport> ListAllGranularity { get; set; }

        public string GranularityName
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.GranularityName : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.GranularityName = value;
            }
        }
        public string GeneralUnitsName
        {
            get
            {
                return (RetailDrillDownReportDTO != null) ? RetailDrillDownReportDTO.GeneralUnitsName : string.Empty;
            }
            set
            {
                RetailDrillDownReportDTO.GeneralUnitsName = value;
            }
        }
    }

}

