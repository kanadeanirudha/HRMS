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
    public class GeneralTransactionMasterController : BaseController
    {
        IGeneralTransactionMasterBA _GeneralTransactionMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralTransactionMasterController()
        {
            _GeneralTransactionMasterBA = new GeneralTransactionMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralTransactionMaster/Index.cshtml");
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
                GeneralTransactionMasterViewModel model = new GeneralTransactionMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralTransactionMaster/List.cshtml", model);
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
            GeneralTransactionMasterViewModel model = new GeneralTransactionMasterViewModel();
            List<SelectListItem> TransactionType = new List<SelectListItem>();
            ViewBag.TransactionType = new SelectList(TransactionType, "Value", "Text");
            List<SelectListItem> li_TransactionType = new List<SelectListItem>();

            li_TransactionType.Add(new SelectListItem { Text = "Sales", Value = "Sales" });
            li_TransactionType.Add(new SelectListItem { Text = "Purchase", Value = "Purchase" });
            li_TransactionType.Add(new SelectListItem { Text = "Inward", Value = "Inward" });
            li_TransactionType.Add(new SelectListItem { Text = "Outward", Value = "Outward" });
            li_TransactionType.Add(new SelectListItem { Text = "Issue", Value = "Issue" });
            li_TransactionType.Add(new SelectListItem { Text = "Dump And Shrink", Value = "Dump And Shrink" });

            ViewData["TransactionType"] = li_TransactionType;
            
            return PartialView("/Views/Inventory/GeneralTransactionMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralTransactionMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralTransactionMasterDTO != null)
                {
                    model.GeneralTransactionMasterDTO.ConnectionString = _connectioString;
                    model.GeneralTransactionMasterDTO.TransactionType = model.TransactionType;
                   
                    model.GeneralTransactionMasterDTO.IsActive = model.IsActive;
                    model.GeneralTransactionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralTransactionMaster> response = _GeneralTransactionMasterBA.InsertGeneralTransactionMaster(model.GeneralTransactionMasterDTO);

                    model.GeneralTransactionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralTransactionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    GeneralTransactionMasterViewModel model = new GeneralTransactionMasterViewModel();
        //    try
        //    {
        //        model.GeneralTransactionMasterDTO = new GeneralTransactionMaster();
        //        model.GeneralTransactionMasterDTO.ID = id;
        //        model.GeneralTransactionMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralTransactionMaster> response = _GeneralTransactionMasterBA.SelectByID(model.GeneralTransactionMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralTransactionMasterDTO.ID = response.Entity.ID;
        //            model.GeneralTransactionMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralTransactionMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.GeneralTransactionMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(GeneralTransactionMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralTransactionMasterDTO != null)
                {
                    if (model != null && model.GeneralTransactionMasterDTO != null)
                    {
                        model.GeneralTransactionMasterDTO.ConnectionString = _connectioString;
                        model.GeneralTransactionMasterDTO.TransactionType = model.TransactionType;
                       
                        model.GeneralTransactionMasterDTO.IsActive = model.IsActive;

                        model.GeneralTransactionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralTransactionMaster> response = _GeneralTransactionMasterBA.UpdateGeneralTransactionMaster(model.GeneralTransactionMasterDTO);
                        model.GeneralTransactionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralTransactionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        GeneralTransactionMasterViewModel model = new GeneralTransactionMasterViewModel();
        //        model.GeneralTransactionMasterDTO = new GeneralTransactionMaster();
        //        model.GeneralTransactionMasterDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralTransactionMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralTransactionMaster> response = _GeneralTransactionMasterBA.SelectByID(model.GeneralTransactionMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralTransactionMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralTransactionMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralTransactionMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralTransactionMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralTransactionMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralTransactionMaster> response = null;
                GeneralTransactionMaster GeneralTransactionMasterDTO = new GeneralTransactionMaster();
                GeneralTransactionMasterDTO.ConnectionString = _connectioString;
                GeneralTransactionMasterDTO.ID = Convert.ToInt16(ID);
                GeneralTransactionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralTransactionMasterBA.DeleteGeneralTransactionMaster(GeneralTransactionMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralTransactionMasterViewModel> GetGeneralTransactionMaster(out int TotalRecords)
        {
            GeneralTransactionMasterSearchRequest searchRequest = new GeneralTransactionMasterSearchRequest();
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
            List<GeneralTransactionMasterViewModel> listGeneralTransactionMasterViewModel = new List<GeneralTransactionMasterViewModel>();
            List<GeneralTransactionMaster> listGeneralTransactionMaster = new List<GeneralTransactionMaster>();
            IBaseEntityCollectionResponse<GeneralTransactionMaster> baseEntityCollectionResponse = _GeneralTransactionMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTransactionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralTransactionMaster item in listGeneralTransactionMaster)
                    {
                        GeneralTransactionMasterViewModel GeneralTransactionMasterViewModel = new GeneralTransactionMasterViewModel();
                        GeneralTransactionMasterViewModel.GeneralTransactionMasterDTO = item;
                        listGeneralTransactionMasterViewModel.Add(GeneralTransactionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTransactionMasterViewModel;
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

                IEnumerable<GeneralTransactionMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.TransactionType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.TransactionType Like '%" + param.sSearch + "%'";  
                        }
                        break;
                    
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralTransactionMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.TransactionType), Convert.ToString(c.IsActive), Convert.ToString(c.ID) };

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