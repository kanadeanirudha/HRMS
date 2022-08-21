using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using AERP.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using System.Web.Mvc.Ajax;
using System.IO;

namespace AERP.Web.UI.Controllers
{
    public class AccountGroupMasterReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountGroupMasterReportBA _accountGroupMasterReportBA = null;
        IAccountHeadMasterReportBA _accountHeadMasterReportBA = null;
        IAccountCategoryMasterReportBA _accountCategoryMasterReportBA = null;

        private readonly ILogger _logException;
        protected static int _headID;
        protected static int _categoryID;
        protected static int _groupID;
        protected string _centreCode = string.Empty;
        protected static int _balanesheetMstID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountGroupMasterReportController()
        {
            _accountGroupMasterReportBA = new AccountGroupMasterReportBA();
            _accountCategoryMasterReportBA = new AccountCategoryMasterReportBA();
            _accountHeadMasterReportBA = new AccountHeadMasterReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0 || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                AccountGroupMasterReportViewModel model = new AccountGroupMasterReportViewModel();
                model.ListAccountHeadMasterReport = GetListAccountHeadMaster();
                //   _balanesheetMstID = Convert.ToInt32(Session["BalancesheetID"].ToString());
                return View("/Views/Accounts/Report/AccountGroupMasterReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }
        [HttpPost]
        public ActionResult Index(AccountGroupMasterReportViewModel model)
        {

            model.ListAccountHeadMasterReport = GetListAccountHeadMaster();

            model.ListAccountCategoryMasterReport = GetCategoryList(Convert.ToInt32(model.SelectedHeadID));
            model.ListAccountGroupMasterReport = GetGroupList(Convert.ToInt32(model.SelectedCategoryID));

            if (model.IsPosted == true)
            {

                _balanesheetMstID = model.AccountBalsheetMstID;
                _headID = Convert.ToInt32(model.SelectedHeadID);
                _categoryID = Convert.ToInt32(model.SelectedCategoryID);
                _groupID = Convert.ToInt32(model.SelectedGroupID);
                model.IsPosted = false;

            }
            else
            {
                model.AccountBalsheetMstID  = _balanesheetMstID;
                model.SelectedHeadID        = Convert.ToString(_headID);
                model.SelectedCategoryID = Convert.ToString(_categoryID);
                model.SelectedGroupID = Convert.ToString(_groupID);

            }
            return View("/Views/Accounts/Report/AccountGroupMasterReport/Index.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(_centreCode, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }
        [NonAction]
        public List<AccountHeadMasterReport> GetListAccountHeadMaster()
        {
            List<AccountHeadMasterReport> listAccountHeadMaster = new List<AccountHeadMasterReport>();
            AccountHeadMasterReportSearchRequest searchRequest = new AccountHeadMasterReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            IBaseEntityCollectionResponse<AccountHeadMasterReport> baseEntityCollectionResponse = _accountHeadMasterReportBA.GetAccountHeadMasterReportBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountHeadMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountHeadMaster;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCategoryAccountHeadWise(int SelectedHeadID)
        {
            try
            {
                var category = GetCategoryList(SelectedHeadID);
                var result = (from s in category select new { id = s.ID, name = s.CategoryDescription, }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public List<AccountCategoryMasterReport> GetCategoryList(int headID)
        {
            List<AccountCategoryMasterReport> listAccountCategoryMasterReport = new List<AccountCategoryMasterReport>();
            AccountCategoryMasterReportSearchRequest searchRequest = new AccountCategoryMasterReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.HeadID = headID;
            IBaseEntityCollectionResponse<AccountCategoryMasterReport> baseEntityCollectionResponse = _accountCategoryMasterReportBA.GetCategoryList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountCategoryMasterReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountCategoryMasterReport;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetGroupAccountCategoryWise(int SelectedCategoryID)
        {
            try
            {
                var category = GetGroupList(SelectedCategoryID);
                var result = (from s in category select new { id = s.ID, name = s.GroupDescription, }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public List<AccountGroupMasterReport> GetGroupList(int categoryID)
        {
            List<AccountGroupMasterReport> listAccountGroupMasterReport = new List<AccountGroupMasterReport>();
            AccountGroupMasterReportSearchRequest searchRequest = new AccountGroupMasterReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CategoryID = categoryID;
            IBaseEntityCollectionResponse<AccountGroupMasterReport> baseEntityCollectionResponse = _accountGroupMasterReportBA.GetGroupList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountGroupMasterReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountGroupMasterReport;
        }

        public List<AccountGroupMasterReport> GetGroupDetailsForReport()
        {
            try
            {
                List<AccountGroupMasterReport> listAccountGroupMasterReport = new List<AccountGroupMasterReport>();
                AccountGroupMasterReportSearchRequest searchRequest = new AccountGroupMasterReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                //if (_headID > 0 && _categoryID > 0 && _groupID > 0)
                //{
                searchRequest.HeadID = _headID;
                searchRequest.CategoryID = _categoryID;
                searchRequest.ID = _groupID;
                IBaseEntityCollectionResponse<AccountGroupMasterReport> baseEntityCollectionResponse = _accountGroupMasterReportBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAccountGroupMasterReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                //}
                return listAccountGroupMasterReport;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //_headID = 0;
                //_categoryID = 0;
                //_groupID = 0;
                //   _balanesheetMstID = 0;
            }

        }
        #endregion



    }
}
