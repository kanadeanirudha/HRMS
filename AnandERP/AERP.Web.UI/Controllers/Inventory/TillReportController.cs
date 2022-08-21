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
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class TillReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ITillReportServiceAccess _TillReportServiceAccess = null;
        IGeneralCounterMasterServiceAccess _GeneralCounterMasterServiceAccess = null;
        private readonly ILogger _logException;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public TillReportController()
        {
            _TillReportServiceAccess = new TillReportServiceAccess();
            _GeneralCounterMasterServiceAccess = new GeneralCounterMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            TillReportViewModel model = new TillReportViewModel();

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();
            //List<GeneralCounterPOSAndPosOperator> CounterMaster = GetListCounterMaster();
            //List<SelectListItem> CounterMasterList = new List<SelectListItem>();
            //foreach (GeneralCounterPOSAndPosOperator item in CounterMaster)
            //{
            //    CounterMasterList.Add(new SelectListItem { Text = item.GeneralCounterMasterName, Value = Convert.ToString(item.GeneralCounterMasterId) });
            //}
            //ViewBag.CounterMasterList = new SelectList(CounterMasterList, "Value", "Text");

            return View("/Views/Inventory_1/TillReport/Index.cshtml", model);
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                TillReportViewModel model = new TillReportViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/TillReport/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string TransactionDate, Int16 CounterId)
        {
            TillReportViewModel model = new TillReportViewModel();

            model.TillReportDTO = new TillReport();
            model.TillReportDTO.CounterId = CounterId;
            model.TillReportDTO.TransactionDate = TransactionDate;
            model.TillReportDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<TillReport> response = _TillReportServiceAccess.TillReportGetData(model.TillReportDTO);
            if (response != null && response.Entity != null)
            {
                model.TillReportDTO.TotalBillRetailCard = response.Entity.TotalBillRetailCard;
                model.TillReportDTO.TotalBillRetailCash = response.Entity.TotalBillRetailCash;
                model.TillReportDTO.TotalBillRestaurantCard = response.Entity.TotalBillRestaurantCard;
                model.TillReportDTO.TotalBillRestaurantCash = response.Entity.TotalBillRestaurantCash;
                model.TillReportDTO.TotalCardPayment = response.Entity.TotalCardPayment;
                model.TillReportDTO.TotalCashPayment = response.Entity.TotalCashPayment;
                model.TillReportDTO.TotalReatailPayment = response.Entity.TotalReatailPayment;
                model.TillReportDTO.TotalRestaurantPayment = response.Entity.TotalRestaurantPayment;
            }

            return PartialView("/Views/Inventory_1/TillReport/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(TillReportViewModel model)
        {
            try
            {
                if (model != null && model.TillReportDTO != null)
                {
                    model.TillReportDTO.ConnectionString = _connectioString;

                    model.TillReportDTO.CashReceived = model.CashReceived;
                    model.TillReportDTO.DescripancyInCash = model.DescripancyInCash;
                    model.TillReportDTO.TransactionDate = model.TransactionDate;
                    model.TillReportDTO.CounterId = model.CounterId;
                    model.TillReportDTO.TotalCashPayment = model.TotalCashPayment;
                    model.TillReportDTO.TotalCardPayment = model.TotalCardPayment;
                    model.TillReportDTO.UserID = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<TillReport> response = _TillReportServiceAccess.TillReportSaveData(model.TillReportDTO);

                    model.TillReportDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.TillReportDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<AdminRoleApplicableDetails> GetCentreListByRoleAuthorization()
        {
            RetailReportsViewModel model = new RetailReportsViewModel();
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }
            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
            AdminRoleApplicableDetails a = null;
            foreach (var item in listAdminRoleApplicableDetails)
            {
                a = new AdminRoleApplicableDetails();
                a.CentreCode = item.CentreCode;
                a.CentreName = item.CentreName;
                model.ListGetAdminRoleApplicableCentre.Add(a);
            }
            return model.ListGetAdminRoleApplicableCentre;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCounterList(string centreCode)
        {
            //string[] splited;
            //splited = SelectedCentreCode.Split(':');
            //_OrganisationSectionDetailsBaseViewModel.SelectedCentreName = splited[1];
            //SelectedCentreCode = splited[0];
            if (String.IsNullOrEmpty(centreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(centreCode, out id);
            var university = GetListCounterMaster(centreCode);
            var result = (from s in university
                          select new
                          {
                              id = s.ID,
                              counterName = s.CounterName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<GeneralCounterMaster> GetListCounterMaster(string centreCode)
        {
            GeneralCounterMasterSearchRequest searchRequest = new GeneralCounterMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = centreCode;
            List<GeneralCounterMaster> ListCounterMaster = new List<GeneralCounterMaster>();
            IBaseEntityCollectionResponse<GeneralCounterMaster> baseEntityCollectionResponse = _GeneralCounterMasterServiceAccess.GetGeneralCounterMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListCounterMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListCounterMaster;
        }


        public List<TillReport> GetTillReport()
        {
            try
            {
                List<TillReport> listTillReport = new List<TillReport>();
                TillReportSearchRequest searchRequest = new TillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                IBaseEntityCollectionResponse<TillReport> baseEntityCollectionResponse = _TillReportServiceAccess.GetTillReport(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listTillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                return listTillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion



    }
}
