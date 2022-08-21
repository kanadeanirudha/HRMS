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
    public class CCRMCallLogReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMCallLogReportBA _CCRMCallLogReportBA = null;
        ICCRMContractTypesMasterBA _CCRMContractTypesMasterBA = null;
        ICCRMAreaPatchMasterBA _CCRMAreaPatchMasterBA = null;
        ICCRMServiceCallTypesBA _CCRMServiceCallTypesBA = null;
        ICCRMLocationTypeMasterBA _CCRMLocationTypeMasterBA = null;
        ICCRMCallAllotmentMasterBA _CCRMCallAllotmentMasterBA = null;
        ICCRMComplaintLoggingMasterBA _CCRMComplaintLoggingMasterBA = null;
        private readonly ILogger _logException;
        protected static int _vendorID;
        protected static string _SerialNo= string.Empty;
        protected static string _MIFType = string.Empty;
        protected static string _Category = string.Empty;
        protected static string _SCNSubmitted = string.Empty;
        protected static string _CallStatus = string.Empty;
        protected static int _ContractTypeId = 0;
        protected static int _EngineerID = 0;
        protected static int _CallTypeID = 0;
        protected static int _CCRMLocationTypeID = 0;
        protected static int _AllotUserID = 0;
        protected static int _LoggID = 0;
        protected static Int16 _CCRMAreaPatchMasterID = 0;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        private short _VendorID;
        public string _ReportFor { get; set; }
        protected static string _ReportForPage;
        //public string ListAllVendor { get; set; }

        #endregion
        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public CCRMCallLogReportController()
        {
            _CCRMCallLogReportBA = new CCRMCallLogReportBA();
            _CCRMContractTypesMasterBA = new CCRMContractTypesMasterBA();
            _CCRMAreaPatchMasterBA = new CCRMAreaPatchMasterBA();
            _CCRMServiceCallTypesBA = new CCRMServiceCallTypesBA();
            _CCRMLocationTypeMasterBA = new CCRMLocationTypeMasterBA();
            _CCRMCallAllotmentMasterBA = new CCRMCallAllotmentMasterBA();
            _CCRMComplaintLoggingMasterBA = new CCRMComplaintLoggingMasterBA();
        }
        #endregion
        #region ------------CONTROLLER ACTION METHODS------------
        // GET: CCRMCallLogReport
        public ActionResult Index()
        {
            CCRMCallLogReportViewModel model = new CCRMCallLogReportViewModel();
            //*********************CCRMContractTypeMaster*********************//
            List<CCRMContractTypesMaster> CCRMContractTypesMaster = GetCCRMContractTypesMaster();
            List<SelectListItem> CCRMContractTypesMasterList = new List<SelectListItem>();
            CCRMContractTypesMasterList.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (CCRMContractTypesMaster item in CCRMContractTypesMaster)
            {
                CCRMContractTypesMasterList.Add(new SelectListItem { Text = item.ContractCode, Value = Convert.ToString(item.ContractTypeId) });
            }
            ViewBag.CCRMContractTypesMasterList = new SelectList(CCRMContractTypesMasterList, "Value", "Text", model.ContractTypeId);
            ////*********************EmployeeSrviveEngg*********************//
            List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
            List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
            EmpEmployeeMasterList.Add(new SelectListItem { Text = "All", Value ="0" });
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
            {
                EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
            }
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.EngineerID);
            //*********************CCRMServiceCallTypes*********************//
            List<CCRMServiceCallTypes> CCRMServiceCallTypes = GetCCRMServiceCallTypes();
            List<SelectListItem> CCRMServiceCallTypesList = new List<SelectListItem>();
            CCRMServiceCallTypesList.Add(new SelectListItem { Text = "All", Value = "0" });
            foreach (CCRMServiceCallTypes item in CCRMServiceCallTypes)
            {
                CCRMServiceCallTypesList.Add(new SelectListItem { Text = item.CallTypeCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMServiceCallTypesList = new SelectList(CCRMServiceCallTypesList, "Value", "Text", model.CallTypeID);

            //*********************Location*********************//
            List<CCRMLocationTypeMaster> CCRMLocationTypeMaster = GetCCRMLocationTypeMaster();
            List<SelectListItem> CCRMLocationTypeMasterList = new List<SelectListItem>();
            CCRMLocationTypeMasterList.Add(new SelectListItem { Text = "All", Value = "0" });
            foreach (CCRMLocationTypeMaster item in CCRMLocationTypeMaster)
            {
                CCRMLocationTypeMasterList.Add(new SelectListItem { Text = item.LocationTypeCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMLocationTypeMasterList = new SelectList(CCRMLocationTypeMasterList, "Value", "Text", model.CCRMLocationTypeID);
            //*********************CCRMCallAllotmentMaster*********************//
            List<CCRMCallAllotmentMaster> CCRMCallAllotmentMaster = GetCCRMCallAllotmentMaster();
            List<SelectListItem> CCRMCallAllotmentMasterList = new List<SelectListItem>();
            CCRMCallAllotmentMasterList.Add(new SelectListItem { Text ="All", Value = "0" });
            foreach (CCRMCallAllotmentMaster item in CCRMCallAllotmentMaster)
            {
                CCRMCallAllotmentMasterList.Add(new SelectListItem { Text = item.UserName, Value = Convert.ToString(item.UserID) });
            }
            ViewBag.CCRMCallAllotmentMasterList = new SelectList(CCRMCallAllotmentMasterList, "Value", "Text", model.UserID);
            //*********************CCRMComplaintLoggingMaster*********************//
            List<CCRMComplaintLoggingMaster> CCRMComplaintLoggingMaster = GetCCRMComplaintLoggingMaster();
            List<SelectListItem> CCRMComplaintLoggingMasterList = new List<SelectListItem>();
            CCRMComplaintLoggingMasterList.Add(new SelectListItem { Text ="All", Value = "0" });
            foreach (CCRMComplaintLoggingMaster item in CCRMComplaintLoggingMaster)
            {
                CCRMComplaintLoggingMasterList.Add(new SelectListItem { Text = item.UserName, Value = Convert.ToString(item.UserID) });
            }
            ViewBag.CCRMComplaintLoggingMasterList = new SelectList(CCRMComplaintLoggingMasterList, "Value", "Text", model.LoggID);
            ////*********************CCRMAreaPatchMaster*********************//
            //List<CCRMAreaPatchMaster> CCRMAreaPatchMaster = GetCCRMAreaPatchMaster();
            //List<SelectListItem> CCRMAreaPatchMasterList = new List<SelectListItem>();
            //foreach (CCRMAreaPatchMaster item in CCRMAreaPatchMaster)
            //{
            //    CCRMAreaPatchMasterList.Add(new SelectListItem { Text = item.AreaPatchName, Value = Convert.ToString(item.ID) });
            //}
            //ViewBag.CCRMAreaPatchMasterList = new SelectList(CCRMAreaPatchMasterList, "Value", "Text", model.CCRMAreaPatchMasterID);
            ////*********************MIFType*********************//
            List<SelectListItem> MIFType = new List<SelectListItem>();
            ViewBag.MIFType = new SelectList(MIFType, "Value", "Text");
            List<SelectListItem> li_MIFType = new List<SelectListItem>();

            li_MIFType.Add(new SelectListItem { Text = "All", Value = "0" });
            li_MIFType.Add(new SelectListItem { Text = "Dealer", Value = "1" });
            li_MIFType.Add(new SelectListItem { Text = "Company", Value = "2" });
            // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
            //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
            ViewData["MIFType"] = li_MIFType;
            ////*********************SCNSubmitted*********************//
            List<SelectListItem> SCNSubmitted = new List<SelectListItem>();
            ViewBag.SCNSubmitted = new SelectList(SCNSubmitted, "Value", "Text");
            List<SelectListItem> li_SCNSubmitted = new List<SelectListItem>();

            li_SCNSubmitted.Add(new SelectListItem { Text = "All", Value = "2" });
            li_SCNSubmitted.Add(new SelectListItem { Text = "SCN Submited", Value = "1" });
            li_SCNSubmitted.Add(new SelectListItem { Text = "SCN Missing", Value = "0" });
            // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
            //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
            ViewData["SCNSubmitted"] = li_SCNSubmitted;
            ////*********************Status*********************//
            List<SelectListItem> CallStatus = new List<SelectListItem>();
            ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
            List<SelectListItem> li_CallStatus = new List<SelectListItem>();

            li_CallStatus.Add(new SelectListItem { Text = "All", Value = "0" });
            li_CallStatus.Add(new SelectListItem { Text = "Unalloted Calls", Value = "3" });
            li_CallStatus.Add(new SelectListItem { Text = "Alloted Unattended Call", Value = "4" });
            li_CallStatus.Add(new SelectListItem { Text = "Complete Calls", Value = "1" });
            li_CallStatus.Add(new SelectListItem { Text = "Broken Calls", Value = "2" });
            // li_Printer.Add(new SelectListItem { Text = "Low", Value = "3" });
            //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
            ViewData["CallStatus"] = li_CallStatus;


            return View("/Views/CCRM/Report/CCRMCallLogReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(CCRMCallLogReportViewModel model)
        {
            //*********************CCRMContractTypeMaster*********************//
            List<CCRMContractTypesMaster> CCRMContractTypesMaster = GetCCRMContractTypesMaster();
            List<SelectListItem> CCRMContractTypesMasterList = new List<SelectListItem>();
            CCRMContractTypesMasterList.Add(new SelectListItem { Text = "All", Value = "0"});
            //ViewBag.CCRMContractTypesMasterList = new SelectList(CCRMContractTypesMasterList, "0", "select", model.ContractTypeId);
            foreach (CCRMContractTypesMaster item in CCRMContractTypesMaster)
            {
                CCRMContractTypesMasterList.Add(new SelectListItem { Text = item.ContractCode, Value = Convert.ToString(item.ContractTypeId) });
            }
         
            ViewBag.CCRMContractTypesMasterList = new SelectList(CCRMContractTypesMasterList, "Value", "Text", model.ContractTypeId);
            
            //*********************EmployeeSrviveEngg*********************//
            List<EmpEmployeeMaster> EmpEmployeeMaster = GetEmpEmployeeMasterService();
            List<SelectListItem> EmpEmployeeMasterList = new List<SelectListItem>();
            EmpEmployeeMasterList.Add(new SelectListItem { Text = "All", Value = "0" });
            foreach (EmpEmployeeMaster item in EmpEmployeeMaster)
            {
                EmpEmployeeMasterList.Add(new SelectListItem { Text = item.EmployeeName, Value = Convert.ToString(item.EmployeeID) });
            }
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMasterList, "Value", "Text", model.EngineerID);
            //*********************CCRMServiceCallTypes*********************//
            List<CCRMServiceCallTypes> CCRMServiceCallTypes = GetCCRMServiceCallTypes();
            List<SelectListItem> CCRMServiceCallTypesList = new List<SelectListItem>();
            CCRMServiceCallTypesList.Add(new SelectListItem { Text = "All", Value = "0" });
            foreach (CCRMServiceCallTypes item in CCRMServiceCallTypes)
            {
                CCRMServiceCallTypesList.Add(new SelectListItem { Text = item.CallTypeCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMServiceCallTypesList = new SelectList(CCRMServiceCallTypesList, "Value", "Text", model.CallTypeID);

            //*********************Location*********************//
            List<CCRMLocationTypeMaster> CCRMLocationTypeMaster = GetCCRMLocationTypeMaster();
            List<SelectListItem> CCRMLocationTypeMasterList = new List<SelectListItem>();
            CCRMLocationTypeMasterList.Add(new SelectListItem { Text = "All", Value = "0" });
            foreach (CCRMLocationTypeMaster item in CCRMLocationTypeMaster)
            {
                CCRMLocationTypeMasterList.Add(new SelectListItem { Text = item.LocationTypeCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMLocationTypeMasterList = new SelectList(CCRMLocationTypeMasterList, "Value", "Text", model.CCRMLocationTypeID);
            //*********************CCRMCallAllotmentMaster*********************//
            List<CCRMCallAllotmentMaster> CCRMCallAllotmentMaster = GetCCRMCallAllotmentMaster();
            List<SelectListItem> CCRMCallAllotmentMasterList = new List<SelectListItem>();
            CCRMCallAllotmentMasterList.Add(new SelectListItem { Text = "All", Value = "0" });
            foreach (CCRMCallAllotmentMaster item in CCRMCallAllotmentMaster)
            {
                CCRMCallAllotmentMasterList.Add(new SelectListItem { Text = item.UserName, Value = Convert.ToString(item.UserID) });
            }
            ViewBag.CCRMCallAllotmentMasterList = new SelectList(CCRMCallAllotmentMasterList, "Value", "Text", model.AllotUserID);
            //*********************CCRMComplaintLoggingMaster*********************//
            List<CCRMComplaintLoggingMaster> CCRMComplaintLoggingMaster = GetCCRMComplaintLoggingMaster();
            List<SelectListItem> CCRMComplaintLoggingMasterList = new List<SelectListItem>();
            CCRMComplaintLoggingMasterList.Add(new SelectListItem { Text = "All", Value = "0" });
            foreach (CCRMComplaintLoggingMaster item in CCRMComplaintLoggingMaster)
            {
                CCRMComplaintLoggingMasterList.Add(new SelectListItem { Text = item.UserName, Value = Convert.ToString(item.UserID) });
            }
            ViewBag.CCRMComplaintLoggingMasterList = new SelectList(CCRMComplaintLoggingMasterList, "Value", "Text", model.LoggID);
            ////*********************CCRMAreaPatchMaster*********************//
            //List<CCRMAreaPatchMaster> CCRMAreaPatchMaster = GetCCRMAreaPatchMaster();
            //List<SelectListItem> CCRMAreaPatchMasterList = new List<SelectListItem>();
            //foreach (CCRMAreaPatchMaster item in CCRMAreaPatchMaster)
            //{
            //    CCRMAreaPatchMasterList.Add(new SelectListItem { Text = item.AreaPatchName, Value = Convert.ToString(item.ID) });
            //}
            //ViewBag.CCRMAreaPatchMasterList = new SelectList(CCRMAreaPatchMasterList, "Value", "Text", model.CCRMAreaPatchMasterID);
            // model.CCRMCallLogReportDTO.Status = model.Status;
            if (model.IsPosted == true)
            {
                _MIFType = model.MIFType;
                _SCNSubmitted = model.SCNSubmitted;
                _ContractTypeId = model.ContractTypeId;
                _EngineerID = model.EngineerID;
                _CallTypeID = model.CallTypeID;
                _CCRMLocationTypeID = model.CCRMLocationTypeID;
                _AllotUserID = model.AllotUserID;
                _SerialNo = model.SerialNo;
                _dateFrom = model.DateFrom;
                _dateTo = model.DateTo;
                _LoggID = model.LoggID;
                _CallStatus = model.CallStatus;
                //  _CCRMAreaPatchMasterID = model.CCRMAreaPatchMasterID;

                model.IsPosted = false;
            }
            else
            {
                model.MIFType = _MIFType;
                model.SCNSubmitted = _SCNSubmitted;
                model.ContractTypeId = _ContractTypeId;
                model.EngineerID = _EngineerID;
                model.CallTypeID = _CallTypeID;
                model.CCRMLocationTypeID = _CCRMLocationTypeID;
                model.AllotUserID = _AllotUserID;
                model.SerialNo = _SerialNo;
                model.DateFrom = _dateFrom;
                model.DateTo = _dateTo;
                model.LoggID = _LoggID;
                model.CallStatus = _CallStatus;
                // model.CCRMAreaPatchMasterID = _CCRMAreaPatchMasterID;

            }
            List<SelectListItem> MIFType = new List<SelectListItem>();
            ViewBag.MIFType = new SelectList(MIFType, "Value", "Text");
          
            List<SelectListItem> li_MIFType = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
            li_MIFType.Add(new SelectListItem { Text = "All", Value = "0" });
            li_MIFType.Add(new SelectListItem { Text = "Dealer", Value = "1" });
            li_MIFType.Add(new SelectListItem { Text = "Company", Value = "2" });

            ViewData["MIFType"] = new SelectList(li_MIFType, "Value", "Text", (model.CCRMCallLogReportDTO.MIFType).ToString().Trim());
            ////*********************SCNSubmitted*********************//
            List<SelectListItem> SCNSubmitted = new List<SelectListItem>();
            ViewBag.SCNSubmitted = new SelectList(SCNSubmitted, "Value", "Text");
            List<SelectListItem> li_SCNSubmitted = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
            li_SCNSubmitted.Add(new SelectListItem { Text = "All", Value = "2" });
            li_SCNSubmitted.Add(new SelectListItem { Text = "SCN Submited", Value = "1" });
            li_SCNSubmitted.Add(new SelectListItem { Text = "SCN Missing", Value = "0" });

            ViewData["SCNSubmitted"] = new SelectList(li_SCNSubmitted, "Value", "Text", (model.CCRMCallLogReportDTO.SCNSubmitted).ToString().Trim());
            ////*********************CallStatus*********************//
            List<SelectListItem> CallStatus = new List<SelectListItem>();
            ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
            List<SelectListItem> li_CallStatus = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
            li_CallStatus.Add(new SelectListItem { Text = "All", Value = "0" });
            li_CallStatus.Add(new SelectListItem { Text = "Unalloted Calls", Value = "3" });
            li_CallStatus.Add(new SelectListItem { Text = "Alloted Unattended Call", Value = "4" });
            li_CallStatus.Add(new SelectListItem { Text = "Complete Calls", Value = "1" });
            li_CallStatus.Add(new SelectListItem { Text = "Broken Calls", Value = "2" });

            ViewData["CallStatus"] = new SelectList(li_CallStatus, "Value", "Text", (model.CCRMCallLogReportDTO.CallStatus).ToString().Trim());
            return View("/Views/CCRM/Report/CCRMCallLogReport/Index.cshtml", model);
        }


        #endregion
        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<CCRMCallLogReport> GetCallLogList()
        {
            try
           {
                List<CCRMCallLogReport> listCCRMCallLogReport = new List<CCRMCallLogReport>();
                CCRMCallLogReportSearchRequest searchRequest = new CCRMCallLogReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                if ( _dateFrom != string.Empty && _dateTo != string.Empty )
                {
                    searchRequest.MIFType = _MIFType;
                    searchRequest.SCNSubmitted = _SCNSubmitted;
                    searchRequest.ContractTypeId = _ContractTypeId;
                    searchRequest.EngineerID = _EngineerID;
                    searchRequest.CallTypeID = _CallTypeID;
                    searchRequest.CCRMLocationTypeID = _CCRMLocationTypeID;
                    searchRequest.AllotUserID = _AllotUserID;
                    searchRequest.SerialNo = _SerialNo;
                    searchRequest.DateFrom = _dateFrom;
                    searchRequest.DateTo = _dateTo;
                    searchRequest.LoggID = _LoggID;
                    searchRequest.CallStatus = _CallStatus;
                    // searchRequest.CCRMAreaPatchMasterID = _CCRMAreaPatchMasterID;

                    IBaseEntityCollectionResponse<CCRMCallLogReport> baseEntityCollectionResponse = _CCRMCallLogReportBA.GetCCRMCallLogReportBySearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listCCRMCallLogReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listCCRMCallLogReport;
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
            if (baseEntityCollectionResponse != null )
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMContractTypesMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMContractTypesMaster;
        }
        protected List<CCRMServiceCallTypes> GetCCRMServiceCallTypes()
        {
            CCRMServiceCallTypesSearchRequest searchRequest = new CCRMServiceCallTypesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMServiceCallTypes> listCCRMServiceCallTypes = new List<CCRMServiceCallTypes>();
            IBaseEntityCollectionResponse<CCRMServiceCallTypes> baseEntityCollectionResponse = _CCRMServiceCallTypesBA.GetCCRMServiceCallTypesList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMServiceCallTypes = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMServiceCallTypes;
        }
        protected List<CCRMLocationTypeMaster> GetCCRMLocationTypeMaster()
        {
            CCRMLocationTypeMasterSearchRequest searchRequest = new CCRMLocationTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMLocationTypeMaster> listCCRMLocationTypeMaster = new List<CCRMLocationTypeMaster>();
            IBaseEntityCollectionResponse<CCRMLocationTypeMaster> baseEntityCollectionResponse = _CCRMLocationTypeMasterBA.GetCCRMLocationTypeMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMLocationTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMLocationTypeMaster;
        }

        protected List<CCRMCallAllotmentMaster> GetCCRMCallAllotmentMaster()
        {
            CCRMCallAllotmentMasterSearchRequest searchRequest = new CCRMCallAllotmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMCallAllotmentMaster> listCCRMCallAllotmentMaster = new List<CCRMCallAllotmentMaster>();
            IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> baseEntityCollectionResponse = _CCRMCallAllotmentMasterBA.GetCCRMCallAllotmentMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMCallAllotmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMCallAllotmentMaster;
        }
        protected List<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMaster()
        {
            CCRMComplaintLoggingMasterSearchRequest searchRequest = new CCRMComplaintLoggingMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollectionResponse = _CCRMComplaintLoggingMasterBA.GetCCRMComplaintLoggedByList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMComplaintLoggingMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMComplaintLoggingMaster;
        }
        //protected List<CCRMAreaPatchMaster> GetCCRMAreaPatchMaster()
        //{
        //    CCRMAreaPatchMasterSearchRequest searchRequest = new CCRMAreaPatchMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    List<CCRMAreaPatchMaster> listCCRMAreaPatchMaster = new List<CCRMAreaPatchMaster>();
        //    IBaseEntityCollectionResponse<CCRMAreaPatchMaster> baseEntityCollectionResponse = _CCRMAreaPatchMasterBA.GetCCRMAreaPatchMasterList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listCCRMAreaPatchMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listCCRMAreaPatchMaster;
        //}
        #endregion
        public string ReportFor { get; set; }



        public List<CCRMCallLogReport> ListAllContractExpiry { get; set; }
    }
}