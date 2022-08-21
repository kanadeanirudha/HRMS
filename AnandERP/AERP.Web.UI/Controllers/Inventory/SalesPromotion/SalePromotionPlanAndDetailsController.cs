using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class SalePromotionPlanAndDetailsController : BaseController
    {
        ISalePromotionPlanAndDetailsServiceAccess _SalePromotionPlanAndDetailsServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalePromotionPlanAndDetailsController()
        {
            _SalePromotionPlanAndDetailsServiceAcess = new SalePromotionPlanAndDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/SalesPromotion/SalePromotionPlanAndDetails/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                SalePromotionPlanAndDetailsViewModel model = new SalePromotionPlanAndDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionPlanAndDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create()
        {
            SalePromotionPlanAndDetailsViewModel model = new SalePromotionPlanAndDetailsViewModel();

            List<SelectListItem> PlanCode = new List<SelectListItem>();
            ViewBag.PlanCode = new SelectList(PlanCode, "Value", "Text");
            List<SelectListItem> PlanCode_li = new List<SelectListItem>();
           
            PlanCode_li.Add(new SelectListItem { Text = "ProductConcessionFree", Value = "ProductConcessionFree" });
            PlanCode_li.Add(new SelectListItem { Text = "ProductConcessionSample", Value = "ProductConcessionSample" });
            PlanCode_li.Add(new SelectListItem { Text = "PriceDiscountOffPerItem", Value = "PriceDiscountOffPerItem" });
            PlanCode_li.Add(new SelectListItem { Text = "PriceDiscountOnFixAmount", Value = "PriceDiscountOnFixAmount" });
            PlanCode_li.Add(new SelectListItem { Text = "FixedAmountOffPerItem", Value = "FixedAmountOffPerItem" });
            PlanCode_li.Add(new SelectListItem { Text = "FixedAmountOnGiftVoucher", Value = "FixedAmountOnGiftVoucher" });
            ViewData["PlanCode"] = PlanCode_li;

            return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionPlanAndDetails/CreatePromotionalPlan.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalePromotionPlanAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalePromotionPlanAndDetailsDTO != null)
                {
                    model.SalePromotionPlanAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalePromotionPlanAndDetailsDTO.PlanTypeName = model.PlanTypeName;
                    model.SalePromotionPlanAndDetailsDTO.PlanTypeCode = model.PlanTypeCode;
                    model.SalePromotionPlanAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalePromotionPlanAndDetails> response = _SalePromotionPlanAndDetailsServiceAcess.InsertSalePromotionPlan(model.SalePromotionPlanAndDetailsDTO);

                    model.SalePromotionPlanAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalePromotionPlanAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


          //  }
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
        [HttpGet]
        public ActionResult CreateSalePromotionPlanDetails(string IDs)
        {
            SalePromotionPlanAndDetailsViewModel model = new SalePromotionPlanAndDetailsViewModel();
            string[] IDsArray = IDs.Split('~');
            model.SalePromotionPlanID = Convert.ToInt32(IDsArray[2]);
            model.PlanTypeCode = IDsArray[1];
            model.PlanTypeName = IDsArray[0];

            return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionPlanAndDetails/CreateSalePromotionPlanDetails.cshtml", model);
        }
        public ActionResult CreateSalePromotionAndDetails(SalePromotionPlanAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalePromotionPlanAndDetailsDTO != null)
                {
                    model.SalePromotionPlanAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalePromotionPlanAndDetailsDTO.SalePromotionPlanID = model.SalePromotionPlanID;
                    model.SalePromotionPlanAndDetailsDTO.PlanTypeCode = model.PlanTypeCode;
                    model.SalePromotionPlanAndDetailsDTO.HowManyQtyToBuy = model.HowManyQtyToBuy;
                    model.SalePromotionPlanAndDetailsDTO.GiftItemQty = model.GiftItemQty;
                    model.SalePromotionPlanAndDetailsDTO.DiscountInPercent = model.DiscountInPercent;
                    model.SalePromotionPlanAndDetailsDTO.IsSampling = model.IsSampling;
                    model.SalePromotionPlanAndDetailsDTO.BillAmountRangeFrom = model.BillAmountRangeFrom;
                    model.SalePromotionPlanAndDetailsDTO.BillAmountRangeUpto = model.BillAmountRangeUpto;
                    model.SalePromotionPlanAndDetailsDTO.BillDiscountAmount = model.BillDiscountAmount;
                    model.SalePromotionPlanAndDetailsDTO.IsPercentage = model.IsPercentage;
                    model.SalePromotionPlanAndDetailsDTO.IsItemWiseDiscountExclude = model.IsItemWiseDiscountExclude;
                    model.SalePromotionPlanAndDetailsDTO.PlanDescription = model.PlanDescription;

                    model.SalePromotionPlanAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalePromotionPlanAndDetails> response = _SalePromotionPlanAndDetailsServiceAcess.InsertSalePromotionPlanAndDetails(model.SalePromotionPlanAndDetailsDTO);

                    model.SalePromotionPlanAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalePromotionPlanAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


          //  }
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


        [HttpGet]
        public ActionResult Edit(int id)
        {
            SalePromotionPlanAndDetailsViewModel model = new SalePromotionPlanAndDetailsViewModel();
            try
            {
                model.SalePromotionPlanAndDetailsDTO = new SalePromotionPlanAndDetails();
                //model.SalePromotionPlanAndDetailsDTO.ID = id;
                model.SalePromotionPlanAndDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalePromotionPlanAndDetails> response = _SalePromotionPlanAndDetailsServiceAcess.SelectByID(model.SalePromotionPlanAndDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    //model.SalePromotionPlanAndDetailsDTO.ID = response.Entity.ID;
                    //model.SalePromotionPlanAndDetailsDTO.CounterName = response.Entity.CounterName;
                    //model.SalePromotionPlanAndDetailsDTO.CounterCode = response.Entity.CounterCode;
                    model.SalePromotionPlanAndDetailsDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionPlanAndDetails/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalePromotionPlanAndDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.SalePromotionPlanAndDetailsDTO != null)
                {
                    if (model != null && model.SalePromotionPlanAndDetailsDTO != null)
                    {
                        model.SalePromotionPlanAndDetailsDTO.ConnectionString = _connectioString;
                        //model.SalePromotionPlanAndDetailsDTO.CounterName = model.CounterName;
                        model.SalePromotionPlanAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<SalePromotionPlanAndDetails> response = _SalePromotionPlanAndDetailsServiceAcess.UpdateSalePromotionPlanAndDetails(model.SalePromotionPlanAndDetailsDTO);
                        model.SalePromotionPlanAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    }
                }
                return Json(model.SalePromotionPlanAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        SalePromotionPlanAndDetailsViewModel model = new SalePromotionPlanAndDetailsViewModel();
        //        model.SalePromotionPlanAndDetailsDTO = new SalePromotionPlanAndDetails();
        //        model.SalePromotionPlanAndDetailsDTO.ID = Convert.ToInt16(ID);
        //        model.SalePromotionPlanAndDetailsDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<SalePromotionPlanAndDetails> response = _SalePromotionPlanAndDetailsServiceAcess.SelectByID(model.SalePromotionPlanAndDetailsDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.SalePromotionPlanAndDetailsDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.SalePromotionPlanAndDetailsDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.SalePromotionPlanAndDetailsDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.SalePromotionPlanAndDetailsDTO.GenServiceRequiredID);

        //        return PartialView("/Views/SalePromotionPlanAndDetails/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<SalePromotionPlanAndDetails> response = null;
                SalePromotionPlanAndDetails SalePromotionPlanAndDetailsDTO = new SalePromotionPlanAndDetails();
                SalePromotionPlanAndDetailsDTO.ConnectionString = _connectioString;
                SalePromotionPlanAndDetailsDTO.SalePromotionPlanDetailsID = Convert.ToInt32(ID);
                SalePromotionPlanAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalePromotionPlanAndDetailsServiceAcess.DeleteSalePromotionPlanAndDetails(SalePromotionPlanAndDetailsDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<SalePromotionPlanAndDetailsViewModel> GetSalePromotionPlanAndDetails(out int TotalRecords)
        {
            SalePromotionPlanAndDetailsSearchRequest searchRequest = new SalePromotionPlanAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<SalePromotionPlanAndDetailsViewModel> listSalePromotionPlanAndDetailsViewModel = new List<SalePromotionPlanAndDetailsViewModel>();
            List<SalePromotionPlanAndDetails> listSalePromotionPlanAndDetails = new List<SalePromotionPlanAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> baseEntityCollectionResponse = _SalePromotionPlanAndDetailsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalePromotionPlanAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalePromotionPlanAndDetails item in listSalePromotionPlanAndDetails)
                    {
                        SalePromotionPlanAndDetailsViewModel SalePromotionPlanAndDetailsViewModel = new SalePromotionPlanAndDetailsViewModel();
                        SalePromotionPlanAndDetailsViewModel.SalePromotionPlanAndDetailsDTO = item;
                        listSalePromotionPlanAndDetailsViewModel.Add(SalePromotionPlanAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalePromotionPlanAndDetailsViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalePromotionPlanAndDetailsViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.HowManyQtyToBuy";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {
                           // _searchBy = " B.HowManyQtyToBuy Like '%" + param.sSearch + "%'";
                            _searchBy = "B.HowManyQtyToBuy Like '%" + param.sSearch + "%' or B.GiftItemQty Like '%" + param.sSearch + "%'or B.DiscountInPercent Like '%" + param.sSearch + "%' or B.BillAmountRangeFrom Like '%" + param.sSearch + "%' or B.BillAmountRangeUpto Like '%" + param.sSearch + "%'or B.BillDiscountAmount Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "B.GiftItemQty";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {
                           // _searchBy = " B.GiftItemQty Like '%" + param.sSearch + "%'";
                            _searchBy = "B.HowManyQtyToBuy Like '%" + param.sSearch + "%' or B.GiftItemQty Like '%" + param.sSearch + "%'or B.DiscountInPercent Like '%" + param.sSearch + "%' or B.BillAmountRangeFrom Like '%" + param.sSearch + "%' or B.BillAmountRangeUpto Like '%" + param.sSearch + "%'or B.BillDiscountAmount Like '%" + param.sSearch + "%'";
                        
                        }
                        break;
                    case 2:
                        _sortBy = "B.GiftItemQty";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //_searchBy = " B.GiftItemQty Like '%" + param.sSearch + "%'";
                            _searchBy = "B.HowManyQtyToBuy Like '%" + param.sSearch + "%' or B.GiftItemQty Like '%" + param.sSearch + "%'or B.DiscountInPercent Like '%" + param.sSearch + "%' or B.BillAmountRangeFrom Like '%" + param.sSearch + "%' or B.BillAmountRangeUpto Like '%" + param.sSearch + "%'or B.BillDiscountAmount Like '%" + param.sSearch + "%'";

                        }
                        break;
                    case 3:
                        _sortBy = "B.DiscountInPercent";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " B.DiscountInPercent Like '%" + param.sSearch + "%'";
                            //_searchBy = "B.HowManyQtyToBuy Like '%" + param.sSearch + "%' or B.GiftItemQty Like '%" + param.sSearch + "%'or B.DiscountInPercent Like '%" + param.sSearch + "%' or B.BillAmountRangeFrom Like '%" + param.sSearch + "%' or B.BillAmountRangeUpto Like '%" + param.sSearch + "%'or B.BillDiscountAmount Like '%" + param.sSearch + "%'";

                        }
                        break;
                    case 4:
                        _sortBy = "B.DiscountInPercent";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " B.DiscountInPercent Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 5:
                        _sortBy = "B.BillAmountRangeFrom";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " B.BillAmountRangeFrom Like '%" + param.sSearch + "%'";
                          //_searchBy = "B.HowManyQtyToBuy Like '%" + param.sSearch + "%' or B.GiftItemQty Like '%" + param.sSearch + "%'or B.DiscountInPercent Like '%" + param.sSearch + "%' or B.BillAmountRangeFrom Like '%" + param.sSearch + "%' or B.BillAmountRangeUpto Like '%" + param.sSearch + "%'or B.BillDiscountAmount Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 6:
                        _sortBy = "B.BillAmountRangeUpto";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " B.BillAmountRangeUpto Like '%" + param.sSearch + "%'or B.BillAmountRangeFrom Like '%" + param.sSearch + "%'or B.BillDiscountAmount Like '%" + param.sSearch + "%'";
                             // _searchBy = "B.HowManyQtyToBuy Like '%" + param.sSearch + "%' or B.GiftItemQty Like '%" + param.sSearch + "%'or B.DiscountInPercent Like '%" + param.sSearch + "%' or B.BillAmountRangeFrom Like '%" + param.sSearch + "%' or B.BillAmountRangeUpto Like '%" + param.sSearch + "%'or B.BillDiscountAmount Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 7:
                        _sortBy = "B.BillDiscountAmount";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " B.BillDiscountAmount Like '%" + param.sSearch + "%'";
                            //_searchBy = "B.HowManyQtyToBuy Like '%" + param.sSearch + "%' or B.GiftItemQty Like '%" + param.sSearch + "%'or B.DiscountInPercent Like '%" + param.sSearch + "%' or B.BillAmountRangeFrom Like '%" + param.sSearch + "%' or B.BillAmountRangeUpto Like '%" + param.sSearch + "%'or B.BillDiscountAmount Like '%" + param.sSearch + "%'";
                        }
                        break;
                    
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetSalePromotionPlanAndDetails(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.PlanTypeName), Convert.ToString(c.PlanTypeName) + " " + "-" + " " + Convert.ToString(c.PlanTypeCode), Convert.ToString(c.PlanTypeCode), Convert.ToString(c.SalePromotionPlanDetailsID), Convert.ToString(c.BillAmountRangeFrom), Convert.ToString(c.BillAmountRangeUpto), Convert.ToString(c.BillDiscountAmount), Convert.ToString(c.HowManyQtyToBuy), Convert.ToString(c.GiftItemQty), Convert.ToString(c.IsSampling), Convert.ToString(c.DiscountInPercent), Convert.ToString(c.SalePromotionPlanID), Convert.ToString(c.SalePromotionPlanDetailsID), Convert.ToString(c.PlanDescription) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}