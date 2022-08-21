using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class InventoryBillDetailReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRetailReportsServiceAccess _RetailReportsServiceAccess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        public string _ReportFor { get; set; }
        protected static string _ReportForPage;
        protected static int _generalUnitsID = 0;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static string paymentMode = string.Empty;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryBillDetailReportController()
        {
            _RetailReportsServiceAccess = new RetailReportsServiceAccess();
            _GeneralUnitsServiceAccess = new GeneralUnitsServiceAccess();
            
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            RetailReportsViewModel model = new RetailReportsViewModel();
           
            List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster();
            List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            foreach (GeneralUnits item in GeneralUnits)
            {
                GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");


            List<SelectListItem> PaymentMode = new List<SelectListItem>();
            ViewBag.PaymentMode = new SelectList(PaymentMode, "Value", "Text");
            List<SelectListItem> li_PaymentMode = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });s
            li_PaymentMode.Add(new SelectListItem { Text = "All", Value = "2" });
            li_PaymentMode.Add(new SelectListItem { Text = "Cash", Value = "1" });
            li_PaymentMode.Add(new SelectListItem { Text = "Card", Value = "0" });

            ViewData["PaymentMode"] = li_PaymentMode;

            return View("/Views/Inventory_1/Report/InventoryBillDetailReport/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(RetailReportsViewModel model)
        {
            List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster();
            List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            foreach (GeneralUnits item in GeneralUnits)
            {
                GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");

            if (model.IsPosted == true)
            {
                _generalUnitsID = model.GeneralUnitsID1;
                _dateFrom = model.DateFrom;
                _dateTo = model.DateTo;
                paymentMode = model.PaymentMode;
                model.IsPosted = false;

            }
            else
            {
                model.GeneralUnitsID1 = _generalUnitsID;
                model.DateFrom = _dateFrom;
                model.DateTo = _dateTo;
                model.PaymentMode = paymentMode;
            }
            List<SelectListItem> PaymentMode = new List<SelectListItem>();
            ViewBag.PaymentMode = new SelectList(PaymentMode, "Value", "Text");
            List<SelectListItem> li_PaymentMode = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
            li_PaymentMode.Add(new SelectListItem { Text = "All", Value = "2" });
            li_PaymentMode.Add(new SelectListItem { Text = "Cash", Value = "1" });
            li_PaymentMode.Add(new SelectListItem { Text = "Card", Value = "0" });

            ViewData["PaymentMode"] = new SelectList(li_PaymentMode, "Value", "Text", (model.RetailReportsDTO.PaymentMode).ToString().Trim());

            return View("/Views/Inventory_1/Report/InventoryBillDetailReport/Index.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
       
        protected List<GeneralUnits> GetGeneralUnitsForItemmaster()
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralUnits> ListGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsServiceAccess.GetGeneralUnitsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }
        public List<RetailReports> GetInventoryBillDetailReportList()
        {
            try
            {
                List<RetailReports> listRetailReports = new List<RetailReports>();
                RetailReportsSearchRequest searchRequest = new RetailReportsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                if (_generalUnitsID > 0 && _dateFrom != string.Empty && _dateTo != string.Empty)
                {
                    searchRequest.GeneralUnitsID = _generalUnitsID;
                    searchRequest.DateFrom = _dateFrom;
                    searchRequest.DateTo = _dateTo;
                    searchRequest.PaymentMode = paymentMode;

                    IBaseEntityCollectionResponse<RetailReports> baseEntityCollectionResponse = _RetailReportsServiceAccess.GetInventoryBillDetailReportBySearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listRetailReports = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listRetailReports;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion
    }
}
