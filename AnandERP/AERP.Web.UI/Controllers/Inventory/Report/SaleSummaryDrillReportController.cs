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
    public class SaleSummaryDrillReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISaleSummaryDrillReportServiceAccess _SaleSummaryDrillReportServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static string _CentreName = string.Empty;
        protected static string _CentreCode = string.Empty;
        protected static string _ReportForPage;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public SaleSummaryDrillReportController()
        {
            _SaleSummaryDrillReportServiceAccess = new SaleSummaryDrillReportServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            SaleSummaryDrillReportViewModel model = new SaleSummaryDrillReportViewModel();

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory_1/Report/SaleSummaryDrillReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(SaleSummaryDrillReportViewModel model)
        {
            if (model.IsPosted == true)
            {

                //_dateFrom = model.DateFrom;
                //_dateTo = model.DateTo;
                _CentreCode = model.CentreCode;
                _CentreName = model.CentreName;
                model.IsPosted = false;
            }
            else
            {
                //model.DateFrom = _dateFrom;
                //model.DateTo = _dateTo;
                model.CentreCode = _CentreCode;
                model.CentreName = _CentreName;
            }
            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory_1/Report/SaleSummaryDrillReport/Index.cshtml", model);
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

        public List<SaleSummaryDrillReport> GetSaleSummaryDrillReport_YearList()
        {
            try
            {
                List<SaleSummaryDrillReport> listRetailReports = new List<SaleSummaryDrillReport>();
                SaleSummaryDrillReportSearchRequest searchRequest = new SaleSummaryDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                if (_CentreCode != null && _CentreName != null)
                {
                    //searchRequest.DateFrom = _dateFrom;
                    //searchRequest.DateTo = _dateTo;
                    searchRequest.CentreName = _CentreName;
                    searchRequest.CentreCode = _CentreCode;
                    searchRequest.NextReport = "MonthWise";
                    IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollectionResponse = _SaleSummaryDrillReportServiceAccess.GetSaleSummaryDrillReport_YearList(searchRequest);
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
        public List<SaleSummaryDrillReport> GetSaleSummaryDrillReport_MonthList(string Date)
        {
            try
            {
                List<SaleSummaryDrillReport> listRetailReports = new List<SaleSummaryDrillReport>();
                SaleSummaryDrillReportSearchRequest searchRequest = new SaleSummaryDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.Date = Date;
                searchRequest.CentreCode = _CentreCode;
                searchRequest.NextReport = "DayWise";
                IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollectionResponse = _SaleSummaryDrillReportServiceAccess.GetSaleSummaryDrillReport_MonthList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailReports = baseEntityCollectionResponse.CollectionResponse.ToList();
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
        public List<SaleSummaryDrillReport> GetSaleSummaryDrillReport_DayList(string Date)
        {
            try
            {
                List<SaleSummaryDrillReport> listRetailReports = new List<SaleSummaryDrillReport>();
                SaleSummaryDrillReportSearchRequest searchRequest = new SaleSummaryDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.Date = Date;
                searchRequest.CentreCode = _CentreCode;
                searchRequest.NextReport = "BillWise";
                IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollectionResponse = _SaleSummaryDrillReportServiceAccess.GetSaleSummaryDrillReport_DayList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailReports = baseEntityCollectionResponse.CollectionResponse.ToList();
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
        public List<SaleSummaryDrillReport> GetSaleSummaryDrillReport_BillList(string Date)
        {
            try
            {
                List<SaleSummaryDrillReport> listRetailReports = new List<SaleSummaryDrillReport>();
                SaleSummaryDrillReportSearchRequest searchRequest = new SaleSummaryDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.Date = Date;
                searchRequest.CentreCode = _CentreCode;
                searchRequest.NextReport = "ItemWise";
                IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollectionResponse = _SaleSummaryDrillReportServiceAccess.GetSaleSummaryDrillReport_BillList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailReports = baseEntityCollectionResponse.CollectionResponse.ToList();
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
        public List<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemList(string BillNumber)
        {
            try
            {
                List<SaleSummaryDrillReport> listRetailReports = new List<SaleSummaryDrillReport>();
                SaleSummaryDrillReportSearchRequest searchRequest = new SaleSummaryDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.BillNumber = BillNumber;
                searchRequest.CentreCode = _CentreCode;
                IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollectionResponse = _SaleSummaryDrillReportServiceAccess.GetSaleSummaryDrillReport_ItemList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailReports = baseEntityCollectionResponse.CollectionResponse.ToList();
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
        public List<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemListSaleReturn(string BillNumber)
        {
            try
            {
                List<SaleSummaryDrillReport> listRetailReports = new List<SaleSummaryDrillReport>();
                SaleSummaryDrillReportSearchRequest searchRequest = new SaleSummaryDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.BillNumber = BillNumber;
                searchRequest.CentreCode = _CentreCode;
                IBaseEntityCollectionResponse<SaleSummaryDrillReport> baseEntityCollectionResponse = _SaleSummaryDrillReportServiceAccess.GetSaleSummaryDrillReport_ItemListSaleReturn(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listRetailReports = baseEntityCollectionResponse.CollectionResponse.ToList();
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
