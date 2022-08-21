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
    public class GeneralItemMerchantiseDepartmentController : BaseController
    {
        IGeneralItemMerchantiseDepartmentBA _GeneralItemMerchantiseDepartmentBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralItemMerchantiseDepartmentController()
        {
            _GeneralItemMerchantiseDepartmentBA = new GeneralItemMerchantiseDepartmentBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralItemMerchantiseDepartment/Index.cshtml");
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
                GeneralItemMerchantiseDepartmentViewModel model = new GeneralItemMerchantiseDepartmentViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralItemMerchantiseDepartment/List.cshtml", model);
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
            GeneralItemMerchantiseDepartmentViewModel model = new GeneralItemMerchantiseDepartmentViewModel();

            return PartialView("/Views/Inventory/GeneralItemMerchantiseDepartment/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralItemMerchantiseDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralItemMerchantiseDepartmentDTO != null)
                    {
                        model.GeneralItemMerchantiseDepartmentDTO.ConnectionString = _connectioString;
                        model.GeneralItemMerchantiseDepartmentDTO.MerchantiseDepartmentName = model.MerchantiseDepartmentName;
                        model.GeneralItemMerchantiseDepartmentDTO.MerchantiseDepartmentCode = model.MerchantiseDepartmentCode;
                        model.GeneralItemMerchantiseDepartmentDTO.MarchandiseGroupID = model.MarchandiseGroupID;
                        model.GeneralItemMerchantiseDepartmentDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralItemMerchantiseDepartment> response = _GeneralItemMerchantiseDepartmentBA.InsertGeneralItemMerchantiseDepartment(model.GeneralItemMerchantiseDepartmentDTO);

                        model.GeneralItemMerchantiseDepartmentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }

                    return Json(model.GeneralItemMerchantiseDepartmentDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GeneralItemMerchantiseDepartmentViewModel model = new GeneralItemMerchantiseDepartmentViewModel();
            try
            {
                model.GeneralItemMerchantiseDepartmentDTO = new GeneralItemMerchantiseDepartment();
                model.GeneralItemMerchantiseDepartmentDTO.ID = Convert.ToInt16(id);
                model.GeneralItemMerchantiseDepartmentDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralItemMerchantiseDepartment> response = _GeneralItemMerchantiseDepartmentBA.SelectByID(model.GeneralItemMerchantiseDepartmentDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMerchantiseDepartmentDTO.ID = response.Entity.ID;
                    model.GeneralItemMerchantiseDepartmentDTO.MerchantiseDepartmentCode = response.Entity.MerchantiseDepartmentCode;
                    model.GeneralItemMerchantiseDepartmentDTO.MerchantiseDepartmentName = response.Entity.MerchantiseDepartmentName;
                }
                return PartialView("/Views/Inventory/GeneralItemMerchantiseDepartment/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralItemMerchantiseDepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralItemMerchantiseDepartmentDTO != null)
                {
                    if (model != null && model.GeneralItemMerchantiseDepartmentDTO != null)
                    {
                        model.GeneralItemMerchantiseDepartmentDTO.ConnectionString = _connectioString;
                        model.GeneralItemMerchantiseDepartmentDTO.ID = model.ID;
                        model.GeneralItemMerchantiseDepartmentDTO.MerchantiseDepartmentName = model.MerchantiseDepartmentName;
                        model.GeneralItemMerchantiseDepartmentDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralItemMerchantiseDepartment> response = _GeneralItemMerchantiseDepartmentBA.UpdateGeneralItemMerchantiseDepartment(model.GeneralItemMerchantiseDepartmentDTO);
                        model.GeneralItemMerchantiseDepartmentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralItemMerchantiseDepartmentDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        GeneralItemMerchantiseDepartmentViewModel model = new GeneralItemMerchantiseDepartmentViewModel();
        //        model.GeneralItemMerchantiseDepartmentDTO = new GeneralItemMerchantiseDepartment();
        //        model.GeneralItemMerchantiseDepartmentDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralItemMerchantiseDepartmentDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralItemMerchantiseDepartment> response = _GeneralItemMerchantiseDepartmentBA.SelectByID(model.GeneralItemMerchantiseDepartmentDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralItemMerchantiseDepartmentDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralItemMerchantiseDepartmentDTO.GroupCode = response.Entity.GroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralItemMerchantiseDepartmentDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralItemMerchantiseDepartmentDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralItemMerchantiseDepartment/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralItemMerchantiseDepartment> response = null;
                GeneralItemMerchantiseDepartment GeneralItemMerchantiseDepartmentDTO = new GeneralItemMerchantiseDepartment();
                GeneralItemMerchantiseDepartmentDTO.ConnectionString = _connectioString;
                GeneralItemMerchantiseDepartmentDTO.ID = Convert.ToInt16(ID);
                GeneralItemMerchantiseDepartmentDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralItemMerchantiseDepartmentBA.DeleteGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartmentDTO);
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
        public IEnumerable<GeneralItemMerchantiseDepartmentViewModel> GetGeneralItemMerchantiseDepartment(out int TotalRecords)
        {
            GeneralItemMerchantiseDepartmentSearchRequest searchRequest = new GeneralItemMerchantiseDepartmentSearchRequest();
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
            List<GeneralItemMerchantiseDepartmentViewModel> listGeneralItemMerchantiseDepartmentViewModel = new List<GeneralItemMerchantiseDepartmentViewModel>();
            List<GeneralItemMerchantiseDepartment> listGeneralItemMerchantiseDepartment = new List<GeneralItemMerchantiseDepartment>();
            IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> baseEntityCollectionResponse = _GeneralItemMerchantiseDepartmentBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMerchantiseDepartment = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralItemMerchantiseDepartment item in listGeneralItemMerchantiseDepartment)
                    {
                        GeneralItemMerchantiseDepartmentViewModel GeneralItemMerchantiseDepartmentViewModel = new GeneralItemMerchantiseDepartmentViewModel();
                        GeneralItemMerchantiseDepartmentViewModel.GeneralItemMerchantiseDepartmentDTO = item;
                        listGeneralItemMerchantiseDepartmentViewModel.Add(GeneralItemMerchantiseDepartmentViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralItemMerchantiseDepartmentViewModel;
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

                IEnumerable<GeneralItemMerchantiseDepartmentViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.MerchantiseDepartmentName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.MerchantiseDepartmentName Like '%" + param.sSearch + "%' or A.MerchantiseDepartmentCode Like '%" + param.sSearch + "%'";       //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.MerchantiseDepartmentCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //_searchBy = "A.MerchantiseDepartmentCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MerchantiseDepartmentName Like '%" + param.sSearch + "%' or A.MerchantiseDepartmentCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralItemMerchantiseDepartment(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.MerchantiseDepartmentName), Convert.ToString(c.MerchantiseDepartmentCode), Convert.ToString(c.ID) };

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