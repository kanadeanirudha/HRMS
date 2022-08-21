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
    public class EmployeeReportForm5MonthlyController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IEmployeeReportForm5MonthlyBA _EmployeeReportForm5MonthlyBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _MonthYear = string.Empty;
        protected static string _MonthName = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public EmployeeReportForm5MonthlyController()
        {
            _EmployeeReportForm5MonthlyBA = new EmployeeReportForm5MonthlyBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                EmployeeReportForm5MonthlyViewModel model = new EmployeeReportForm5MonthlyViewModel();

                List<SelectListItem> MonthList = new List<SelectListItem>();
                DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
                ViewBag.MonthList = new SelectList(MonthList, "Value", "Text");
                List<SelectListItem> li_MonthList = new List<SelectListItem>();
                li_MonthList.Add(new SelectListItem { Text = "--Select month -- ", Value = "0" });
                for (int i = 1; i < 13; i++)
                {
                    ViewBag.MonthList = new SelectList(info.GetMonthName(i), i.ToString());
                    li_MonthList.Add(new SelectListItem { Text = info.GetMonthName(i), Value = (i).ToString() });
                }
                ViewData["MonthName"] = new SelectList(li_MonthList, "Value", "Text");
                //For Year
                int year = DateTime.Now.Year - 65;
                List<SelectListItem> li_YearList = new List<SelectListItem>();
                ViewBag.YearList = new SelectList(li_YearList, "Value", "Text");
                li_YearList.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
                for (int i = DateTime.Now.Year; year <= i; i--)
                {
                    li_YearList.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["MonthYear"] = new SelectList(li_YearList, "Value", "Text");

                return View("/Views/Contract/Report/EmployeeReportForm5Monthly/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(EmployeeReportForm5MonthlyViewModel model)
        {

            //For Year
            int year = DateTime.Now.Year - 65;
            List<SelectListItem> li_YearList = new List<SelectListItem>();
            ViewBag.YearList = new SelectList(li_YearList, "Value", "Text");
            li_YearList.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
            for (int i = DateTime.Now.Year; year <= i; i--)
            {
                li_YearList.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
            }
            ViewData["MonthYear"] = new SelectList(li_YearList, "Value", "Text", model.MonthYear);

            List<SelectListItem> MonthList = new List<SelectListItem>();
            DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
            ViewBag.MonthList = new SelectList(MonthList, "Value", "Text");
            List<SelectListItem> li_MonthList = new List<SelectListItem>();
            li_MonthList.Add(new SelectListItem { Text = "--Select month -- ", Value = "0" });
            for (int i = 1; i < 13; i++)
            {
                ViewBag.MonthList = new SelectList(info.GetMonthName(i), i.ToString());
                li_MonthList.Add(new SelectListItem { Text = info.GetMonthName(i), Value = (i).ToString() });
            }
            ViewData["MonthName"] = new SelectList(li_MonthList, "Value", "Text", model.MonthName);

            if (model.IsPosted == true)
            {
                _MonthYear = model.MonthYear;
                _MonthName = model.MonthName;
                model.IsPosted = false;

            }
            else
            {
                model.MonthYear = _MonthYear;
                model.MonthName = _MonthName;
            }



            return View("/Views/Contract/Report/EmployeeReportForm5Monthly/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<EmployeeReportForm5Monthly> GetEmployeeReportForm5MonthlyList()
        {
            try
            {
                List<EmployeeReportForm5Monthly> listEmployeeReportForm5Monthly = new List<EmployeeReportForm5Monthly>();
                EmployeeReportForm5MonthlySearchRequest searchRequest = new EmployeeReportForm5MonthlySearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                if (_MonthYear != string.Empty)
                {
                    searchRequest.MonthYear = _MonthYear;
                    searchRequest.MonthName = Convert.ToString(_MonthName);
                    IBaseEntityCollectionResponse<EmployeeReportForm5Monthly> baseEntityCollectionResponse = _EmployeeReportForm5MonthlyBA.GetEmployeeReportForm5MonthlyDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listEmployeeReportForm5Monthly = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listEmployeeReportForm5Monthly;
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
