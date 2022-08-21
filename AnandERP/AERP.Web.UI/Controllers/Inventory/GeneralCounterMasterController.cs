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
    public class GeneralCounterMasterController : BaseController
    {
        IGeneralCounterMasterServiceAccess _GeneralCounterMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralCounterMasterController()
        {
            _GeneralCounterMasterServiceAcess = new GeneralCounterMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/GeneralCounterMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralCounterMasterViewModel model = new GeneralCounterMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/GeneralCounterMaster/List.cshtml", model);
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
            GeneralCounterMasterViewModel model = new GeneralCounterMasterViewModel();
          
                return PartialView("/Views/Inventory_1/GeneralCounterMaster/Create.cshtml", model);
                  }

        [HttpPost]
        public ActionResult Create(GeneralCounterMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
               // {
                    if (model != null && model.GeneralCounterMasterDTO != null)
                    {
                        model.GeneralCounterMasterDTO.ConnectionString = _connectioString;
                        model.GeneralCounterMasterDTO.CounterName= model.CounterName;
                        model.GeneralCounterMasterDTO.CounterCode = model.CounterCode;
                        model.GeneralCounterMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCounterMaster> response = _GeneralCounterMasterServiceAcess.InsertGeneralCounterMaster(model.GeneralCounterMasterDTO);

                        model.GeneralCounterMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        return Json(model.GeneralCounterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralCounterMasterViewModel model = new GeneralCounterMasterViewModel();
            try
            {
                model.GeneralCounterMasterDTO = new GeneralCounterMaster();
                model.GeneralCounterMasterDTO.ID = id;
                model.GeneralCounterMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralCounterMaster> response = _GeneralCounterMasterServiceAcess.SelectByID(model.GeneralCounterMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralCounterMasterDTO.ID = response.Entity.ID;
                    model.GeneralCounterMasterDTO.CounterName = response.Entity.CounterName;
                    model.GeneralCounterMasterDTO.CounterCode = response.Entity.CounterCode;
                    model.GeneralCounterMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory_1/GeneralCounterMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralCounterMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralCounterMasterDTO != null)
                {
                    if (model != null && model.GeneralCounterMasterDTO != null)
                    {
                        model.GeneralCounterMasterDTO.ConnectionString = _connectioString;
                        model.GeneralCounterMasterDTO.CounterName = model.CounterName;
                        model.GeneralCounterMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCounterMaster> response = _GeneralCounterMasterServiceAcess.UpdateGeneralCounterMaster(model.GeneralCounterMasterDTO);
                        model.GeneralCounterMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    }
                }
                return Json(model.GeneralCounterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        GeneralCounterMasterViewModel model = new GeneralCounterMasterViewModel();
        //        model.GeneralCounterMasterDTO = new GeneralCounterMaster();
        //        model.GeneralCounterMasterDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralCounterMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralCounterMaster> response = _GeneralCounterMasterServiceAcess.SelectByID(model.GeneralCounterMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralCounterMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralCounterMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralCounterMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralCounterMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralCounterMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralCounterMaster> response = null;
                GeneralCounterMaster GeneralCounterMasterDTO = new GeneralCounterMaster();
                GeneralCounterMasterDTO.ConnectionString = _connectioString;
                GeneralCounterMasterDTO.ID = Convert.ToInt16(ID);
                GeneralCounterMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralCounterMasterServiceAcess.DeleteGeneralCounterMaster(GeneralCounterMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
      

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralCounterMasterViewModel> GetGeneralCounterMaster(out int TotalRecords)
        {
            GeneralCounterMasterSearchRequest searchRequest = new GeneralCounterMasterSearchRequest();
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
            List<GeneralCounterMasterViewModel> listGeneralCounterMasterViewModel = new List<GeneralCounterMasterViewModel>();
            List<GeneralCounterMaster> listGeneralCounterMaster = new List<GeneralCounterMaster>();
            IBaseEntityCollectionResponse<GeneralCounterMaster> baseEntityCollectionResponse = _GeneralCounterMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCounterMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralCounterMaster item in listGeneralCounterMaster)
                    {
                        GeneralCounterMasterViewModel GeneralCounterMasterViewModel = new GeneralCounterMasterViewModel();
                        GeneralCounterMasterViewModel.GeneralCounterMasterDTO = item;
                        listGeneralCounterMasterViewModel.Add(GeneralCounterMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralCounterMasterViewModel;
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

                IEnumerable<GeneralCounterMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.CounterName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                           // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.CounterCode Like '%" + param.sSearch + "%' or A.CounterName Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.CounterCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                          //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.CounterName Like '%" + param.sSearch + "%' or A.CounterCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralCounterMaster(out TotalRecords);
                
                
                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CounterName), Convert.ToString(c.CounterCode), Convert.ToString(c.ID) };

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