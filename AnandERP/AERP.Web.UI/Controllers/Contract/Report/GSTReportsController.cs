using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
using AERP.Business.BusinessAction;
using System.Globalization;
namespace AERP.Web.UI.Controllers
{
    public class GSTReportsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IGSTReportsBA _GSTReportsBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public GSTReportsController()
        {
            _GSTReportsBA = new GSTReportsBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                GSTReportsViewModel model = new GSTReportsViewModel();

                model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();
                model.ListAccountSessionMasterReport = GetAllAccountSession();

                return View("/Views/Contract/Report/GSTReports/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(GSTReportsViewModel model)
        {
            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();
            model.ListAccountSessionMasterReport = GetAllAccountSession();

            if (model.IsPosted == true)
            {
                _centreCode = model.CentreCode;
                _centreName = model.CentreName;
                _dateFrom = model.FromDate;
                _dateTo = model.UptoDate;
                _AccountSessionID = model.AccountSessionID;

                model.IsPosted = false;
            }
            else
            {
                model.CentreCode = _centreCode;
                model.CentreName = _centreName;
                model.FromDate = _dateFrom;
                model.UptoDate = _dateTo;
                model.AccountSessionID = _AccountSessionID;
            }

            return View("/Views/Contract/Report/GSTReports/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<AdminRoleApplicableDetails> GetCentreListByRoleAuthorization()
        {
            EmployeePFReportFORM6AViewModel model = new EmployeePFReportFORM6AViewModel();
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }
            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByFinanceManager(AdminRoleMasterID);
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

        public List<GSTReports> GetGST1ReportsList()
        {
            try
            {
                List<GSTReports> listGSTReports = new List<GSTReports>();
                GSTReportsSearchRequest searchRequest = new GSTReportsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                if (_dateFrom != string.Empty && _centreCode != string.Empty)
                {
                    searchRequest.CentreCode = _centreCode;
                    searchRequest.CentreName = _centreName;
                    searchRequest.FromDate = _dateFrom;
                    searchRequest.UptoDate = _dateTo;
                    IBaseEntityCollectionResponse<GSTReports> baseEntityCollectionResponse = _GSTReportsBA.GetGSTR1ReportsDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listGSTReports = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listGSTReports;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public List<GSTReports> GetGST2ReportsList()
        {
            try
            {
                List<GSTReports> listGSTReports = new List<GSTReports>();
                GSTReportsSearchRequest searchRequest = new GSTReportsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                if (_centreCode != string.Empty)
                {
                    searchRequest.CentreCode = _centreCode;
                    IBaseEntityCollectionResponse<GSTReports> baseEntityCollectionResponse = _GSTReportsBA.GetGSTR2ReportsDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listGSTReports = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listGSTReports;
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
