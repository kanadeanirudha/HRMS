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
    public class EmployeePFReportFORM6AController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IEmployeePFReportFORM6ABA _EmployeePFReportFORM6ABA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public EmployeePFReportFORM6AController()
        {
            _EmployeePFReportFORM6ABA = new EmployeePFReportFORM6ABA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                EmployeePFReportFORM6AViewModel model = new EmployeePFReportFORM6AViewModel();

                model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();
                model.ListAccountSessionMasterReport = GetAllAccountSession();

                return View("/Views/Contract/Report/EmployeePFReportFORM6A/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(EmployeePFReportFORM6AViewModel model)
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

            return View("/Views/Contract/Report/EmployeePFReportFORM6A/Index.cshtml", model);
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

        public List<EmployeePFReportFORM6A> GetEmployeePFReportFORM6AList()
        {
            try
            {
                List<EmployeePFReportFORM6A> listEmployeePFReportFORM6A = new List<EmployeePFReportFORM6A>();
                EmployeePFReportFORM6ASearchRequest searchRequest = new EmployeePFReportFORM6ASearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                if (_dateFrom != string.Empty && _dateTo != string.Empty)
                {
                    searchRequest.FromDate = _dateFrom;
                    searchRequest.UptoDate = _dateTo;
                    IBaseEntityCollectionResponse<EmployeePFReportFORM6A> baseEntityCollectionResponse = _EmployeePFReportFORM6ABA.GetEmployeePFReportFORM6ADataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listEmployeePFReportFORM6A = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listEmployeePFReportFORM6A;
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
