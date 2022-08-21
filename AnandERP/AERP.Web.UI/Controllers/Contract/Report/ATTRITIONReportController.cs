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
    public class ATTRITIONReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IATTRITIONReportBA _ATTRITIONReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _MonthYear = string.Empty;
        protected static string _MonthName = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ATTRITIONReportController()
        {
            _ATTRITIONReportBA = new ATTRITIONReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                ATTRITIONReportViewModel model = new ATTRITIONReportViewModel();
                return View("/Views/Contract/Report/ATTRITIONReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }

        }

        [HttpPost]
        public ActionResult Index(ATTRITIONReportViewModel model)
        {
            return View("/Views/Contract/Report/ATTRITIONReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<ATTRITIONReport> GetATTRITIONReportList()
        {
            try
            {
                List<ATTRITIONReport> listATTRITIONReport = new List<ATTRITIONReport>();
                ATTRITIONReportSearchRequest searchRequest = new ATTRITIONReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                if (_MonthYear != string.Empty)
                {
                    searchRequest.MonthYear = _MonthYear;
                    searchRequest.MonthName = Convert.ToString(_MonthName);
                    IBaseEntityCollectionResponse<ATTRITIONReport> baseEntityCollectionResponse = _ATTRITIONReportBA.GetATTRITIONReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listATTRITIONReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listATTRITIONReport;
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
