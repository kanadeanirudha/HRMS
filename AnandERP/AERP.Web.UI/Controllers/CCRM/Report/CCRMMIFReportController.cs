using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using AERP.Common;
using AERP.DataProvider;
using AERP.Business.BusinessActions;

namespace AERP.Web.UI.Controllers
{
    public class CCRMMIFReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMMIFReportBA _CCRMMIFReportBA = null;
        ICCRMContractTypesMasterBA _CCRMContractTypesMasterBA = null;
        ICCRMAreaPatchMasterBA _CCRMAreaPatchMasterBA = null;
        private readonly ILogger _logException;
        protected static int _vendorID;
        protected static string _Status = string.Empty;
        protected static string _Category = string.Empty;
        protected static int _ContractTypeId = 0;
        protected static int _EngineerID = 0;
        protected static Int16 _CCRMAreaPatchMasterID = 0;
        private short _VendorID;
        public string _ReportFor { get; set; }
        protected static string _ReportForPage;
        //public string ListAllVendor { get; set; }

        #endregion
        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public CCRMMIFReportController()
        {
            _CCRMMIFReportBA = new CCRMMIFReportBA();
            _CCRMContractTypesMasterBA = new CCRMContractTypesMasterBA();
            _CCRMAreaPatchMasterBA = new CCRMAreaPatchMasterBA();
        }
        #endregion
        #region ------------CONTROLLER ACTION METHODS------------
        // GET: CCRMMIFReport
        public ActionResult Index()
        {
            CCRMMIFReportViewModel model = new CCRMMIFReportViewModel();
            //*********************CCRMContractTypeMaster*********************//
            List<CCRMContractTypesMaster> CCRMContractTypesMaster = GetCCRMContractTypesMaster();
            List<SelectListItem> CCRMContractTypesMasterList = new List<SelectListItem>();
            foreach (CCRMContractTypesMaster item in CCRMContractTypesMaster)
            {
                CCRMContractTypesMasterList.Add(new SelectListItem { Text = item.ContractCode, Value = Convert.ToString(item.ContractTypeId) });
            }
            ViewBag.CCRMContractTypesMasterList = new SelectList(CCRMContractTypesMasterList, "Value", "Text", model.ContractTypeId);
            //*********************EmployeeSrviveEngg*********************//
            List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
            List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
            {
                EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
            }
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.EngineerID);
            //*********************CCRMAreaPatchMaster*********************//
            List<CCRMAreaPatchMaster> CCRMAreaPatchMaster = GetCCRMAreaPatchMaster();
            List<SelectListItem> CCRMAreaPatchMasterList = new List<SelectListItem>();
            foreach (CCRMAreaPatchMaster item in CCRMAreaPatchMaster)
            {
                CCRMAreaPatchMasterList.Add(new SelectListItem { Text = item.AreaPatchName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMAreaPatchMasterList = new SelectList(CCRMAreaPatchMasterList, "Value", "Text", model.CCRMAreaPatchMasterID);
            //*********************status*********************//
            List<SelectListItem> Status = new List<SelectListItem>();
            ViewBag.Status = new SelectList(Status, "Value", "Text");
            List<SelectListItem> li_Status = new List<SelectListItem>();

           // li_Status.Add(new SelectListItem { Text = "All", Value = "0" });
            li_Status.Add(new SelectListItem { Text = "Active", Value = "1" });
             li_Status.Add(new SelectListItem { Text = "InActive", Value = "2" });
            // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
            //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
            ViewData["Status"] = li_Status;
            //*********************Category*********************//
            List<SelectListItem> Category = new List<SelectListItem>();
            ViewBag.Category = new SelectList(Category, "Value", "Text");
            List<SelectListItem> li_Category = new List<SelectListItem>();

            // li_Status.Add(new SelectListItem { Text = "All", Value = "0" });
            li_Category.Add(new SelectListItem { Text = "Copier", Value = "1" });
            li_Category.Add(new SelectListItem { Text = "NonCopier", Value = "2" });
            li_Category.Add(new SelectListItem { Text = "Other", Value = "3" });
            //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
            ViewData["Category"] = li_Category;



            return View("/Views/CCRM/Report/CCRMMIFReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(CCRMMIFReportViewModel model)
        {
            //*********************CCRMContractTypeMaster*********************//
            List<CCRMContractTypesMaster> CCRMContractTypesMaster = GetCCRMContractTypesMaster();
            List<SelectListItem> CCRMContractTypesMasterList = new List<SelectListItem>();
            foreach (CCRMContractTypesMaster item in CCRMContractTypesMaster)
            {
                CCRMContractTypesMasterList.Add(new SelectListItem { Text = item.ContractCode, Value = Convert.ToString(item.ContractTypeId) });
            }
            ViewBag.CCRMContractTypesMasterList = new SelectList(CCRMContractTypesMasterList, "Value", "Text", model.ContractTypeId);
            //*********************EmployeeSrviveEngg*********************//
            List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
            List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
            {
                EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
            }
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.EngineerID);
            //*********************CCRMAreaPatchMaster*********************//
            List<CCRMAreaPatchMaster> CCRMAreaPatchMaster = GetCCRMAreaPatchMaster();
            List<SelectListItem> CCRMAreaPatchMasterList = new List<SelectListItem>();
            foreach (CCRMAreaPatchMaster item in CCRMAreaPatchMaster)
            {
                CCRMAreaPatchMasterList.Add(new SelectListItem { Text = item.AreaPatchName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMAreaPatchMasterList = new SelectList(CCRMAreaPatchMasterList, "Value", "Text", model.CCRMAreaPatchMasterID);
            // model.CCRMMIFReportDTO.Status = model.Status;
            if (model.IsPosted == true)
            {
                _Status = model.Status;
                _ContractTypeId = model.ContractTypeId;
                _EngineerID = model.EngineerID;
                _CCRMAreaPatchMasterID = model.CCRMAreaPatchMasterID;
                _Category = model.Category;

                model.IsPosted = false;
            }
            else
            {
                model.Status = _Status;
                model.ContractTypeId = _ContractTypeId;
                model.EngineerID = _EngineerID;
                model.CCRMAreaPatchMasterID = _CCRMAreaPatchMasterID;
                model.Category = _Category;
            }
            List<SelectListItem> Status = new List<SelectListItem>();
            ViewBag.Status = new SelectList(Status, "Value", "Text");
            List<SelectListItem> li_Status = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
           // li_Status.Add(new SelectListItem { Text = "All", Value = "0" });
            li_Status.Add(new SelectListItem { Text = "Active", Value = "1" });
            li_Status.Add(new SelectListItem { Text = "InActive", Value = "2" });

            ViewData["Status"] = new SelectList(li_Status, "Value", "Text", (model.CCRMMIFReportDTO.Status).ToString().Trim());
            //*********************Category*********************//
            List<SelectListItem> Category = new List<SelectListItem>();
            ViewBag.Category = new SelectList(Category, "Value", "Text");
            List<SelectListItem> li_Category = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
            // li_Status.Add(new SelectListItem { Text = "All", Value = "0" });
            li_Category.Add(new SelectListItem { Text = "Copier", Value = "1" });
            li_Category.Add(new SelectListItem { Text = "NonCopier", Value = "2" });
            li_Category.Add(new SelectListItem { Text = "Other", Value = "3" });
            ViewData["Category"] = new SelectList(li_Category, "Value", "Text", (model.CCRMMIFReportDTO.Category).ToString().Trim());

            return View("/Views/CCRM/Report/CCRMMIFReport/Index.cshtml", model);
        }


        #endregion
        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<CCRMMIFReport> GetContractExpiryList()
        {
            try
            {
                List<CCRMMIFReport> listCCRMMIFReport = new List<CCRMMIFReport>();
                CCRMMIFReportSearchRequest searchRequest = new CCRMMIFReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                if (_ContractTypeId > 0 && _EngineerID > 0)
                {
                    searchRequest.ContractTypeId = _ContractTypeId;
                    searchRequest.EngineerID = _EngineerID;
                    searchRequest.CCRMAreaPatchMasterID = _CCRMAreaPatchMasterID;
                    searchRequest.Status = _Status;
                    searchRequest.Category = _Category;
                    IBaseEntityCollectionResponse<CCRMMIFReport> baseEntityCollectionResponse = _CCRMMIFReportBA.GetCCRMMIFReportBySearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listCCRMMIFReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listCCRMMIFReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        protected List<CCRMContractTypesMaster> GetCCRMContractTypesMaster()
        {
            CCRMContractTypesMasterSearchRequest searchRequest = new CCRMContractTypesMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMContractTypesMaster> listCCRMContractTypesMaster = new List<CCRMContractTypesMaster>();
            IBaseEntityCollectionResponse<CCRMContractTypesMaster> baseEntityCollectionResponse = _CCRMContractTypesMasterBA.GetCCRMContractTypesMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMContractTypesMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMContractTypesMaster;
        }
        protected List<CCRMAreaPatchMaster> GetCCRMAreaPatchMaster()
        {
            CCRMAreaPatchMasterSearchRequest searchRequest = new CCRMAreaPatchMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMAreaPatchMaster> listCCRMAreaPatchMaster = new List<CCRMAreaPatchMaster>();
            IBaseEntityCollectionResponse<CCRMAreaPatchMaster> baseEntityCollectionResponse = _CCRMAreaPatchMasterBA.GetCCRMAreaPatchMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMAreaPatchMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMAreaPatchMaster;
        }
        #endregion
        public string ReportFor { get; set; }



        public List<CCRMMIFReport> ListAllContractExpiry { get; set; }
    }
}