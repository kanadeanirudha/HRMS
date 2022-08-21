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
    public class ContractEmployeeReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IContractEmployeeReportBA _ContractEmployeeReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;
        protected static byte _ReportType = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ContractEmployeeReportController()
        {
            _ContractEmployeeReportBA = new ContractEmployeeReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                ContractEmployeeReportViewModel model = new ContractEmployeeReportViewModel();
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
                model.ListGetAdminRoleApplicableCentre = GetAdminRoleApplicableCentreBySalesManager(AdminRoleMasterID);

                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "All", Value = "1" });
                li1.Add(new SelectListItem { Text = "Missing", Value = "2" });
                ViewData["ReportType"] = li1;

                return View("/Views/Contract/Report/ContractEmployeeReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(ContractEmployeeReportViewModel model)
        {

            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
            model.ListGetAdminRoleApplicableCentre = GetAdminRoleApplicableCentreBySalesManager(AdminRoleMasterID);

            List<SelectListItem> li1 = new List<SelectListItem>();
            li1.Add(new SelectListItem { Text = "All", Value = "1" });
            li1.Add(new SelectListItem { Text = "Missing", Value = "2" });
            ViewData["ReportType"] = new SelectList(li1, "Value", "Text", model.ReportType);

            if (model.IsPosted == true)
            {
                _centreCode = model.CentreCode;
                _ReportType = model.ReportType;
                model.IsPosted = false;
            }
            else
            {
                model.CentreCode = _centreCode;
                model.ReportType = _ReportType;
            }

            return View("/Views/Contract/Report/ContractEmployeeReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<AdminRoleApplicableDetails> GetCentreListByRoleAuthorization()
        {
            ContractEmployeeReportViewModel model = new ContractEmployeeReportViewModel();
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

        public List<ContractEmployeeReport> GetContractEmployeeReportList()
        {
            try
            {
                List<ContractEmployeeReport> listContractEmployeeReport = new List<ContractEmployeeReport>();
                ContractEmployeeReportSearchRequest searchRequest = new ContractEmployeeReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                if (_centreCode != string.Empty)
                {
                    searchRequest.CentreCode = _centreCode;
                    searchRequest.ReportType = _ReportType;
                    IBaseEntityCollectionResponse<ContractEmployeeReport> baseEntityCollectionResponse = _ContractEmployeeReportBA.GetContractEmployeeReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listContractEmployeeReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listContractEmployeeReport;
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
