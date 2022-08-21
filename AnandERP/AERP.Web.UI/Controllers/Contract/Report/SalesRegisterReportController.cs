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
    public class SalesRegisterReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISalesRegisterReportBA _SalesRegisterReportBA = null;
        private readonly ILogger _logException;
        protected static string _FromDate = string.Empty;
        protected static string _UptoDate = string.Empty;
        protected static string _CentreName = string.Empty;
        protected static string _CentreCode = string.Empty;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public SalesRegisterReportController()
        {
            _SalesRegisterReportBA = new SalesRegisterReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToInt32(Session["Account Manager"]) > 0 || Convert.ToInt32(Session["Admin Manager"]) > 0 && IsApplied == true)
            {
                SalesRegisterReportViewModel model = new SalesRegisterReportViewModel();
                model.ListAccountSessionMaster = GetAllAccountSession();

                return View("/Views/Contract/Report/SalesRegisterReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(SalesRegisterReportViewModel model)
        {
            model.ListAccountSessionMaster = GetAllAccountSession();

            if (model.IsPosted == true)
            {
                _FromDate = model.FromDate;
                _UptoDate = model.UptoDate;
                _CentreCode = model.CentreCode;
                _CentreName = model.CentreName;
                _AccountSessionID = model.AccountSessionID;
                model.IsPosted = false;
            }
            else
            {
                model.FromDate = _FromDate;
                model.UptoDate = _UptoDate;
                model.CentreCode = _CentreCode;
                model.CentreName = _CentreName;
                model.AccountSessionID = _AccountSessionID;
            }

            return View("/Views/Contract/Report/SalesRegisterReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<SalesRegisterReport> GetSalesRegisterReportList()
        {
            try
            {
                List<SalesRegisterReport> listSalesRegisterReport = new List<SalesRegisterReport>();
                SalesRegisterReportSearchRequest searchRequest = new SalesRegisterReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                
                if (_FromDate != string.Empty && _UptoDate != string.Empty && _CentreCode!=string.Empty)
                {
                    searchRequest.FromDate = _FromDate;
                    searchRequest.UptoDate = _UptoDate;
                    searchRequest.CentreCode= _CentreCode;
                    searchRequest.CentreName = _CentreName;
                    IBaseEntityCollectionResponse<SalesRegisterReport> baseEntityCollectionResponse = _SalesRegisterReportBA.GetSalesRegisterReportList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listSalesRegisterReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listSalesRegisterReport;
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
