using System;
using System.Collections.Generic;
using System.Linq;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.Business.BusinessActions;
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
    public class TaskApprovalFormFieldNameMasterController : BaseController
    {
        IGeneralTaskModelBA _GeneralTaskModelBA = null;
        ITaskApprovalFormFieldNameMasterBA _TaskApprovalFormFieldNameMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        #region  ------------CONTROLLER CLASS CONSTRUCTOR------------

        public TaskApprovalFormFieldNameMasterController()
        {
            _GeneralTaskModelBA = new GeneralTaskModelBA();
            _TaskApprovalFormFieldNameMasterServiceAcess = new TaskApprovalFormFieldNameMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/TaskModel/TaskApprovalFormFieldNameMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                TaskApprovalFormFieldNameMasterViewModel model = new TaskApprovalFormFieldNameMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/TaskModel/TaskApprovalFormFieldNameMaster/List.cshtml", model);
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
        TaskApprovalFormFieldNameMasterViewModel model = new TaskApprovalFormFieldNameMasterViewModel();


        //************************** Drop Down For Task Code ***********************************************

        List<GeneralTaskModel> GeneralTaskModel = GetListGeneralTaskModel();
        List<SelectListItem> GeneralTaskModelList = new List<SelectListItem>();

        foreach (GeneralTaskModel item in GeneralTaskModel)
        {
            GeneralTaskModelList.Add(new SelectListItem { Text = item.TaskCode, Value = Convert.ToString(item.ID) });
        }
        ViewBag.GeneralTaskModellList = new SelectList(GeneralTaskModelList, "Value", "Text");


        return PartialView("/Views/TaskModel/TaskApprovalFormFieldNameMaster/Create.cshtml", model);
    }

        [HttpGet]
        public ActionResult CreateTaskApprovalFormFieldNameDetails(string IDs)
        {
            TaskApprovalFormFieldNameMasterViewModel model = new TaskApprovalFormFieldNameMasterViewModel();
            string[] IDsArray = IDs.Split('~');
            model.TaskApprovalFormFieldMasterId = Convert.ToInt32(IDsArray[0]);
            model.FormName = Convert.ToString(IDsArray[1]);

            return PartialView("/Views/TaskModel/TaskApprovalFormFieldNameMaster/CreateTaskApprovalFormFieldNameDetails.cshtml", model);
        }

    [HttpPost]
    public ActionResult Create(TaskApprovalFormFieldNameMasterViewModel model)
    {
        try
        {
            //if (ModelState.IsValid)
            // {
            if (model != null && model.TaskApprovalFormFieldNameMasterDTO != null)
            {
                model.TaskApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;
                model.TaskApprovalFormFieldNameMasterDTO.FormName = model.FormName;
                model.TaskApprovalFormFieldNameMasterDTO.TaskCode = model.TaskCode;
                model.TaskApprovalFormFieldNameMasterDTO.ViewName = model.ViewName;
                model.TaskApprovalFormFieldNameMasterDTO.InsertUpdateProcedure = model.InsertUpdateProcedure;
                
                model.TaskApprovalFormFieldNameMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = _TaskApprovalFormFieldNameMasterServiceAcess.InsertTaskApprovalFormFieldNameMaster(model.TaskApprovalFormFieldNameMasterDTO);

                model.TaskApprovalFormFieldNameMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.TaskApprovalFormFieldNameMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //Data Added with XMLString 
    [HttpPost]
    public ActionResult CreateTaskApprovalFormFieldNameMasterDetails(TaskApprovalFormFieldNameMasterViewModel model)
    {
        try
        {
            //if (ModelState.IsValid)
            // {
            if (model != null && model.TaskApprovalFormFieldNameMasterDTO != null)
            {
                model.TaskApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;
                model.TaskApprovalFormFieldNameMasterDTO.XMLstring = model.XMLstring;
                //model.TaskApprovalFormFieldNameMasterDTO.TaskApprovalFormFieldMasterId = model.TaskApprovalFormFieldMasterId;
                //model.TaskApprovalFormFieldNameMasterDTO.TaskApprovalFormFieldNameDetailsID = model.TaskApprovalFormFieldNameDetailsID;
                model.TaskApprovalFormFieldNameMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = _TaskApprovalFormFieldNameMasterServiceAcess.InsertTaskApprovalFormFieldNameMaster(model.TaskApprovalFormFieldNameMasterDTO);

                model.TaskApprovalFormFieldNameMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.TaskApprovalFormFieldNameMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    TaskApprovalFormFieldNameMasterViewModel model = new TaskApprovalFormFieldNameMasterViewModel();
        //    try
        //    {
        //        model.TaskApprovalFormFieldNameMasterDTO = new TaskApprovalFormFieldNameMaster();
        //        model.TaskApprovalFormFieldNameMasterDTO.ID = id;
        //        model.TaskApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = _TaskApprovalFormFieldNameMasterServiceAcess.SelectByID(model.TaskApprovalFormFieldNameMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.TaskApprovalFormFieldNameMasterDTO.ID = response.Entity.ID;
        //            model.TaskApprovalFormFieldNameMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.TaskApprovalFormFieldNameMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.TaskApprovalFormFieldNameMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(TaskApprovalFormFieldNameMasterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.TaskApprovalFormFieldNameMasterDTO != null)
        //        {
        //            if (model != null && model.TaskApprovalFormFieldNameMasterDTO != null)
        //            {
        //                model.TaskApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;
        //                model.TaskApprovalFormFieldNameMasterDTO.CounterName = model.CounterName;
        //                // model.TaskApprovalFormFieldNameMasterDTO.SeqNo = model.SeqNo;
        //                model.TaskApprovalFormFieldNameMasterDTO.CounterCode = model.CounterCode;
        //                //model.TaskApprovalFormFieldNameMasterDTO.DefaultFlag = model.DefaultFlag;
        //                model.TaskApprovalFormFieldNameMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = _TaskApprovalFormFieldNameMasterServiceAcess.UpdateTaskApprovalFormFieldNameMaster(model.TaskApprovalFormFieldNameMasterDTO);
        //                model.TaskApprovalFormFieldNameMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.TaskApprovalFormFieldNameMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        TaskApprovalFormFieldNameMasterViewModel model = new TaskApprovalFormFieldNameMasterViewModel();
        //        model.TaskApprovalFormFieldNameMasterDTO = new TaskApprovalFormFieldNameMaster();
        //        model.TaskApprovalFormFieldNameMasterDTO.ID = Convert.ToInt16(ID);
        //        model.TaskApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = _TaskApprovalFormFieldNameMasterServiceAcess.SelectByID(model.TaskApprovalFormFieldNameMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.TaskApprovalFormFieldNameMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.TaskApprovalFormFieldNameMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.TaskApprovalFormFieldNameMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.TaskApprovalFormFieldNameMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/TaskApprovalFormFieldNameMaster/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult DeleteTaskApprovalFormFieldNameDetails(int TaskApprovalFormFieldNameDetailsID)
        {
            var errorMessage = string.Empty;
            if (TaskApprovalFormFieldNameDetailsID > 0)
            {
                IBaseEntityResponse<TaskApprovalFormFieldNameMaster> response = null;
                TaskApprovalFormFieldNameMaster TaskApprovalFormFieldNameMasterDTO = new TaskApprovalFormFieldNameMaster();
                TaskApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;
                TaskApprovalFormFieldNameMasterDTO.TaskApprovalFormFieldNameDetailsID = Convert.ToInt32(TaskApprovalFormFieldNameDetailsID);
                TaskApprovalFormFieldNameMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _TaskApprovalFormFieldNameMasterServiceAcess.DeleteTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
    #region Methods
    //Dropdown for Task Code
    protected List<GeneralTaskModel> GetListGeneralTaskModel()
    {
        GeneralTaskModelSearchRequest searchRequest = new GeneralTaskModelSearchRequest();
        searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        List<GeneralTaskModel> listAdmin = new List<GeneralTaskModel>();
        IBaseEntityCollectionResponse<GeneralTaskModel> baseEntityCollectionResponse = _GeneralTaskModelBA.GetTaskCode(searchRequest);
        if (baseEntityCollectionResponse != null)
        {
            if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
            {
                listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
            }
        }
        return listAdmin;
    }



        public IEnumerable<TaskApprovalFormFieldNameMasterViewModel> GetTaskApprovalFormFieldNameMaster(out int TotalRecords)
        {
            TaskApprovalFormFieldNameMasterSearchRequest searchRequest = new TaskApprovalFormFieldNameMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
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
        List<TaskApprovalFormFieldNameMasterViewModel> listTaskApprovalFormFieldNameMasterViewModel = new List<TaskApprovalFormFieldNameMasterViewModel>();
        List<TaskApprovalFormFieldNameMaster> listTaskApprovalFormFieldNameMaster = new List<TaskApprovalFormFieldNameMaster>();
        IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> baseEntityCollectionResponse = _TaskApprovalFormFieldNameMasterServiceAcess.GetBySearch(searchRequest);
        if (baseEntityCollectionResponse != null)
        {
            if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
            {
                listTaskApprovalFormFieldNameMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                foreach (TaskApprovalFormFieldNameMaster item in listTaskApprovalFormFieldNameMaster)
                {
                    TaskApprovalFormFieldNameMasterViewModel TaskApprovalFormFieldNameMasterViewModel = new TaskApprovalFormFieldNameMasterViewModel();
                    TaskApprovalFormFieldNameMasterViewModel.TaskApprovalFormFieldNameMasterDTO = item;
                    listTaskApprovalFormFieldNameMasterViewModel.Add(TaskApprovalFormFieldNameMasterViewModel);
                }
            }
        }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listTaskApprovalFormFieldNameMasterViewModel;
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

                IEnumerable<TaskApprovalFormFieldNameMasterViewModel> filteredGroupDescription;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        // _searchBy = "A.GroupDescription like '%'";
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        _searchBy = "B.LableName Like '%" + param.sSearch + "%' or B.SequenceNumber Like '%" + param.sSearch + "%' or B.ColumnNumber Like'%" + param.sSearch + "%' or B.FieldName Like'%" + param.sSearch + "%'";
                    }
                    break;

                case 1:
                    _sortBy = "B.LableName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        // _searchBy = "A.GroupDescription like '%'";
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        _searchBy = "B.LableName Like '%" + param.sSearch + "%' or B.SequenceNumber Like '%" + param.sSearch + "%' or B.ColumnNumber Like'%" + param.sSearch + "%' or B.FieldName Like'%" + param.sSearch + "%'";
                    }
                    break;
                case 2:
                    _sortBy = "B.SequenceNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        // _searchBy = "A.MarchandiseGroupCode like '%'";
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        _searchBy = "B.LableName Like '%" + param.sSearch + "%' or B.SequenceNumber Like '%" + param.sSearch + "%' or B.ColumnNumber Like'%" + param.sSearch + "%' or B.FieldName Like'%" + param.sSearch + "%'";
                    }
                    break;
                case 3:
                    _sortBy = "B.ColumnNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        // _searchBy = "A.MarchandiseGroupCode like '%'";
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        _searchBy = "B.LableName Like '%" + param.sSearch + "%' or B.SequenceNumber Like '%" + param.sSearch + "%' or B.ColumnNumber Like'%" + param.sSearch + "%' or B.FieldName Like'%" + param.sSearch + "%'";
                    }
                    break;
                case 4:
                    _sortBy = "B.FieldName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        // _searchBy = "A.MarchandiseGroupCode like '%'";
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        _searchBy = "B.LableName Like '%" + param.sSearch + "%' or B.SequenceNumber Like '%" + param.sSearch + "%' or B.ColumnNumber Like'%" + param.sSearch + "%' or B.FieldName Like'%" + param.sSearch + "%'";
                    }
                    break;
            }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetTaskApprovalFormFieldNameMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);


                var result = from c in records select new[] { Convert.ToString(c.TaskApprovalFormFieldMasterId), Convert.ToString(c.FormName), Convert.ToString(c.LableName), Convert.ToString(c.SequenceNumber), Convert.ToString(c.ColumnNumber), Convert.ToString(c.FieldName), Convert.ToString(c.TaskApprovalFormFieldNameDetailsID) };

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
        #endregion