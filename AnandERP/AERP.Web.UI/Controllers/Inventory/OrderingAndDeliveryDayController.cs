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
using AERP.DataProvider;
namespace AERP.Web.UI.Controllers
{
    public class OrderingAndDeliveryDayController : BaseController
    {
        IOrderingAndDeliveryDayBA _OrderingAndDeliveryDayBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrderingAndDeliveryDayController()
        {
            _OrderingAndDeliveryDayBA = new OrderingAndDeliveryDayBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/OrderingAndDeliveryDay/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                OrderingAndDeliveryDayViewModel model = new OrderingAndDeliveryDayViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/OrderingAndDeliveryDay/List.cshtml", model);
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
            OrderingAndDeliveryDayViewModel model = new OrderingAndDeliveryDayViewModel();

            return PartialView("/Views/Inventory/OrderingAndDeliveryDay/Create.cshtml", model);
        }


        [HttpPost]
        public ActionResult Create(OrderingAndDeliveryDayViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.OrderingAndDeliveryDayDTO != null)
                {
                    model.OrderingAndDeliveryDayDTO.ConnectionString = _connectioString;
                    model.OrderingAndDeliveryDayDTO.ParameterXml = model.ParameterXml;
                    //model.OrderingAndDeliveryDayDTO.MovementCode = model.MovementCode;
                    //model.OrderingAndDeliveryDayDTO.IsActive = model.IsActive;
                    model.OrderingAndDeliveryDayDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OrderingAndDeliveryDay> response = _OrderingAndDeliveryDayBA.InsertOrderingAndDeliveryDay(model.OrderingAndDeliveryDayDTO);

                    model.OrderingAndDeliveryDayDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.OrderingAndDeliveryDayDTO.errorMessage, JsonRequestBehavior.AllowGet);
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



        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    OrderingAndDeliveryDayViewModel model = new OrderingAndDeliveryDayViewModel();
        //    try
        //    {
        //        model.OrderingAndDeliveryDayDTO = new OrderingAndDeliveryDay();
        //        model.OrderingAndDeliveryDayDTO.ID = id;
        //        model.OrderingAndDeliveryDayDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<OrderingAndDeliveryDay> response = _OrderingAndDeliveryDayBA.SelectByID(model.OrderingAndDeliveryDayDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.OrderingAndDeliveryDayDTO.ID = response.Entity.ID;
        //            model.OrderingAndDeliveryDayDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.OrderingAndDeliveryDayDTO.GroupCode = response.Entity.GroupCode;
        //            model.OrderingAndDeliveryDayDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(OrderingAndDeliveryDayViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrderingAndDeliveryDayDTO != null)
                {
                    if (model != null && model.OrderingAndDeliveryDayDTO != null)
                    {
                        model.OrderingAndDeliveryDayDTO.ConnectionString = _connectioString;
                        //model.OrderingAndDeliveryDayDTO.MovementType = model.MovementType;
                        //model.OrderingAndDeliveryDayDTO.MovementCode = model.MovementCode;
                        //model.OrderingAndDeliveryDayDTO.IsActive = model.IsActive;

                        model.OrderingAndDeliveryDayDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrderingAndDeliveryDay> response = _OrderingAndDeliveryDayBA.UpdateOrderingAndDeliveryDay(model.OrderingAndDeliveryDayDTO);
                        model.OrderingAndDeliveryDayDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.OrderingAndDeliveryDayDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        OrderingAndDeliveryDayViewModel model = new OrderingAndDeliveryDayViewModel();
        //        model.OrderingAndDeliveryDayDTO = new OrderingAndDeliveryDay();
        //        model.OrderingAndDeliveryDayDTO.ID = Convert.ToInt16(ID);
        //        model.OrderingAndDeliveryDayDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<OrderingAndDeliveryDay> response = _OrderingAndDeliveryDayBA.SelectByID(model.OrderingAndDeliveryDayDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.OrderingAndDeliveryDayDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.OrderingAndDeliveryDayDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.OrderingAndDeliveryDayDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.OrderingAndDeliveryDayDTO.GenServiceRequiredID);

        //        return PartialView("/Views/OrderingAndDeliveryDay/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<OrderingAndDeliveryDay> response = null;
                OrderingAndDeliveryDay OrderingAndDeliveryDayDTO = new OrderingAndDeliveryDay();
                OrderingAndDeliveryDayDTO.ConnectionString = _connectioString;
                OrderingAndDeliveryDayDTO.ID = Convert.ToInt16(ID);
                OrderingAndDeliveryDayDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _OrderingAndDeliveryDayBA.DeleteOrderingAndDeliveryDay(OrderingAndDeliveryDayDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<OrderingAndDeliveryDayViewModel> GetOrderingAndDeliveryDay(out int TotalRecords)
        {
            OrderingAndDeliveryDaySearchRequest searchRequest = new OrderingAndDeliveryDaySearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
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
            List<OrderingAndDeliveryDayViewModel> listOrderingAndDeliveryDayViewModel = new List<OrderingAndDeliveryDayViewModel>();
            List<OrderingAndDeliveryDay> listOrderingAndDeliveryDay = new List<OrderingAndDeliveryDay>();
            IBaseEntityCollectionResponse<OrderingAndDeliveryDay> baseEntityCollectionResponse = _OrderingAndDeliveryDayBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrderingAndDeliveryDay = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrderingAndDeliveryDay item in listOrderingAndDeliveryDay)
                    {
                        OrderingAndDeliveryDayViewModel OrderingAndDeliveryDayViewModel = new OrderingAndDeliveryDayViewModel();
                        OrderingAndDeliveryDayViewModel.OrderingAndDeliveryDayDTO = item;
                        listOrderingAndDeliveryDayViewModel.Add(OrderingAndDeliveryDayViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrderingAndDeliveryDayViewModel;
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

                IEnumerable<OrderingAndDeliveryDayViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.code";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.code Like '%" + param.sSearch + "%' or A.Orderingday Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.Orderingday";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.code Like '%" + param.sSearch + "%' or A.Orderingday Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetOrderingAndDeliveryDay(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                //var result = from c in records select new[] { Convert.ToString(c.MovementType), Convert.ToString(c.MovementCode), Convert.ToString(c.IsActive), Convert.ToString(c.ID) };
                var result = from c in records select new[] { Convert.ToString(c.code), Convert.ToString(c.OrderingCode), Convert.ToString(c.ID) };
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