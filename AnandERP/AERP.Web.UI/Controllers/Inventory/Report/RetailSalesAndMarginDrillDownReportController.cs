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
    public class RetailSalesAndMarginDrillDownReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRetailSalesAndMarginDrillDownReportServiceAccess _RetailSalesAndMarginDrillDownReportServiceAccess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static int _generalUnitsID = 0;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static string _granularity = string.Empty;
        protected static string _generalUnitsName = string.Empty;
        protected static string _granularityName = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _ReportForPage;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public RetailSalesAndMarginDrillDownReportController()
        {
            _RetailSalesAndMarginDrillDownReportServiceAccess = new RetailSalesAndMarginDrillDownReportServiceAccess();
            _GeneralUnitsServiceAccess = new GeneralUnitsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            RetailSalesAndMarginDrillDownReportViewModel model = new RetailSalesAndMarginDrillDownReportViewModel();
            List<SelectListItem> li_GranularityList = new List<SelectListItem>();
            li_GranularityList.Add(new SelectListItem { Text = "Daily", Value = "1" });
            li_GranularityList.Add(new SelectListItem { Text = "Weekly", Value = "2" });
            li_GranularityList.Add(new SelectListItem { Text = "Monthly", Value = "3" });
            li_GranularityList.Add(new SelectListItem { Text = "Yearly", Value = "4" });
            ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text");
            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory_1/Report/RetailSalesAndMarginDrillDownReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(RetailSalesAndMarginDrillDownReportViewModel model)
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
                    _generalUnitsID = model.GeneralUnitsID;
                    _dateFrom = model.DateFrom;
                    _dateTo = model.DateTo;
                    _granularity = model.Granularity;
                    _granularityName = model.GranularityName;
                    _generalUnitsName = model.GeneralUnitsName;
                    _centreName = model.CentreName;
                    model.ListGeneralUnits = GetGeneralUnitsByCentreCode(model.CentreCode);
                    ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", model.Granularity);
                    model.IsPosted = false;
                }
                else
                {
                    model.CentreCode = _centreCode;
                    model.GeneralUnitsID = _generalUnitsID;
                    model.DateFrom = _dateFrom;
                    model.DateTo = _dateTo;
                    model.Granularity = _granularity;
                    model.GranularityName = _granularityName;
                    model.GeneralUnitsName = _generalUnitsName;
                    model.CentreName = _centreName;
                    model.ListGeneralUnits = GetGeneralUnitsByCentreCode(_centreCode);
                    ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", _granularity);
                }
                return View("/Views/Inventory_1/Report/RetailSalesAndMarginDrillDownReport/Index.cshtml", model);
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
                IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsServiceAccess.GetGeneralUnitsByCentreCode(searchRequest);
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

        public List<RetailSalesAndMarginDrillDownReport> GetRetailSalesAndMarginDrillDownReportList()
        {
            try
            {
                List<RetailSalesAndMarginDrillDownReport> listRetailSalesAndMarginDrillDownReport = new List<RetailSalesAndMarginDrillDownReport>();
                RetailSalesAndMarginDrillDownReportSearchRequest searchRequest = new RetailSalesAndMarginDrillDownReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                if (_dateFrom != null && _dateTo != null)
                {
                    searchRequest.DateFrom = _dateFrom;
                    searchRequest.DateTo = _dateTo;
                    searchRequest.GeneralUnitsID = _generalUnitsID;
                    searchRequest.GeneralUnitsName = _generalUnitsName;
                    IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollectionResponse = _RetailSalesAndMarginDrillDownReportServiceAccess.GetRetailSalesAndMarginDrillDownReportBySearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listRetailSalesAndMarginDrillDownReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listRetailSalesAndMarginDrillDownReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<RetailSalesAndMarginDrillDownReport> GetStoresList()
        {
            try
            {
                List<RetailSalesAndMarginDrillDownReport> listRetailSalesAndMarginDrillDownReport = new List<RetailSalesAndMarginDrillDownReport>();
                RetailSalesAndMarginDrillDownReportSearchRequest searchRequest = new RetailSalesAndMarginDrillDownReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                searchRequest.CentreName = _centreName;
                searchRequest.CentreCode = _centreCode;

                string code = searchRequest.CentreCode;
                string[] accnmArray = code.Split(':');
                searchRequest.CentreCode = Convert.ToString(accnmArray[0]);
                searchRequest.GranularityName = _granularityName;

                IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollectionResponse = _RetailSalesAndMarginDrillDownReportServiceAccess.RetailSalesAndMarginDrillDownReportBySearch_StoreList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailSalesAndMarginDrillDownReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listRetailSalesAndMarginDrillDownReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<RetailSalesAndMarginDrillDownReport> GetGroupDescriptionList(string GeneralUnitsId, string GeneralUnitsName)
        {
            try
            {
                List<RetailSalesAndMarginDrillDownReport> listRetailSalesAndMarginDrillDownReport = new List<RetailSalesAndMarginDrillDownReport>();
                RetailSalesAndMarginDrillDownReportSearchRequest searchRequest = new RetailSalesAndMarginDrillDownReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                _generalUnitsID = Convert.ToInt32(GeneralUnitsId);
                _generalUnitsName = GeneralUnitsName;
                
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.CentreName = _centreName;
                IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollectionResponse = _RetailSalesAndMarginDrillDownReportServiceAccess.RetailSalesAndMarginDrillDownReportBySearch_GroupDescriptionList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailSalesAndMarginDrillDownReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listRetailSalesAndMarginDrillDownReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<RetailSalesAndMarginDrillDownReport> GetMerchantiseDepartmentList(string MarchandiseGroupCode)
        {
            try
            {
                List<RetailSalesAndMarginDrillDownReport> listRetailSalesAndMarginDrillDownReport = new List<RetailSalesAndMarginDrillDownReport>();
                RetailSalesAndMarginDrillDownReportSearchRequest searchRequest = new RetailSalesAndMarginDrillDownReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                searchRequest.MarchandiseGroupCode = MarchandiseGroupCode;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.CentreName = _centreName;
                
                IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollectionResponse = _RetailSalesAndMarginDrillDownReportServiceAccess.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseDepartmentList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailSalesAndMarginDrillDownReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listRetailSalesAndMarginDrillDownReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<RetailSalesAndMarginDrillDownReport> GetMerchantiseCategoryList(string MerchantiseDepartmentCode)
        {
            try
            {
                List<RetailSalesAndMarginDrillDownReport> listRetailSalesAndMarginDrillDownReport = new List<RetailSalesAndMarginDrillDownReport>();
                RetailSalesAndMarginDrillDownReportSearchRequest searchRequest = new RetailSalesAndMarginDrillDownReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                searchRequest.MerchantiseDepartmentCode = MerchantiseDepartmentCode;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.CentreName = _centreName;
                IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollectionResponse = _RetailSalesAndMarginDrillDownReportServiceAccess.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseCategoryList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailSalesAndMarginDrillDownReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listRetailSalesAndMarginDrillDownReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public List<RetailSalesAndMarginDrillDownReport> GetMerchantiseSubCategoryList(string MerchantiseCategoryCode)
        {
            try
            {
                List<RetailSalesAndMarginDrillDownReport> listRetailSalesAndMarginDrillDownReport = new List<RetailSalesAndMarginDrillDownReport>();
                RetailSalesAndMarginDrillDownReportSearchRequest searchRequest = new RetailSalesAndMarginDrillDownReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                searchRequest.MerchantiseCategoryCode = MerchantiseCategoryCode;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.CentreName = _centreName;
                IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollectionResponse = _RetailSalesAndMarginDrillDownReportServiceAccess.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseSubCategoryList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailSalesAndMarginDrillDownReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listRetailSalesAndMarginDrillDownReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<RetailSalesAndMarginDrillDownReport> GetMerchantiseBaseCategoryList(string MarchandiseSubCatgoryCode)
        {
            try
            {
                List<RetailSalesAndMarginDrillDownReport> listRetailSalesAndMarginDrillDownReport = new List<RetailSalesAndMarginDrillDownReport>();
                RetailSalesAndMarginDrillDownReportSearchRequest searchRequest = new RetailSalesAndMarginDrillDownReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                searchRequest.MarchandiseSubCatgoryCode = MarchandiseSubCatgoryCode;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.CentreName = _centreName;
                IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollectionResponse = _RetailSalesAndMarginDrillDownReportServiceAccess.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseBaseCategoryList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailSalesAndMarginDrillDownReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listRetailSalesAndMarginDrillDownReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public List<RetailSalesAndMarginDrillDownReport> GettemDescriptionList(string MarchandiseBaseCatgoryCode)
        {
            try
            {
                List<RetailSalesAndMarginDrillDownReport> listRetailSalesAndMarginDrillDownReport = new List<RetailSalesAndMarginDrillDownReport>();
                RetailSalesAndMarginDrillDownReportSearchRequest searchRequest = new RetailSalesAndMarginDrillDownReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                searchRequest.MarchandiseBaseCatgoryCode = MarchandiseBaseCatgoryCode;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.CentreName = _centreName;
                IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> baseEntityCollectionResponse = _RetailSalesAndMarginDrillDownReportServiceAccess.RetailSalesAndMarginDrillDownReportBySearch_ItemDescriptionList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailSalesAndMarginDrillDownReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listRetailSalesAndMarginDrillDownReport;
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
