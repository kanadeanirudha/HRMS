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
    public class InventoryCounterDetailReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRetailReportsServiceAccess _RetailReportsServiceAccess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        private readonly ILogger _logException;
        public string _ReportFor { get; set; }
        protected static string _ReportForPage;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryCounterDetailReportController()
        {
            _RetailReportsServiceAccess = new RetailReportsServiceAccess();


        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            RetailReportsViewModel model = new RetailReportsViewModel();

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory_1/Report/InventoryCounterDetailReport/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(RetailReportsViewModel model)
        {
            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            if (model.IsPosted == true)
            {
                _centreCode = model.CentreCode;
                _centreName = model.CentreName;
                _dateFrom = model.DateFrom;
                _dateTo = model.DateTo;
                model.IsPosted = false;

            }
            else
            {
                model.CentreCode = _centreCode;
                model.CentreName = _centreName;
                model.DateFrom = _dateFrom;
                model.DateTo = _dateTo;

            }

            return View("/Views/Inventory_1/Report/InventoryCounterDetailReport/Index.cshtml", model);
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

        public List<RetailReports> GetInventoryCounterDetailReportList()
        {
            try
            {
                List<RetailReports> listRetailReports = new List<RetailReports>();
                RetailReportsSearchRequest searchRequest = new RetailReportsSearchRequest();
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                searchRequest.CentreName = _centreName;
                searchRequest.CentreCode = _centreCode;
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                if (_dateFrom != string.Empty && _dateTo != string.Empty)
                {
                    IBaseEntityCollectionResponse<RetailReports> baseEntityCollectionResponse = _RetailReportsServiceAccess.GetInventoryCounterDetailReportBySearch(searchRequest);
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
