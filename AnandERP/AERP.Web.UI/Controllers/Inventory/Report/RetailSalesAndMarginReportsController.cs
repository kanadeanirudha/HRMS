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
    public class RetailSalesAndMarginReportsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRetailReportsServiceAccess _RetailReportsServiceAccess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAcess = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static int _generalUnitsID = 0;
        protected static string _dateFrom = string.Empty;
        protected static string _generalUnitsName = string.Empty;
        protected static string _granularityName = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static string _granularity = string.Empty;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public RetailSalesAndMarginReportsController()
        {
            _RetailReportsServiceAccess = new RetailReportsServiceAccess();
            _GeneralUnitsServiceAcess = new GeneralUnitsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            RetailReportsViewModel model = new RetailReportsViewModel();

            List<SelectListItem> li_GranularityList = new List<SelectListItem>();
            li_GranularityList.Add(new SelectListItem { Text = "Daily", Value = "1" });
            li_GranularityList.Add(new SelectListItem { Text = "Weekly", Value = "2" });
            li_GranularityList.Add(new SelectListItem { Text = "Monthly", Value = "3" });
            li_GranularityList.Add(new SelectListItem { Text = "Yearly", Value = "4" });
            ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text"); 
            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();
            return View("/Views/Inventory_1/Report/RetailSalesAndMarginReports/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(RetailReportsViewModel model)
        {
            try
            {
                model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();
              
                List<SelectListItem> li_GranularityList = new List<SelectListItem>();
                li_GranularityList.Add(new SelectListItem { Text = "Daily", Value = "1" });
                li_GranularityList.Add(new SelectListItem { Text = "Weekly", Value = "2" });
                li_GranularityList.Add(new SelectListItem { Text = "Monthly", Value = "3" });
                li_GranularityList.Add(new SelectListItem { Text = "Yearly", Value = "4" });
               

                if (model.IsPosted == true)
                {
                    _centreCode = model.CentreCode;
                    _centreName = model.CentreName;
                    _generalUnitsID = model.GeneralUnitsID;
                    _dateFrom = model.DateFrom;
                    _dateTo = model.DateTo;
                    _granularity = model.Granularity;
                    _granularityName = model.GranularityName;
                    _generalUnitsName = model.GeneralUnitsName;
                    model.ListGeneralUnits = GetGeneralUnitsByCentreCode(model.CentreCode);
                    ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", model.Granularity);
                    model.IsPosted = false;
                }
                else
                {
                    model.CentreCode = _centreCode;
                    model.CentreName = _centreName;
                    model.GeneralUnitsID = _generalUnitsID;
                    model.DateFrom = _dateFrom;
                    model.DateTo = _dateTo;
                    model.Granularity = _granularity;
                    model.GeneralUnitsName = _generalUnitsName;
                    model.GranularityName = _granularityName;
                    model.ListGeneralUnits = GetGeneralUnitsByCentreCode(_centreCode);
                    ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", _granularity);
                }
                return View("/Views/Inventory_1/Report/RetailSalesAndMarginReports/Index.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUnitList(string centreCode)
        {
            //string[] splited;
            //splited = SelectedCentreCode.Split(':');
            //_OrganisationSectionDetailsBaseViewModel.SelectedCentreName = splited[1];
            //SelectedCentreCode = splited[0];
            if (String.IsNullOrEmpty(centreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(centreCode, out id);
            var university = GetGeneralUnitsByCentreCode(centreCode);
            var result = (from s in university
                          select new
                          {
                              id = s.ID,
                              unitName = s.UnitName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<GeneralUnits> GetGeneralUnitsByCentreCode(string centreCode)
        {
            try
            {
                List<GeneralUnits> listGeneralUnits = new List<GeneralUnits>();
                GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = !string.IsNullOrEmpty(centreCode) ? centreCode.Split(':')[0] : string.Empty;
                IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsServiceAcess.GetGeneralUnitsByCentreCode(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listGeneralUnits;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

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
                a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                a.CentreName = item.CentreName;
                model.ListGetAdminRoleApplicableCentre.Add(a);
            }
            return model.ListGetAdminRoleApplicableCentre;
        }

        public List<RetailReports> GetRetailSalesAndMarginReport()
        {
            try
            {
                List<RetailReports> listRetailReports = new List<RetailReports>();
                RetailReportsSearchRequest searchRequest = new RetailReportsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                if (_generalUnitsID > 0 && _dateFrom != string.Empty && _dateTo != string.Empty && _granularity != string.Empty )
                {
                    searchRequest.GeneralUnitsID = _generalUnitsID;
                    searchRequest.Granularity = _granularity;
                    searchRequest.GeneralUnitsName = _generalUnitsName;
                    searchRequest.GranularityName = _granularityName;
                    searchRequest.DateFrom = _dateFrom;
                    searchRequest.CentreName = _centreName;
                    searchRequest.DateTo = _dateTo;
                    IBaseEntityCollectionResponse<RetailReports> baseEntityCollectionResponse = _RetailReportsServiceAccess.GetRetailSalesAndMarginReportsBySearch(searchRequest);
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
