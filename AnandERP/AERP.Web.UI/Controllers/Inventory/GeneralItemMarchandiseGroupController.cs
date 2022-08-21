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
    public class GeneralItemMarchandiseGroupController : BaseController
    {
        IGeneralItemMarchandiseGroupBA _GeneralItemMarchandiseGroupBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralItemMarchandiseGroupController()
        {
            _GeneralItemMarchandiseGroupBA = new GeneralItemMarchandiseGroupBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralItemMarchandiseGroup/Index.cshtml");
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
                GeneralItemMarchandiseGroupViewModel model = new GeneralItemMarchandiseGroupViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralItemMarchandiseGroup/List.cshtml", model);
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
            GeneralItemMarchandiseGroupViewModel model = new GeneralItemMarchandiseGroupViewModel();

            return PartialView("/Views/Inventory/GeneralItemMarchandiseGroup/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralItemMarchandiseGroupViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralItemMarchandiseGroupDTO != null)
                {
                    model.GeneralItemMarchandiseGroupDTO.ConnectionString = _connectioString;
                    model.GeneralItemMarchandiseGroupDTO.GroupDescription = model.GroupDescription;
                    model.GeneralItemMarchandiseGroupDTO.MarchandiseGroupCode = model.MarchandiseGroupCode;
                    model.GeneralItemMarchandiseGroupDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralItemMarchandiseGroup> response = _GeneralItemMarchandiseGroupBA.InsertGeneralItemMarchandiseGroup(model.GeneralItemMarchandiseGroupDTO);

                    model.GeneralItemMarchandiseGroupDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralItemMarchandiseGroupDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralItemMarchandiseGroupViewModel model = new GeneralItemMarchandiseGroupViewModel();
            try
            {
                model.GeneralItemMarchandiseGroupDTO = new GeneralItemMarchandiseGroup();
                model.GeneralItemMarchandiseGroupDTO.ID = Convert.ToInt16(id);
                model.GeneralItemMarchandiseGroupDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralItemMarchandiseGroup> response = _GeneralItemMarchandiseGroupBA.SelectByID(model.GeneralItemMarchandiseGroupDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMarchandiseGroupDTO.ID = response.Entity.ID;
                    model.GeneralItemMarchandiseGroupDTO.GroupDescription = response.Entity.GroupDescription;
                    model.GeneralItemMarchandiseGroupDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
                }
                return PartialView("/Views/Inventory/GeneralItemMarchandiseGroup/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralItemMarchandiseGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralItemMarchandiseGroupDTO != null)
                {
                    if (model != null && model.GeneralItemMarchandiseGroupDTO != null)
                    {
                        model.GeneralItemMarchandiseGroupDTO.ConnectionString = _connectioString;
                        model.GeneralItemMarchandiseGroupDTO.GroupDescription = model.GroupDescription;
                        model.GeneralItemMarchandiseGroupDTO.ID = model.ID;
                        model.GeneralItemMarchandiseGroupDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralItemMarchandiseGroup> response = _GeneralItemMarchandiseGroupBA.UpdateGeneralItemMarchandiseGroup(model.GeneralItemMarchandiseGroupDTO);
                        model.GeneralItemMarchandiseGroupDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralItemMarchandiseGroupDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        GeneralItemMarchandiseGroupViewModel model = new GeneralItemMarchandiseGroupViewModel();
        //        model.GeneralItemMarchandiseGroupDTO = new GeneralItemMarchandiseGroup();
        //        model.GeneralItemMarchandiseGroupDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralItemMarchandiseGroupDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralItemMarchandiseGroup> response = _GeneralItemMarchandiseGroupBA.SelectByID(model.GeneralItemMarchandiseGroupDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralItemMarchandiseGroupDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralItemMarchandiseGroupDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralItemMarchandiseGroupDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralItemMarchandiseGroupDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralItemMarchandiseGroup/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralItemMarchandiseGroup> response = null;
                GeneralItemMarchandiseGroup GeneralItemMarchandiseGroupDTO = new GeneralItemMarchandiseGroup();
                GeneralItemMarchandiseGroupDTO.ConnectionString = _connectioString;
                GeneralItemMarchandiseGroupDTO.ID = Convert.ToInt16(ID);
                GeneralItemMarchandiseGroupDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralItemMarchandiseGroupBA.DeleteGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroupDTO);
                string errorMessageDis = string.Empty;
                string colorCode = string.Empty;
                string mode = string.Empty;
                if (response.Entity.ErrorCode == 77)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "danger";
                }
                else if (response.Entity.ErrorCode == 0)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "success";
                }
                string[] arrayList = { errorMessageDis, colorCode, mode };
                errorMessage = string.Join(",", arrayList);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralItemMarchandiseGroupViewModel> GetGeneralItemMarchandiseGroup(out int TotalRecords)
        {
            GeneralItemMarchandiseGroupSearchRequest searchRequest = new GeneralItemMarchandiseGroupSearchRequest();
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
            List<GeneralItemMarchandiseGroupViewModel> listGeneralItemMarchandiseGroupViewModel = new List<GeneralItemMarchandiseGroupViewModel>();
            List<GeneralItemMarchandiseGroup> listGeneralItemMarchandiseGroup = new List<GeneralItemMarchandiseGroup>();
            IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> baseEntityCollectionResponse = _GeneralItemMarchandiseGroupBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMarchandiseGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralItemMarchandiseGroup item in listGeneralItemMarchandiseGroup)
                    {
                        GeneralItemMarchandiseGroupViewModel GeneralItemMarchandiseGroupViewModel = new GeneralItemMarchandiseGroupViewModel();
                        GeneralItemMarchandiseGroupViewModel.GeneralItemMarchandiseGroupDTO = item;
                        listGeneralItemMarchandiseGroupViewModel.Add(GeneralItemMarchandiseGroupViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralItemMarchandiseGroupViewModel;
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

                IEnumerable<GeneralItemMarchandiseGroupViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.GroupDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%' or A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.MarchandiseGroupCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%' or A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralItemMarchandiseGroup(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.GroupDescription), Convert.ToString(c.MarchandiseGroupCode), Convert.ToString(c.ID) };

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