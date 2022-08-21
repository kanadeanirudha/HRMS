using System;
using System.Collections.Generic;
using System.Linq;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using AERP.Business.BusinessActions;
using AERP.Business.BusinessAction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
namespace AERP.Web.UI.Controllers
{
    public class GeneralRequestMasterController : BaseController
    {
        IGeneralRequestMasterBA _GeneralRequestMasterServiceAcess = null;
        
        IGeneralTaskModelBA _GeneralTaskModelBA = null;

        IGeneralTaskReportingDetailsBA _generalTaskReportingDetailsBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralRequestMasterController()
        {
            _GeneralRequestMasterServiceAcess = new GeneralRequestMasterBA();
            _GeneralTaskModelBA    = new GeneralTaskModelBA();
            _GeneralTaskReportingDetailsBA = new GeneralTaskReportingDetailsBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/TaskModel/GeneralRequestMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralRequestMasterViewModel model = new GeneralRequestMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/TaskModel/GeneralRequestMaster/List.cshtml", model);
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
            try
            {
              GeneralRequestMasterViewModel model = new GeneralRequestMasterViewModel();
               
                model.MenuCodeList = GetMenuCodeAndMenuLink(0); // 0 for MenuCodeList
                model.TaskApprovalBasedTableList = GetTaskApprovalBasedTableList();
                ViewBag.TaskApprovalParamPrimaryKeyList = new List<SelectListItem>();

                return PartialView("/Views/TaskModel/GeneralRequestMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(GeneralRequestMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralRequestMasterDTO != null)
                {
                    model.GeneralRequestMasterDTO.ConnectionString = _connectioString;
                    model.GeneralRequestMasterDTO.RequestCode = model.RequestCode;
                    model.GeneralRequestMasterDTO.RequestDescription = model.RequestDescription;
                    model.GeneralRequestMasterDTO.MenuCode = model.MenuCode;
                    model.GeneralRequestMasterDTO.RequestApprovalBasedTable = model.RequestApprovalBasedTable;
                    model.GeneralRequestMasterDTO.RequestApprovalParamPrimaryKey = model.RequestApprovalParamPrimaryKey;
                  //  model.GeneralRequestMasterDTO.LinkMenuCode = model.LinkMenuCode;
                    model.GeneralRequestMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralRequestMaster> response = _GeneralRequestMasterServiceAcess.InsertGeneralRequestMaster(model.GeneralRequestMasterDTO);

                    model.GeneralRequestMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralRequestMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    GeneralRequestMasterViewModel model = new GeneralRequestMasterViewModel();
        //    try
        //    {
        //        model.GeneralRequestMasterDTO = new GeneralRequestMaster();
        //        model.GeneralRequestMasterDTO.ID = id;
        //        model.GeneralRequestMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralRequestMaster> response = _GeneralRequestMasterServiceAcess.SelectByID(model.GeneralRequestMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralRequestMasterDTO.ID = response.Entity.ID;
        //            model.GeneralRequestMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralRequestMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.GeneralRequestMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(GeneralRequestMasterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.GeneralRequestMasterDTO != null)
        //        {
        //            if (model != null && model.GeneralRequestMasterDTO != null)
        //            {
        //                model.GeneralRequestMasterDTO.ConnectionString = _connectioString;
        //                model.GeneralRequestMasterDTO.CounterName = model.CounterName;
        //                // model.GeneralRequestMasterDTO.SeqNo = model.SeqNo;
        //                model.GeneralRequestMasterDTO.CounterCode = model.CounterCode;
        //                //model.GeneralRequestMasterDTO.DefaultFlag = model.DefaultFlag;
        //                model.GeneralRequestMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<GeneralRequestMaster> response = _GeneralRequestMasterServiceAcess.UpdateGeneralRequestMaster(model.GeneralRequestMasterDTO);
        //                model.GeneralRequestMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.GeneralRequestMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        GeneralRequestMasterViewModel model = new GeneralRequestMasterViewModel();
        //        model.GeneralRequestMasterDTO = new GeneralRequestMaster();
        //        model.GeneralRequestMasterDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralRequestMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralRequestMaster> response = _GeneralRequestMasterServiceAcess.SelectByID(model.GeneralRequestMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralRequestMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralRequestMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralRequestMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralRequestMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralRequestMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralRequestMaster> response = null;
                GeneralRequestMaster GeneralRequestMasterDTO = new GeneralRequestMaster();
                GeneralRequestMasterDTO.ConnectionString = _connectioString;
                GeneralRequestMasterDTO.ID = Convert.ToInt32(ID);
                GeneralRequestMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralRequestMasterServiceAcess.DeleteGeneralRequestMaster(GeneralRequestMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        //*************************For Getting PrimaryKeylist ID *****************
        #region Methods
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPrimaryKeyList(string tableName)
        {
            try
            {
                var dataList1 = GetTaskApprovalParamPrimaryKeyList(!string.IsNullOrEmpty(tableName) ? tableName : string.Empty);
                var result1 = (from s in dataList1 select new { id = s.TaskApprovalParamPrimaryKey, name = s.TaskApprovalParamPrimaryKey }).ToList();
                var dataList2 = GetTaskApprovalBaseTableDisplayFieldList(!string.IsNullOrEmpty(tableName) ? tableName : string.Empty);
                var result2 = (from s in dataList2 select new { id = s.TaskApprovalTableDisplayField, name = s.TaskApprovalTableDisplayField }).ToList();
                var objList = new { Result1 = result1, Result2 = result2 };
                return Json(objList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        
        
        public IEnumerable<GeneralRequestMasterViewModel> GetGeneralRequestMaster(out int TotalRecords)
        {
            GeneralRequestMasterSearchRequest searchRequest = new GeneralRequestMasterSearchRequest();
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
            List<GeneralRequestMasterViewModel> listGeneralRequestMasterViewModel = new List<GeneralRequestMasterViewModel>();
            List<GeneralRequestMaster> listGeneralRequestMaster = new List<GeneralRequestMaster>();
            IBaseEntityCollectionResponse<GeneralRequestMaster> baseEntityCollectionResponse = _GeneralRequestMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralRequestMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralRequestMaster item in listGeneralRequestMaster)
                    {
                        GeneralRequestMasterViewModel GeneralRequestMasterViewModel = new GeneralRequestMasterViewModel();
                        GeneralRequestMasterViewModel.GeneralRequestMasterDTO = item;
                        listGeneralRequestMasterViewModel.Add(GeneralRequestMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralRequestMasterViewModel;
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

                IEnumerable<GeneralRequestMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.RequestCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.RequestDescription Like '%" + param.sSearch + "%' or A.RequestCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.RequestDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.RequestCode Like '%" + param.sSearch + "%' or A.RequestDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.MenuCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.RequestDescription Like '%" + param.sSearch + "%' or A.MenuCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.RequestApprovalBasedTable";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MenuCode Like '%" + param.sSearch + "%' or A.RequestApprovalBasedTable Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 4:
                        _sortBy = "A.RequestApprovalParamPrimaryKey";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.RequestApprovalBasedTable Like '%" + param.sSearch + "%' or A.RequestApprovalParamPrimaryKey Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 5:
                        _sortBy = "A.LinkMenuCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.RequestApprovalParamPrimaryKey Like '%" + param.sSearch + "%' or A.LinkMenuCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralRequestMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.RequestCode), Convert.ToString(c.RequestDescription), Convert.ToString(c.MenuCode), Convert.ToString(c.RequestApprovalBasedTable), Convert.ToString(c.RequestApprovalParamPrimaryKey),Convert.ToString(c.ID) };

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



        public object model { get; set; }

        public GeneralTaskReportingDetailsBA _GeneralTaskReportingDetailsBA { get; set; }
    }
}