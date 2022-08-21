using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using AMS.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using System.IO;

namespace AMS.Web.UI.Controllers
{
    public class AccountCashBankDetailsReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountGeneralLedgerReportServiceAccess _accountGeneralLedgerReportServiceAccess = null;


        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        protected static int _balanesheetMstID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountCashBankDetailsReportController()
        {
            _accountGeneralLedgerReportServiceAccess = new AccountGeneralLedgerReportServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        [HttpGet]
        public ActionResult Index()
        {
            try
            {

                if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
                {
                    AccountGeneralLedgerReportViewModel model = new AccountGeneralLedgerReportViewModel();
                    model.ListAccountSessionMasterReport = GetAllAccountSession();
                    List<SelectListItem> li_AccountType = new List<SelectListItem>();
                    li_AccountType.Add(new SelectListItem { Text = "Cash Short Statment", Value = "C" });
                    li_AccountType.Add(new SelectListItem { Text = "Cash Bank Short Statment", Value = "B" });
                    ViewData["AccountType"] = new SelectList(li_AccountType, "Value", "Text", model.AccountGeneralLedgerReportDTO.AccountType);
                    _balanesheetMstID = model.AccountBalsheetMstID;
                    model.ListAccountNameReport = GetAccountList("C" ,string.Empty);

                    return View("/Views/Accounts/AccountCashBankDetailsReport/Index.cshtml", model);
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Index(AccountGeneralLedgerReportViewModel model)
        {
            try
            {

                if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
                {
                   
                    model.ListAccountSessionMasterReport = GetAllAccountSession();
                    List<SelectListItem> li_AccountType = new List<SelectListItem>();
                    li_AccountType.Add(new SelectListItem { Text = "Cash Short Statment", Value = "C" });
                    li_AccountType.Add(new SelectListItem { Text = "Cash Bank Short Statment", Value = "B" });
                    ViewData["AccountType"] = new SelectList(li_AccountType, "Value", "Text", model.AccountGeneralLedgerReportDTO.AccountType);
                   
                    model.ListAccountNameReport = GetAccountList( model.AccountGeneralLedgerReportDTO.AccountType, string.Empty);

                    return View("/Views/Accounts/AccountCashBankDetailsReport/Index.cshtml", model);
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(_centreCode, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetAccountByCashBankFlag(string AccountType)
        {
            //OrganisationSyllabusGroupMasterViewModel model = new OrganisationSyllabusGroupMasterViewModel();

            if (String.IsNullOrEmpty(AccountType))
            {
                throw new ArgumentNullException("AccountType");
            }
            int id = 0;
            bool isValid = Int32.TryParse(AccountType, out id);
            var accountName = GetAccountList(AccountType, string.Empty);
            var result = (from s in accountName
                          select new
                          {
                              id = s.ID,
                              name = s.AccountName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<AccountGeneralLedgerReport> GetAccountDetailsForReport()
        {
            try
            {
                List<AccountGeneralLedgerReport> listaccountDayBookReport = new List<AccountGeneralLedgerReport>();
                AccountGeneralLedgerReportSearchRequest searchRequest = new AccountGeneralLedgerReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                Session["SuperUser"].ToString();
                if (Convert.ToInt32(Session["BalancesheetID"]) > 0)
                {
                    // searchRequest.AccBalsheetMstID = Convert.ToInt16(Session["BalancesheetID"]);

                    IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollectionResponse = _accountGeneralLedgerReportServiceAccess.GetBySearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listaccountDayBookReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listaccountDayBookReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            finally
            {
                _balanesheetMstID = 0;
            }

        }
        #endregion
    }
}