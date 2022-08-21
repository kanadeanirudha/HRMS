using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using System.Web.Mvc.Ajax;
using AERP.ExceptionManager;
using System.IO;

namespace AERP.Web.UI.Controllers
{
    public class AccountExclusiveToCentreReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        protected static int _accBalancesheetMstID;
        IAccountExclusiveToCentreReportBA _accountExclusiveToCentreReportBA = null;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountExclusiveToCentreReportController()
        {
            _accountExclusiveToCentreReportBA = new AccountExclusiveToCentreReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToInt32(Session["Account Manager"]) > 0 || Convert.ToInt32(Session["Admin Manager"]) > 0)
                {
                    AccountExclusiveToCentreReportViewModel model = new AccountExclusiveToCentreReportViewModel();
                    _accBalancesheetMstID = Convert.ToInt32(Session["BalancesheetID"].ToString());
                    return View("/Views/Accounts/Report/AccountExclusiveToCentreReport/Index.cshtml", model);
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

            //  return View("/Views/Accounts/AccountExclusiveToCentreReport/Index.cshtml");
        }



        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _accBalancesheetMstID);
            return listOrganisationStudyCentreMaster;
        }
        [NonAction]
        public List<AccountExclusiveToCentreReport> GetListAccountSessionMaster()
        {
            try
            {
                List<AccountExclusiveToCentreReport> listAccountSessionMaster = new List<AccountExclusiveToCentreReport>();
                AccountExclusiveToCentreReportSearchRequest searchRequest = new AccountExclusiveToCentreReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.AccBalancesheetMstID = _accBalancesheetMstID;
                IBaseEntityCollectionResponse<AccountExclusiveToCentreReport> baseEntityCollectionResponse = _accountExclusiveToCentreReportBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAccountSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listAccountSessionMaster;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            finally
            {
                //  _accBalancesheetMstID = 0;
            }
        }

        #endregion



    }
}
