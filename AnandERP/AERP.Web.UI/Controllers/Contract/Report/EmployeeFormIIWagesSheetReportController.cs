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
    public class EmployeeFormIIWagesSheetReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IEmployeeFormIIWagesSheetReportBA _EmployeeFormIIWagesSheetReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _MonthYear = string.Empty;
        protected static string _MonthName = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public EmployeeFormIIWagesSheetReportController()
        {
            _EmployeeFormIIWagesSheetReportBA = new EmployeeFormIIWagesSheetReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                EmployeeFormIIWagesSheetReportViewModel model = new EmployeeFormIIWagesSheetReportViewModel();

                return View("/Views/Contract/Report/EmployeeFormIIWagesSheetReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(EmployeeFormIIWagesSheetReportViewModel model)
        {
            return View("/Views/Contract/Report/EmployeeFormIIWagesSheetReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<EmployeeFormIIWagesSheetReport> GetEmployeeFormIIWagesSheetReportList()
        {
            try
            {
                List<EmployeeFormIIWagesSheetReport> listEmployeeFormIIWagesSheetReport = new List<EmployeeFormIIWagesSheetReport>();
                EmployeeFormIIWagesSheetReportSearchRequest searchRequest = new EmployeeFormIIWagesSheetReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                if (_MonthYear != string.Empty)
                {
                    searchRequest.MonthYear = _MonthYear;
                    searchRequest.MonthName = Convert.ToString(_MonthName);
                    IBaseEntityCollectionResponse<EmployeeFormIIWagesSheetReport> baseEntityCollectionResponse = _EmployeeFormIIWagesSheetReportBA.GetEmployeeFormIIWagesSheetReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listEmployeeFormIIWagesSheetReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listEmployeeFormIIWagesSheetReport;
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
