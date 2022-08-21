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
    public class GeneralPriceGroupController : BaseController
    {
        IGeneralPriceGroupBA _GeneralPriceGroupBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralPriceGroupController()
        {
            _GeneralPriceGroupBA = new GeneralPriceGroupBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralPriceGroup/Index.cshtml");
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
                GeneralPriceGroupViewModel model = new GeneralPriceGroupViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralPriceGroup/List.cshtml", model);
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
            GeneralPriceGroupViewModel model = new GeneralPriceGroupViewModel();

            List<SelectListItem> IsRelatedTo = new List<SelectListItem>();
            ViewBag.IsRelatedTo = new SelectList(IsRelatedTo, "Value", "Text");
            List<SelectListItem> li_IsRelatedTo = new List<SelectListItem>();
           
            li_IsRelatedTo.Add(new SelectListItem { Text = "Sales", Value = "1" });
            li_IsRelatedTo.Add(new SelectListItem { Text = "Purchase", Value = "2" });


            ViewData["IsRelatedTo"] = li_IsRelatedTo;

            return PartialView("/Views/Inventory/GeneralPriceGroup/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralPriceGroupViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralPriceGroupDTO != null)
                {
                    model.GeneralPriceGroupDTO.ConnectionString = _connectioString;
                    
                    model.GeneralPriceGroupDTO.GeneralPriceGroupCode = model.GeneralPriceGroupCode;
                    model.GeneralPriceGroupDTO.GeneralPriceGroupDescription = model.GeneralPriceGroupDescription;
                    model.GeneralPriceGroupDTO.IsRelatedTo = model.IsRelatedTo;
                    model.GeneralPriceGroupDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPriceGroup> response = _GeneralPriceGroupBA.InsertGeneralPriceGroup(model.GeneralPriceGroupDTO);

                    model.GeneralPriceGroupDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralPriceGroupDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    GeneralPriceGroupViewModel model = new GeneralPriceGroupViewModel();
        //    try
        //    {
        //        model.GeneralPriceGroupDTO = new GeneralPriceGroup();
        //        model.GeneralPriceGroupDTO.ID = id;
        //        model.GeneralPriceGroupDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralPriceGroup> response = _GeneralPriceGroupBA.SelectByID(model.GeneralPriceGroupDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralPriceGroupDTO.ID = response.Entity.ID;
        //            model.GeneralPriceGroupDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralPriceGroupDTO.GroupCode = response.Entity.GroupCode;
        //            model.GeneralPriceGroupDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(GeneralPriceGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralPriceGroupDTO != null)
                {
                    if (model != null && model.GeneralPriceGroupDTO != null)
                    {
                        model.GeneralPriceGroupDTO.ConnectionString = _connectioString;
                        model.GeneralPriceGroupDTO.GeneralPriceGroupCode = model.GeneralPriceGroupCode;
                        model.GeneralPriceGroupDTO.GeneralPriceGroupDescription = model.GeneralPriceGroupDescription;
                        model.GeneralPriceGroupDTO.IsRelatedTo = model.IsRelatedTo;
                        model.GeneralPriceGroupDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralPriceGroup> response = _GeneralPriceGroupBA.UpdateGeneralPriceGroup(model.GeneralPriceGroupDTO);
                        model.GeneralPriceGroupDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralPriceGroupDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        GeneralPriceGroupViewModel model = new GeneralPriceGroupViewModel();
        //        model.GeneralPriceGroupDTO = new GeneralPriceGroup();
        //        model.GeneralPriceGroupDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralPriceGroupDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralPriceGroup> response = _GeneralPriceGroupBA.SelectByID(model.GeneralPriceGroupDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralPriceGroupDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralPriceGroupDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralPriceGroupDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralPriceGroupDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralPriceGroup/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralPriceGroup> response = null;
                GeneralPriceGroup GeneralPriceGroupDTO = new GeneralPriceGroup();
                GeneralPriceGroupDTO.ConnectionString = _connectioString;
                GeneralPriceGroupDTO.ID = Convert.ToInt16(ID);
                GeneralPriceGroupDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralPriceGroupBA.DeleteGeneralPriceGroup(GeneralPriceGroupDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralPriceGroupViewModel> GetGeneralPriceGroup(out int TotalRecords)
        {
            GeneralPriceGroupSearchRequest searchRequest = new GeneralPriceGroupSearchRequest();
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
            List<GeneralPriceGroupViewModel> listGeneralPriceGroupViewModel = new List<GeneralPriceGroupViewModel>();
            List<GeneralPriceGroup> listGeneralPriceGroup = new List<GeneralPriceGroup>();
            IBaseEntityCollectionResponse<GeneralPriceGroup> baseEntityCollectionResponse = _GeneralPriceGroupBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralPriceGroup item in listGeneralPriceGroup)
                    {
                        GeneralPriceGroupViewModel GeneralPriceGroupViewModel = new GeneralPriceGroupViewModel();
                        GeneralPriceGroupViewModel.GeneralPriceGroupDTO = item;
                        listGeneralPriceGroupViewModel.Add(GeneralPriceGroupViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPriceGroupViewModel;
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

                IEnumerable<GeneralPriceGroupViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.GeneralPriceGroupCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.GeneralPriceGroupCode Like '%" + param.sSearch + "%' or A.GeneralPriceGroupDescription Like '%" + param.sSearch + "%' or A.IsRelatedTo Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.GeneralPriceGroupDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.GeneralPriceGroupCode Like '%" + param.sSearch + "%' or A.GeneralPriceGroupDescription Like '%" + param.sSearch + "%' or A.IsRelatedTo Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.IsRelatedTo";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.GeneralPriceGroupCode Like '%" + param.sSearch + "%' or A.GeneralPriceGroupDescription Like '%" + param.sSearch + "%' or A.IsRelatedTo Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralPriceGroup(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.GeneralPriceGroupCode), Convert.ToString(c.GeneralPriceGroupDescription), Convert.ToString(c.IsRelatedTo), Convert.ToString(c.ID) };

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