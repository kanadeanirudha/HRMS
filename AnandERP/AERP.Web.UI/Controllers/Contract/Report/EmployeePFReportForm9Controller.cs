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
    public class EmployeePFReportForm9Controller : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IEmployeePFReportForm9BA _EmployeePFReportForm9BA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _MonthYear = string.Empty;
        protected static string _MonthName = string.Empty;
        protected static string _MonthFullName = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public EmployeePFReportForm9Controller()
        {
            _EmployeePFReportForm9BA = new EmployeePFReportForm9BA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                EmployeePFReportForm9ViewModel model = new EmployeePFReportForm9ViewModel();

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

                return View("/Views/Contract/Report/EmployeePFReportForm9/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(EmployeePFReportForm9ViewModel model)
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
                _MonthFullName = model.MonthFullName;
                model.IsPosted = false;

            }
            else
            {
                model.MonthYear = _MonthYear;
                model.MonthName = _MonthName;
                model.MonthFullName = _MonthFullName;
            }



            return View("/Views/Contract/Report/EmployeePFReportForm9/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<EmployeePFReportForm9> GetEmployeePFReportForm9List()
        {
            try
            {
                List<EmployeePFReportForm9> listEmployeePFReportForm9 = new List<EmployeePFReportForm9>();
                EmployeePFReportForm9SearchRequest searchRequest = new EmployeePFReportForm9SearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                if (_MonthYear != string.Empty)
                {
                    searchRequest.MonthYear = _MonthYear;
                    searchRequest.MonthName = Convert.ToString(_MonthName);
                    searchRequest.MonthFullName = _MonthFullName;
                    IBaseEntityCollectionResponse<EmployeePFReportForm9> baseEntityCollectionResponse = _EmployeePFReportForm9BA.GetEmployeePFReportForm9DataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listEmployeePFReportForm9 = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listEmployeePFReportForm9;
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
