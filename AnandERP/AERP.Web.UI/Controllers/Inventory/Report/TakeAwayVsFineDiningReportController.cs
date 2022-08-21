
using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class TakeAwayVsFineDiningReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRetailReportsServiceAccess _RetailReportsServiceAccess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _CentreName = string.Empty;
        protected static string _CentreCode = string.Empty;
        protected static string _granularityName;
        protected static string _granularity = string.Empty;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public TakeAwayVsFineDiningReportController()
        {
            _RetailReportsServiceAccess = new RetailReportsServiceAccess();
            _GeneralUnitsServiceAccess = new GeneralUnitsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            RetailReportsViewModel model = new RetailReportsViewModel();

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            List<SelectListItem> li_GranularityList = new List<SelectListItem>();
            li_GranularityList.Add(new SelectListItem { Text = "Daily",   Value = "1" });
            li_GranularityList.Add(new SelectListItem { Text = "Weekly",  Value = "2" });
            li_GranularityList.Add(new SelectListItem { Text = "Monthly", Value = "3" });
            li_GranularityList.Add(new SelectListItem { Text = "Yearly",  Value = "4" });
            ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text");
           
            return View("/Views/Inventory_1/Report/TakeAwayVsFineDiningReport/Index.cshtml", model);
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
                _CentreCode = model.CentreCode;
                _dateFrom = model.DateFrom;
                _dateTo = model.DateTo;
                _granularity = model.Granularity;
                _CentreName = model.CentreName;
                _granularityName = model.GranularityName;

                ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", model.Granularity);
                model.IsPosted = false;
            }
            else
            {
                model.CentreCode = _CentreCode;
                model.DateFrom = _dateFrom;
                model.DateTo = _dateTo;
                model.Granularity = _granularity;
                model.CentreName = _CentreName;
                model.GranularityName = _granularityName;

                ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", _granularity);
            }

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory_1/Report/TakeAwayVsFineDiningReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<AdminRoleApplicableDetails> GetCentreListByRoleAuthorization()
        {
            RetailReportsViewModel model = new RetailReportsViewModel();
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }
            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
            AdminRoleApplicableDetails a = null;
            foreach (var item in listAdminRoleApplicableDetails)
            {
                a = new AdminRoleApplicableDetails();
                a.CentreCode = item.CentreCode;
                a.CentreName = item.CentreName;
                model.ListGetAdminRoleApplicableCentre.Add(a);
            }
            return model.ListGetAdminRoleApplicableCentre;
        }

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

        public List<RetailReports> GetDinningReportList()
        {
            try
            {
                List<RetailReports> listRetailReports = new List<RetailReports>();
                RetailReportsSearchRequest searchRequest = new RetailReportsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                if(_dateFrom!= null && _dateTo!= null)
                {
                    searchRequest.CentreName = _CentreName;
                    searchRequest.GranularityName = _granularityName;
                    searchRequest.CentreCode = _CentreCode;
                    searchRequest.Granularity = _granularity;
                    searchRequest.DateFrom = _dateFrom;
                    searchRequest.DateTo = _dateTo;
                    IBaseEntityCollectionResponse<RetailReports> baseEntityCollectionResponse = _RetailReportsServiceAccess.GetRetailReportsBySearch_GetDinningReportList(searchRequest);
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
