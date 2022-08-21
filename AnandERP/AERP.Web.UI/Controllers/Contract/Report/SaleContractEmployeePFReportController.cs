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
namespace AERP.Web.UI.Controllers
{
    public class SaleContractEmployeePFReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISaleContractEmployeePFReportBA _SaleContractEmployeePFReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public SaleContractEmployeePFReportController()
        {
            _SaleContractEmployeePFReportBA = new SaleContractEmployeePFReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                SaleContractEmployeePFReportViewModel model = new SaleContractEmployeePFReportViewModel();

                model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();
                model.ListAccountSessionMasterReport = GetAllAccountSession();

                return View("/Views/Contract/Report/SaleContractEmployeePFReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(SaleContractEmployeePFReportViewModel model)
        {

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();
            model.ListAccountSessionMasterReport = GetAllAccountSession();

            if (model.IsPosted == true)
            {
                _centreCode = model.CentreCode;
                _dateFrom = model.FromDate;
                _dateTo = model.UptoDate;
                _SaleContractEmployeeMasterID = model.SaleContractEmployeeMasterID;
                _AccountSessionID = model.AccountSessionID;

                model.IsPosted = false;
            }
            else
            {
                _centreCode = model.CentreCode;
                _dateFrom = model.FromDate;
                _dateTo = model.UptoDate;
                _SaleContractEmployeeMasterID = model.SaleContractEmployeeMasterID;
                _AccountSessionID = model.AccountSessionID;
            }

            return View("/Views/Contract/Report/SaleContractEmployeePFReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<AdminRoleApplicableDetails> GetCentreListByRoleAuthorization()
        {
            SaleContractEmployeePFReportViewModel model = new SaleContractEmployeePFReportViewModel();
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

        public List<SaleContractEmployeePFReport> GetSaleContractEmployeePFReportList()
        {
            try
            {
                List<SaleContractEmployeePFReport> listSaleContractEmployeePFReport = new List<SaleContractEmployeePFReport>();
                SaleContractEmployeePFReportSearchRequest searchRequest = new SaleContractEmployeePFReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                if (_dateFrom != string.Empty && _dateTo != string.Empty && _SaleContractEmployeeMasterID > 0)
                {
                    searchRequest.FromDate = _dateFrom;
                    searchRequest.UptoDate = _dateTo;
                    searchRequest.SaleContractEmployeeMasterID = _SaleContractEmployeeMasterID;
                    IBaseEntityCollectionResponse<SaleContractEmployeePFReport> baseEntityCollectionResponse = _SaleContractEmployeePFReportBA.GetSaleContractEmployeePFReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listSaleContractEmployeePFReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listSaleContractEmployeePFReport;
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
