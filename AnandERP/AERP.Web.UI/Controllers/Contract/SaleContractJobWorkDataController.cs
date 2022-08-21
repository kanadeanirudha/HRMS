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
    public class SaleContractJobWorkDataController : BaseController
    {
        ISaleContractJobWorkDataBA _SaleContractJobWorkDataBA = null;
        ISaleContractMasterBA _SaleContractMasterBA = null;
        ISaleContractAttendanceBA _SaleContractAttendanceBA = null;

        string _centreCode = string.Empty;
        string _designationId = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SaleContractJobWorkDataController()
        {
            _SaleContractJobWorkDataBA = new SaleContractJobWorkDataBA();
            _SaleContractMasterBA = new SaleContractMasterBA();
            _SaleContractAttendanceBA = new SaleContractAttendanceBA();

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
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0) && IsApplied == true))
            {
                SaleContractJobWorkDataViewModel _SaleContractJobWorkDataViewModel = new SaleContractJobWorkDataViewModel();

                return View("/Views/Contract/SaleContractJobWorkData/Index.cshtml", _SaleContractJobWorkDataViewModel);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            try
            {
                SaleContractJobWorkDataViewModel model = new SaleContractJobWorkDataViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                model.SaleContractJobWorkDataList = GetJobWorkDataList(SaleContractMasterID, SaleContractBillingSpanID);

                return PartialView("/Views/Contract/SaleContractJobWorkData/List.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult AddJobWorkData(string SaleContractMasterID)
        {
            SaleContractJobWorkDataViewModel model = new SaleContractJobWorkDataViewModel();

            model.SaleContractJobWorkDataDTO.ConnectionString = _connectioString;
            model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractSpanList = GetSpanListBySaleContractMaster(SaleContractMasterID);

            return PartialView("/Views/Contract/SaleContractJobWorkData/AddJobWorkData.cshtml", model);
        }

        [HttpGet]
        public ActionResult GetJobWorkData(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractJobWorkDataViewModel model = new SaleContractJobWorkDataViewModel();

            model.SaleContractJobWorkDataList = GetJobWorkDataList(SaleContractMasterID, SaleContractBillingSpanID);

            return PartialView("/Views/Contract/SaleContractJobWorkData/GetJobWorkData.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddJobWorkData(SaleContractJobWorkDataViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractJobWorkDataDTO != null)
                {
                    model.SaleContractJobWorkDataDTO.ConnectionString = _connectioString;
                    model.SaleContractJobWorkDataDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractJobWorkDataDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractJobWorkDataDTO.XMLstringForJobWorkData = model.XMLstringForJobWorkData;

                    model.SaleContractJobWorkDataDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SaleContractJobWorkDataDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractJobWorkData> response = _SaleContractJobWorkDataBA.InsertSaleContractJobWorkData(model.SaleContractJobWorkDataDTO);

                    model.SaleContractJobWorkDataDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractJobWorkDataDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //protected List<SaleContractJobWorkData> GetSaleContractJobWorkDataSpanWise(string SaleContractMasterID, string SaleContractBillingSpanID)
        //{

        //    SaleContractJobWorkDataSearchRequest searchRequest = new SaleContractJobWorkDataSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
        //    searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

        //    List<SaleContractJobWorkData> listSaleContractJobWorkData = new List<SaleContractJobWorkData>();
        //    IBaseEntityCollectionResponse<SaleContractJobWorkData> baseEntityCollectionResponse = _SaleContractJobWorkDataBA.GetSaleContractJobWorkDataSpanWise(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listSaleContractJobWorkData = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listSaleContractJobWorkData;
        //}

        protected List<SaleContractJobWorkData> GetJobWorkDataList(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractJobWorkDataSearchRequest searchRequest = new SaleContractJobWorkDataSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractJobWorkData> listSaleContractJobWorkData = new List<SaleContractJobWorkData>();
            IBaseEntityCollectionResponse<SaleContractJobWorkData> baseEntityCollectionResponse = _SaleContractJobWorkDataBA.GetJobWorkDataList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractJobWorkData = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractJobWorkData;
        }
        #endregion

        #region AjaxHandler

        #endregion
    }
}


