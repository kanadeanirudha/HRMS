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
    public class RestaurantTableMaster_1Controller : BaseController
    {
        IRestaurantTableMasterServiceAccess _RestaurantTableMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public RestaurantTableMaster_1Controller()
        {
            _RestaurantTableMasterServiceAcess = new RestaurantTableMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/RestaurantTableMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                RestaurantTableMasterViewModel model = new RestaurantTableMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/RestaurantTableMaster/List.cshtml", model);
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
            RestaurantTableMasterViewModel model = new RestaurantTableMasterViewModel();

            List<SelectListItem> Shape = new List<SelectListItem>();
            ViewBag.Shape = new SelectList(Shape, "Value", "Text");
            List<SelectListItem> li_Shape = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });s
            li_Shape.Add(new SelectListItem { Text = "Square", Value = "1" });
            li_Shape.Add(new SelectListItem { Text = "Oval", Value = "2" });
            li_Shape.Add(new SelectListItem { Text = "Round", Value = "3" });

            ViewData["Shape"] = li_Shape;
            return PartialView("/Views/Inventory_1/RestaurantTableMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(RestaurantTableMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.RestaurantTableMasterDTO != null)
                {
                    model.RestaurantTableMasterDTO.ConnectionString = _connectioString;
                    model.RestaurantTableMasterDTO.Name = model.Name;
                    model.RestaurantTableMasterDTO.TableNumber = model.TableNumber;
                    model.RestaurantTableMasterDTO.Shape = model.Shape;
                    model.RestaurantTableMasterDTO.MinCapacity = model.MinCapacity;
                    model.RestaurantTableMasterDTO.MaxCapicity = model.MaxCapicity;
                    model.RestaurantTableMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<RestaurantTableMaster> response = _RestaurantTableMasterServiceAcess.InsertRestaurantTableMaster(model.RestaurantTableMasterDTO);

                    model.RestaurantTableMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.RestaurantTableMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int16 id)
        {
            RestaurantTableMasterViewModel model = new RestaurantTableMasterViewModel();
            try
            {
                model.RestaurantTableMasterDTO = new RestaurantTableMaster();
                model.RestaurantTableMasterDTO.ID = id;
                model.RestaurantTableMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<RestaurantTableMaster> response = _RestaurantTableMasterServiceAcess.SelectByID(model.RestaurantTableMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.RestaurantTableMasterDTO.ID = response.Entity.ID;
                    model.RestaurantTableMasterDTO.Name = response.Entity.Name;
                    model.RestaurantTableMasterDTO.TableNumber = response.Entity.TableNumber;
                    model.RestaurantTableMasterDTO.Shape = response.Entity.Shape;
                    model.RestaurantTableMasterDTO.MaxCapicity = response.Entity.MaxCapicity;
                    model.RestaurantTableMasterDTO.MinCapacity = response.Entity.MinCapacity;
                }

                List<SelectListItem> Shape = new List<SelectListItem>();
                ViewBag.Shape = new SelectList(Shape, "Value", "Text");
                List<SelectListItem> li_Shape = new List<SelectListItem>();
                //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
                li_Shape.Add(new SelectListItem { Text = "Square", Value = "1" });
                li_Shape.Add(new SelectListItem { Text = "Oval", Value = "2" });
                li_Shape.Add(new SelectListItem { Text = "Round", Value = "3" });
                ViewData["Shape"] = new SelectList(li_Shape, "Value", "Text", (model.RestaurantTableMasterDTO.Shape).ToString().Trim());

                return PartialView("/Views/Inventory_1/RestaurantTableMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(RestaurantTableMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.RestaurantTableMasterDTO != null)
                {
                    if (model != null && model.RestaurantTableMasterDTO != null)
                    {
                        model.RestaurantTableMasterDTO.ConnectionString = _connectioString;
                        model.RestaurantTableMasterDTO.Name = model.Name;
                        model.RestaurantTableMasterDTO.TableNumber = model.TableNumber;
                        model.RestaurantTableMasterDTO.Shape = model.Shape;
                        model.RestaurantTableMasterDTO.MaxCapicity = model.MaxCapicity;
                        model.RestaurantTableMasterDTO.MinCapacity = model.MinCapacity;
                        model.RestaurantTableMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<RestaurantTableMaster> response = _RestaurantTableMasterServiceAcess.UpdateRestaurantTableMaster(model.RestaurantTableMasterDTO);
                        //model.RestaurantTableMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        model.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.ErrorMessage, JsonRequestBehavior.AllowGet);
                     
                    }
                }
                //return Json(model.RestaurantTableMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<RestaurantTableMaster> response = null;
                RestaurantTableMaster RestaurantTableMasterDTO = new RestaurantTableMaster();
                RestaurantTableMasterDTO.ConnectionString = _connectioString;
                RestaurantTableMasterDTO.ID = Convert.ToInt16(ID);
                RestaurantTableMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _RestaurantTableMasterServiceAcess.DeleteRestaurantTableMaster(RestaurantTableMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<RestaurantTableMasterViewModel> GetRestaurantTableMaster(out int TotalRecords)
        {
            RestaurantTableMasterSearchRequest searchRequest = new RestaurantTableMasterSearchRequest();
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
            List<RestaurantTableMasterViewModel> listRestaurantTableMasterViewModel = new List<RestaurantTableMasterViewModel>();
            List<RestaurantTableMaster> listRestaurantTableMaster = new List<RestaurantTableMaster>();
            IBaseEntityCollectionResponse<RestaurantTableMaster> baseEntityCollectionResponse = _RestaurantTableMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listRestaurantTableMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (RestaurantTableMaster item in listRestaurantTableMaster)
                    {
                        RestaurantTableMasterViewModel RestaurantTableMasterViewModel = new RestaurantTableMasterViewModel();
                        RestaurantTableMasterViewModel.RestaurantTableMasterDTO = item;
                        listRestaurantTableMasterViewModel.Add(RestaurantTableMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listRestaurantTableMasterViewModel;
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

                IEnumerable<RestaurantTableMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.Name";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.Name Like '%" + param.sSearch + "%' or A.TableNumber Like '%" + param.sSearch + "%' or A.Shape Like '%" + param.sSearch + "%' or A.MaxCapacity Like '%" + param.sSearch + "%'or A.MinCapacity Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.TableNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.Name Like '%" + param.sSearch + "%' or A.TableNumber Like '%" + param.sSearch + "%' or A.Shape Like '%" + param.sSearch + "%' or A.MaxCapacity Like '%" + param.sSearch + "%'or A.MinCapacity Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.Shape";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.Name Like '%" + param.sSearch + "%' or A.TableNumber Like '%" + param.sSearch + "%' or A.Shape Like '%" + param.sSearch + "%' or A.MaxCapacity Like '%" + param.sSearch + "%'or A.MinCapacity Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.MaxCapacity";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.Name Like '%" + param.sSearch + "%' or A.TableNumber Like '%" + param.sSearch + "%' or A.Shape Like '%" + param.sSearch + "%' or A.MaxCapacity Like '%" + param.sSearch + "%'or A.MinCapacity Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 4:
                        _sortBy = "A.MinCapacity";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.Name Like '%" + param.sSearch + "%' or A.TableNumber Like '%" + param.sSearch + "%' or A.Shape Like '%" + param.sSearch + "%' or A.MaxCapacity Like '%" + param.sSearch + "%'or A.MinCapacity Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetRestaurantTableMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.Name), Convert.ToString(c.TableNumber), Convert.ToString(c.Shape), Convert.ToString(c.MaxCapicity), Convert.ToString(c.MinCapacity), Convert.ToString(c.ID) };

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