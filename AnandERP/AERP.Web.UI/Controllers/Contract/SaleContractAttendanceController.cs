using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;

namespace AERP.Web.UI.Controllers
{
    public class SaleContractAttendanceController : BaseController
    {
        ISaleContractAttendanceBA _SaleContractAttendanceBA = null;
        ISaleContractMasterBA _SaleContractMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SaleContractAttendanceController()
        {
            _SaleContractAttendanceBA = new SaleContractAttendanceBA();
            _SaleContractMasterBA = new SaleContractMasterBA();
        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["HR Manager"]) > 0 || Convert.ToInt32(Session["HR Manager:Entity"]) > 0) && IsApplied == true))
            {
                SaleContractAttendanceViewModel _SaleContractAttendanceViewModel = new SaleContractAttendanceViewModel();

                return View("/Views/Contract/SaleContractAttendance/Index.cshtml", _SaleContractAttendanceViewModel);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string SaleContractMasterID, string Months)
        {
            try
            {
                SaleContractAttendanceViewModel model = new SaleContractAttendanceViewModel();

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.SaleContractAttendanceList = GetSaleContractAttendance(SaleContractMasterID, Months);

                return PartialView("/Views/Contract/SaleContractAttendance/List.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult ListMonthWise(string actionMode, string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            try
            {
                SaleContractAttendanceViewModel model = new SaleContractAttendanceViewModel();

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                //model.SaleContractAttendanceList = GetSaleContractAttendanceMonthWise(SaleContractMasterID, Months);

                model.SaleContractAttendanceList = GetSaleContractAttendanceSpanWise(SaleContractMasterID, SaleContractBillingSpanID);

                return PartialView("/Views/Contract/SaleContractAttendance/ListMonthWise.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpGet]
        public ActionResult AddAttendance()
        {
            SaleContractAttendanceViewModel model = new SaleContractAttendanceViewModel();

            model.SaleContractAttendanceDTO.ConnectionString = _connectioString;

            return PartialView("/Views/Contract/SaleContractAttendance/AddAttendance.cshtml", model);
        }

        [HttpGet]
        public ActionResult AddAttendanceMonthWise(string SaleContractMasterID)
        {
            SaleContractAttendanceViewModel model = new SaleContractAttendanceViewModel();

            model.SaleContractAttendanceDTO.ConnectionString = _connectioString;
            model.ID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractAttendanceList = GetSpanListBySaleContractMaster(SaleContractMasterID);

            return PartialView("/Views/Contract/SaleContractAttendance/AddAttendanceMonthWise.cshtml", model);
        }


        [HttpGet]
        public ActionResult GetAttendanceForAttendanceDate(string SaleContractMasterID, string AttendanceDate)
        {
            SaleContractAttendanceViewModel model = new SaleContractAttendanceViewModel();

            model.SaleContractAttendanceList = GetAttendanceListForAttendanceDate(SaleContractMasterID, AttendanceDate);

            return PartialView("/Views/Contract/SaleContractAttendance/GetAttendanceForAttendanceDate.cshtml", model);
        }

        [HttpGet]
        public ActionResult GetAttendanceForMonthWise(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractAttendanceViewModel model = new SaleContractAttendanceViewModel();

            model.SaleContractAttendanceList = GetAttendanceListForSpanWise(SaleContractMasterID, SaleContractBillingSpanID);

            return PartialView("/Views/Contract/SaleContractAttendance/GetAttendanceForMonthWise.cshtml", model);
        }

        [HttpGet]
        public ActionResult SplitSalarySpan(string SaleContractMasterID)
        {
            SaleContractAttendanceViewModel model = new SaleContractAttendanceViewModel();

            model.SaleContractAttendanceDTO.ConnectionString = _connectioString;
            model.ID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractAttendanceList = GetSpanListBySaleContractMaster(SaleContractMasterID);

            return PartialView("/Views/Contract/SaleContractAttendance/SplitSalarySpan.cshtml", model);
        }

        [HttpGet]
        public ActionResult AddSalaryForManPowerItem(Int64 ID)
        {
            SaleContractAttendanceViewModel model = new SaleContractAttendanceViewModel();

            model.SaleContractAttendanceDTO.ConnectionString = _connectioString;
            model.SaleContractAttendanceDTO.ID = Convert.ToInt64(ID);

            IBaseEntityResponse<SaleContractAttendance> response = _SaleContractAttendanceBA.GetSalaryForManPowerItem(model.SaleContractAttendanceDTO);

            if (response != null && response.Entity != null)
            {
                model.SaleContractAttendanceDTO.CustomerMasterID = response.Entity.CustomerMasterID;
                model.SaleContractAttendanceDTO.CustomerBranchMasterID = response.Entity.CustomerBranchMasterID;
                model.SaleContractAttendanceDTO.SalaryForManPowerItemID = response.Entity.SalaryForManPowerItemID;
                model.SaleContractAttendanceDTO.SalaryForManPowerItemName = response.Entity.SalaryForManPowerItemName;
            }

            return PartialView("/Views/Contract/SaleContractAttendance/AddSalaryForManPowerItem.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddAttendance(SaleContractAttendanceViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractAttendanceDTO != null)
                {
                    model.SaleContractAttendanceDTO.ConnectionString = _connectioString;
                    model.SaleContractAttendanceDTO.AttendanceDate = model.AttendanceDate;
                    model.SaleContractAttendanceDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractAttendanceDTO.XMLstringForAttendance = model.XMLstringForAttendance;

                    model.SaleContractAttendanceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractAttendanceDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractAttendance> response = _SaleContractAttendanceBA.InsertSaleContractAttendance(model.SaleContractAttendanceDTO);

                    model.SaleContractAttendanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractAttendanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult AddAttendanceMonthWise(SaleContractAttendanceViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractAttendanceDTO != null)
                {
                    model.SaleContractAttendanceDTO.ConnectionString = _connectioString;
                    model.SaleContractAttendanceDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractAttendanceDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractAttendanceDTO.XMLstringForAttendance = model.XMLstringForAttendance;

                    model.SaleContractAttendanceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractAttendanceDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractAttendance> response = _SaleContractAttendanceBA.InsertSaleContractAttendanceSpanWise(model.SaleContractAttendanceDTO);

                    model.SaleContractAttendanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractAttendanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult SplitSalarySpan(SaleContractAttendanceViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractAttendanceDTO != null)
                {
                    model.SaleContractAttendanceDTO.ConnectionString = _connectioString;
                    model.SaleContractAttendanceDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractAttendanceDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractAttendanceDTO.SplitFromDate = model.SplitFromDate;

                    model.SaleContractAttendanceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractAttendanceDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractAttendance> response = _SaleContractAttendanceBA.InsertSaleContractSplitSalarySpan(model.SaleContractAttendanceDTO);

                    if (response.Entity.ErrorCode == 111)
                    {
                        string errorMessage = "Attendance is created for selected Span. This span can not be splitted.";
                        string colorCode = "warning";
                        string mode = string.Empty;
                        string[] arrayList = { errorMessage, colorCode, mode };
                        model.SaleContractAttendanceDTO.errorMessage = string.Join(",", arrayList);
                    }
                    else if (response.Entity.ErrorCode == 112)
                    {
                        string errorMessage = "Split From Date is out of Span. Please select correct From Date.";
                        string colorCode = "warning";
                        string mode = string.Empty;
                        string[] arrayList = { errorMessage, colorCode, mode };
                        model.SaleContractAttendanceDTO.errorMessage = string.Join(",", arrayList);
                    }
                    else
                    {
                        model.SaleContractAttendanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }

                    return Json(model.SaleContractAttendanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult AddSalaryForManPowerItem(SaleContractAttendanceViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractAttendanceDTO != null)
                {
                    model.SaleContractAttendanceDTO.ConnectionString = _connectioString;
                    model.SaleContractAttendanceDTO.ID = model.ID;
                    model.SaleContractAttendanceDTO.SalaryForManPowerItemID = model.SalaryForManPowerItemID;

                    model.SaleContractAttendanceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractAttendanceDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractAttendance> response = _SaleContractAttendanceBA.InsertSalaryForManPowerItem(model.SaleContractAttendanceDTO);

                    model.SaleContractAttendanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SaleContractAttendanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        #endregion

        #region Methods

        [HttpPost]
        public JsonResult GetContractNumberSearchList(string term)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<SaleContractMaster> listFeeSubType = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetContractNumberSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              ID = r.ID,
                              ContractNumber = r.ContractNumber,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMonthBySaleContractMasterID(string SaleContractMasterID)
        {

            var MonthsList = GetMonthListBySaleContractMaster(SaleContractMasterID);
            var result = (from s in MonthsList
                          select new
                          {
                              name = s.Months,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSpanBySaleContractMasterID(string SaleContractMasterID)
        {

            var MonthsList = GetSpanListBySaleContractMaster(SaleContractMasterID);
            var result = (from s in MonthsList
                          select new
                          {
                              name = s.SaleContractBillingSpanName,
                              id = s.SaleContractBillingSpanID
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<SaleContractAttendance> GetMonthListBySaleContractMaster(string SaleContractMasterID)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetMonthListBySaleContractMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        protected List<SaleContractAttendance> GetSpanListBySaleContractMaster(string SaleContractMasterID)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetSpanListBySaleContractMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        protected List<SaleContractAttendance> GetSaleContractAttendance(string SaleContractMasterID, string Months)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.Months = Months;

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetSaleContractAttendance(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        //protected List<SaleContractAttendance> GetSaleContractAttendanceMonthWise(string SaleContractMasterID, string Months)
        //{

        //    SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
        //    searchRequest.Months = Months;

        //    List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
        //    IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetSaleContractAttendanceMonthWise(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

        //        }
        //    }
        //    return listSaleContractAttendance;
        //}

        protected List<SaleContractAttendance> GetSaleContractAttendanceSpanWise(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetSaleContractAttendanceSpanWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        protected List<SaleContractAttendance> GetAttendanceListForAttendanceDate(string SaleContractMasterID, string AttendanceDate)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.AttendanceDate = AttendanceDate;

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetAttendanceListForAttendanceDate(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractAttendance;
        }

        protected List<SaleContractAttendance> GetAttendanceListForSpanWise(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetAttendanceListForSpanWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractAttendance;
        }
        //protected List<SaleContractAttendance> GetAttendanceListForMonthWise(string SaleContractMasterID, string Months)
        //{

        //    SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
        //    searchRequest.Months = SaleContractBillingSpanID;

        //    List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
        //    IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetAttendanceListForMonthWise(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listSaleContractAttendance;
        //}

        #endregion

        #region AjaxHandler

        #endregion
    }
}