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
    public class EmployeePFReportForm10Controller : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IEmployeePFReportForm10BA _EmployeePFReportForm10BA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _MonthYear = string.Empty;
        protected static string _MonthName = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public EmployeePFReportForm10Controller()
        {
            _EmployeePFReportForm10BA = new EmployeePFReportForm10BA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                EmployeePFReportForm10ViewModel model = new EmployeePFReportForm10ViewModel();

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

                return View("/Views/Contract/Report/EmployeePFReportForm10/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(EmployeePFReportForm10ViewModel model)
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



            return View("/Views/Contract/Report/EmployeePFReportForm10/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<EmployeePFReportForm10> GetEmployeePFReportForm10List()
        {
            try
            {
                List<EmployeePFReportForm10> listEmployeePFReportForm10 = new List<EmployeePFReportForm10>();
                EmployeePFReportForm10SearchRequest searchRequest = new EmployeePFReportForm10SearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                if (_MonthYear != string.Empty)
                {
                    searchRequest.MonthYear = _MonthYear;
                    searchRequest.MonthName = Convert.ToString(_MonthName);
                    IBaseEntityCollectionResponse<EmployeePFReportForm10> baseEntityCollectionResponse = _EmployeePFReportForm10BA.GetEmployeePFReportForm10DataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listEmployeePFReportForm10 = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listEmployeePFReportForm10;
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
