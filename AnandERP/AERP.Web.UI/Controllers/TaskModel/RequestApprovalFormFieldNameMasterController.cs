using System;
using System.Collections.Generic;
using System.Linq;
using AERP.Base.DTO;
using AERP.DTO;
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
    public class RequestApprovalFormFieldNameMasterController : BaseController
    {
        IRequestApprovalFormFieldNameMasterBA _RequestApprovalFormFieldNameMasterServiceAcess = null;
        IGeneralRequestMasterBA _GeneralRequestMasterBA =  null;
        
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

        public RequestApprovalFormFieldNameMasterController()
        {
            _RequestApprovalFormFieldNameMasterServiceAcess = new RequestApprovalFormFieldNameMasterBA();
            _GeneralRequestMasterBA = new GeneralRequestMasterBA();
        
        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/TaskModel/RequestApprovalFormFieldNameMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                RequestApprovalFormFieldNameMasterViewModel model = new RequestApprovalFormFieldNameMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/TaskModel/RequestApprovalFormFieldNameMaster/List.cshtml", model);
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
            RequestApprovalFormFieldNameMasterViewModel model = new RequestApprovalFormFieldNameMasterViewModel();
                  //************************** Drop Down For Request Code ***********************************************

          List<GeneralRequestMaster> GeneralRequestMaster = GetListGeneralRequestMaster();
          List<SelectListItem> GeneralRequestMasterList = new List<SelectListItem>();

                   foreach (GeneralRequestMaster item in GeneralRequestMaster)
                      {
                          GeneralRequestMasterList.Add(new SelectListItem { Text = item.RequestCode, Value = Convert.ToString(item.RequestCode) });
                      }
                      ViewBag.GeneralRequestMasterlList = new SelectList(GeneralRequestMasterList, "Value", "Text");

          
                return PartialView("/Views/TaskModel/RequestApprovalFormFieldNameMaster/Create.cshtml", model);
         }

        [HttpGet]
        public ActionResult CreateRequestApprovalFormFieldNameDetails(string IDs)
        {
            RequestApprovalFormFieldNameMasterViewModel model = new RequestApprovalFormFieldNameMasterViewModel();
            string[] IDsArray = IDs.Split('~');
            model.RequestApprovalFormFieldMasterId= Convert.ToInt32(IDsArray[0]);
            model.FormName = Convert.ToString(IDsArray[1]);

            return PartialView("/Views/TaskModel/RequestApprovalFormFieldNameMaster/CreateRequestApprovalFormFieldNameDetails.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(RequestApprovalFormFieldNameMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
               // {
                    if (model != null && model.RequestApprovalFormFieldNameMasterDTO != null)
                    {
                        model.RequestApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;
                        model.RequestApprovalFormFieldNameMasterDTO.FormName= model.FormName;
                        model.RequestApprovalFormFieldNameMasterDTO.RequestCode = model.RequestCode;
                        model.RequestApprovalFormFieldNameMasterDTO.ViewName = model.ViewName;
                        model.RequestApprovalFormFieldNameMasterDTO.InsertUpdateProcedure = model.InsertUpdateProcedure;
                        model.RequestApprovalFormFieldNameMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> response = _RequestApprovalFormFieldNameMasterServiceAcess.InsertRequestApprovalFormFieldNameMaster(model.RequestApprovalFormFieldNameMasterDTO);

                        model.RequestApprovalFormFieldNameMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        return Json(model.RequestApprovalFormFieldNameMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]   //for RequestApprovalFormFieldNameDetails
        public ActionResult CreateRequestApprovalFormFieldNameMasterDetails(RequestApprovalFormFieldNameMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.RequestApprovalFormFieldNameMasterDTO != null)
                {
                  
                    //for Request Details
                    model.RequestApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;
                   // model.RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldMasterId = model.RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldMasterId;
                    model.RequestApprovalFormFieldNameMasterDTO.XMLString = model.RequestApprovalFormFieldNameMasterDTO.XMLString;
                    model.RequestApprovalFormFieldNameMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<RequestApprovalFormFieldNameMaster> response = _RequestApprovalFormFieldNameMasterServiceAcess.InsertRequestApprovalFormFieldNameMaster(model.RequestApprovalFormFieldNameMasterDTO);

                    model.RequestApprovalFormFieldNameMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.RequestApprovalFormFieldNameMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    RequestApprovalFormFieldNameMasterViewModel model = new RequestApprovalFormFieldNameMasterViewModel();
        //    try
        //    {
        //        model.RequestApprovalFormFieldNameMasterDTO = new RequestApprovalFormFieldNameMaster();
        //        model.RequestApprovalFormFieldNameMasterDTO.ID = id;
        //        model.RequestApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> response = _RequestApprovalFormFieldNameMasterServiceAcess.SelectByID(model.RequestApprovalFormFieldNameMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.RequestApprovalFormFieldNameMasterDTO.ID = response.Entity.ID;
        //            model.RequestApprovalFormFieldNameMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.RequestApprovalFormFieldNameMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.RequestApprovalFormFieldNameMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(RequestApprovalFormFieldNameMasterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.RequestApprovalFormFieldNameMasterDTO != null)
        //        {
        //            if (model != null && model.RequestApprovalFormFieldNameMasterDTO != null)
        //            {
        //                model.RequestApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;
        //                model.RequestApprovalFormFieldNameMasterDTO.CounterName = model.CounterName;
        //                // model.RequestApprovalFormFieldNameMasterDTO.SeqNo = model.SeqNo;
        //                model.RequestApprovalFormFieldNameMasterDTO.CounterCode = model.CounterCode;
        //                //model.RequestApprovalFormFieldNameMasterDTO.DefaultFlag = model.DefaultFlag;
        //                model.RequestApprovalFormFieldNameMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<RequestApprovalFormFieldNameMaster> response = _RequestApprovalFormFieldNameMasterServiceAcess.UpdateRequestApprovalFormFieldNameMaster(model.RequestApprovalFormFieldNameMasterDTO);
        //                model.RequestApprovalFormFieldNameMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.RequestApprovalFormFieldNameMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        RequestApprovalFormFieldNameMasterViewModel model = new RequestApprovalFormFieldNameMasterViewModel();
        //        model.RequestApprovalFormFieldNameMasterDTO = new RequestApprovalFormFieldNameMaster();
        //        model.RequestApprovalFormFieldNameMasterDTO.ID = Convert.ToInt16(ID);
        //        model.RequestApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> response = _RequestApprovalFormFieldNameMasterServiceAcess.SelectByID(model.RequestApprovalFormFieldNameMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.RequestApprovalFormFieldNameMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.RequestApprovalFormFieldNameMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.RequestApprovalFormFieldNameMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.RequestApprovalFormFieldNameMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/RequestApprovalFormFieldNameMaster/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult DeleteRequestApprovalFormFieldNameDetails(int RequestApprovalFormFieldNameDetailsID)
        {
            var errorMessage = string.Empty;
            if (RequestApprovalFormFieldNameDetailsID > 0)
            {
                IBaseEntityResponse<RequestApprovalFormFieldNameMaster> response = null;
                RequestApprovalFormFieldNameMaster RequestApprovalFormFieldNameMasterDTO = new RequestApprovalFormFieldNameMaster();
                RequestApprovalFormFieldNameMasterDTO.ConnectionString = _connectioString;
                RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldNameDetailsID = Convert.ToInt32(RequestApprovalFormFieldNameDetailsID);
                RequestApprovalFormFieldNameMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _RequestApprovalFormFieldNameMasterServiceAcess.DeleteRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
      

        #endregion

        // Non-Action Method
        #region Methods
        //Dropdown for Request Code
    protected List<GeneralRequestMaster> GetListGeneralRequestMaster()
    {
       GeneralRequestMasterSearchRequest searchRequest = new GeneralRequestMasterSearchRequest();
        searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        List<GeneralRequestMaster> listAdmin = new List<GeneralRequestMaster>();
        IBaseEntityCollectionResponse<GeneralRequestMaster> baseEntityCollectionResponse = _GeneralRequestMasterBA.GetRequestCode(searchRequest);
        if (baseEntityCollectionResponse != null)
        {
            if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
            {
                listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
            }
        }
        return listAdmin;
    }






        public IEnumerable<RequestApprovalFormFieldNameMasterViewModel> GetRequestApprovalFormFieldNameMaster(out int TotalRecords)
        {
            RequestApprovalFormFieldNameMasterSearchRequest searchRequest = new RequestApprovalFormFieldNameMasterSearchRequest();
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
            List<RequestApprovalFormFieldNameMasterViewModel> listRequestApprovalFormFieldNameMasterViewModel = new List<RequestApprovalFormFieldNameMasterViewModel>();
            List<RequestApprovalFormFieldNameMaster> listRequestApprovalFormFieldNameMaster = new List<RequestApprovalFormFieldNameMaster>();
            IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> baseEntityCollectionResponse = _RequestApprovalFormFieldNameMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listRequestApprovalFormFieldNameMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (RequestApprovalFormFieldNameMaster item in listRequestApprovalFormFieldNameMaster)
                    {
                        RequestApprovalFormFieldNameMasterViewModel RequestApprovalFormFieldNameMasterViewModel = new RequestApprovalFormFieldNameMasterViewModel();
                        RequestApprovalFormFieldNameMasterViewModel.RequestApprovalFormFieldNameMasterDTO = item;
                        listRequestApprovalFormFieldNameMasterViewModel.Add(RequestApprovalFormFieldNameMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listRequestApprovalFormFieldNameMasterViewModel;
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

                IEnumerable<RequestApprovalFormFieldNameMasterViewModel> filteredGroupDescription;
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
                filteredGroupDescription = GetRequestApprovalFormFieldNameMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);


                var result = from c in records select new[] {Convert.ToString(c.RequestApprovalFormFieldNameMasterID), Convert.ToString(c.FormName), Convert.ToString(c.LableName), Convert.ToString(c.SequenceNumber), Convert.ToString(c.ColumnNumber), Convert.ToString(c.FieldName), Convert.ToString(c.RequestApprovalFormFieldNameDetailsID) };

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