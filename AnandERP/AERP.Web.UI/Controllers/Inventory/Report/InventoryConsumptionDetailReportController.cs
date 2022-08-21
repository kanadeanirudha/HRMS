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
    public class InventoryConsumptionDetailReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRetailReportsServiceAccess _RetailReportsServiceAccess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        private readonly ILogger _logException;
        protected static Int32 _generalUnitsID;
        protected static string _granularity = string.Empty;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static string _generalUnitsName = string.Empty;
        protected static string _granularityName = string.Empty;
    
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryConsumptionDetailReportController()
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
            //for Granularity
            List<SelectListItem> li_GranularityList = new List<SelectListItem>();
            li_GranularityList.Add(new SelectListItem { Text = "Daily", Value = "1" });
            li_GranularityList.Add(new SelectListItem { Text = "Weekly", Value = "2" });
            li_GranularityList.Add(new SelectListItem { Text = "Monthly", Value = "3" });
            li_GranularityList.Add(new SelectListItem { Text = "Yearly", Value = "4" });
            ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text");
            
            //For cafe
            List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            foreach (GeneralUnits item in GeneralUnits)
            {
                GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");

            return View("/Views/Inventory_1/Report/InventoryConsumptionDetailReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(RetailReportsViewModel model)
        {

            List<SelectListItem> li_GranularityList = new List<SelectListItem>();
            li_GranularityList.Add(new SelectListItem { Text = "Daily", Value = "1" });
            li_GranularityList.Add(new SelectListItem { Text = "Weekly", Value = "2" });
            li_GranularityList.Add(new SelectListItem { Text = "Monthly", Value = "3" });
            li_GranularityList.Add(new SelectListItem { Text = "Yearly", Value = "4" });

            if (model.IsPosted == true)
            {
                _generalUnitsID = model.GeneralUnitsID;
                _dateFrom = model.DateFrom;
                _dateTo = model.DateTo;
                _granularity = model.Granularity;
                _generalUnitsName = model.GeneralUnitsName;
                _granularityName = model.GranularityName;

                ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", model.Granularity);
                model.IsPosted = false;
            }
            else
            {
                model.GeneralUnitsID = _generalUnitsID;
                model.DateFrom = _dateFrom;
                model.DateTo = _dateTo;
                model.Granularity = _granularity;
                model.GeneralUnitsName = _generalUnitsName;
                model.GranularityName =  _granularityName;

                ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", _granularity);
            }



            List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster();
            List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            foreach (GeneralUnits item in GeneralUnits)
            {
                GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text", model.GeneralUnitsID);


            return View("/Views/Inventory_1/Report/InventoryConsumptionDetailReport/Index.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        // Dropdown for General Units
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

        public List<RetailReports> GetInventoryConsumptionDetailReportList()
        {
            try
            {
                List<RetailReports> listRetailReports = new List<RetailReports>();
                RetailReportsSearchRequest searchRequest = new RetailReportsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                if (_dateFrom != null && _dateTo != null)
                {
                    searchRequest.GeneralUnitsName = _generalUnitsName;
                    searchRequest.GranularityName  = _granularityName;
                    searchRequest.GeneralUnitsID   = _generalUnitsID;
                    searchRequest.Granularity      = _granularity;
                    searchRequest.DateFrom = _dateFrom;
                    searchRequest.DateTo = _dateTo;
                    IBaseEntityCollectionResponse<RetailReports> baseEntityCollectionResponse = _RetailReportsServiceAccess.GetConsumptionDetailReportBySearch(searchRequest);
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
