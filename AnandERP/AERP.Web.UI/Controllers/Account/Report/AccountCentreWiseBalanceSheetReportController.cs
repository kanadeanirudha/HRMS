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
    public class AccountCentreWiseBalanceSheetReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
       // protected static int _balanesheetMstID;
        IAccountCentreWiseBalanceSheetReportBA _accountCentreWiseBalanceSheetReportBA = null;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountCentreWiseBalanceSheetReportController()
        {
            _accountCentreWiseBalanceSheetReportBA = new AccountCentreWiseBalanceSheetReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToInt32(Session["Account Manager"]) > 0 || Convert.ToInt32(Session["Admin Manager"]) > 0)
                {
                    AccountCentreWiseBalanceSheetReportViewModel model = new AccountCentreWiseBalanceSheetReportViewModel();
                //    _balanesheetMstID = Convert.ToInt32(Session["BalancesheetID"].ToString());
                    return View("/Views/Accounts/Report/AccountCentreWiseBalanceSheetReport/Index.cshtml", model);
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

            //  return View("/Views/Accounts/AccountCentreWiseBalanceSheetReport/Index.cshtml");
        }



        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, 0);
            return listOrganisationStudyCentreMaster;
        }
        [NonAction]
        public List<AccountCentreWiseBalanceSheetReport> GetListAccountCentreWiseBalanceSheetMaster()
        {
            try
            {
                List<AccountCentreWiseBalanceSheetReport> listAccountCentreWiseBalanceSheetMaster = new List<AccountCentreWiseBalanceSheetReport>();
                AccountCentreWiseBalanceSheetReportSearchRequest searchRequest = new AccountCentreWiseBalanceSheetReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<AccountCentreWiseBalanceSheetReport> baseEntityCollectionResponse = _accountCentreWiseBalanceSheetReportBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAccountCentreWiseBalanceSheetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listAccountCentreWiseBalanceSheetMaster;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            finally
            {
                //  _balanesheetMstID = 0;
            }
        }

        #endregion



    }
}
