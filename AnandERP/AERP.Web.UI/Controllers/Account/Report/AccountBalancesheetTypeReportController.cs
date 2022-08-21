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

namespace AERP.Web.UI.Controllers
{
    public class AccountBalancesheetTypeReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountBalancesheetTypeReportBA _accountBalancesheetTypeReportBA = null;
        private readonly ILogger _logException;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountBalancesheetTypeReportController()
        {
            _accountBalancesheetTypeReportBA = new AccountBalancesheetTypeReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToInt32(Session["Account Manager"]) > 0 || Convert.ToInt32(Session["Admin Manager"]) > 0)
                {
                    return View("/Views/Accounts/Report/AccountBalancesheetTypeReport/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
      
        #endregion

         #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, 0);
            return listOrganisationStudyCentreMaster;
        }

        public List<AccountBalancesheetTypeReport> GetListAccountBalancesheetTypeReport()
         {
             try
             {
                 List<AccountBalancesheetTypeReport> listAccountBalancesheetTypeReport =  new List<AccountBalancesheetTypeReport>();
                 AccountBalancesheetTypeReportSearchRequest searchRequest = new AccountBalancesheetTypeReportSearchRequest();
                 searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                    
                IBaseEntityCollectionResponse<AccountBalancesheetTypeReport> baseEntityCollectionResponse = _accountBalancesheetTypeReportBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAccountBalancesheetTypeReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listAccountBalancesheetTypeReport;
             }
             catch (Exception ex)
             {
                 _logException.Error(ex.Message);
                 throw;
             }
             finally
             {
             }
         }
         #endregion
    }
}