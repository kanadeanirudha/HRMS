using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class InventoryConsumptionDetailDrillReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IInventoryConsumptionDetailDrillReportServiceAccess _InventoryConsumptionDetailDrillReportServiceAccess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static int _generalUnitsID;
        protected static int _ProcessUnitID;
        //protected static string _ReportForPage;
        protected static string _granularity;
        protected static string _granularityName;
        protected static string _generalUnitsName;
        protected static string _selectedGeneralUnitsID;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        // protected static string 
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryConsumptionDetailDrillReportController()
        {
            _InventoryConsumptionDetailDrillReportServiceAccess = new InventoryConsumptionDetailDrillReportServiceAccess();
            _GeneralUnitsServiceAccess = new GeneralUnitsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            InventoryConsumptionDetailDrillReportViewModel model = new InventoryConsumptionDetailDrillReportViewModel();

            //For Granularity
            model.ProcessUnitID = 1;
            List<SelectListItem> Granularity = new List<SelectListItem>();
            ViewBag.Granularity = new SelectList(Granularity, "Value", "Text");
            List<SelectListItem> li_GranularityList = new List<SelectListItem>();
            li_GranularityList.Add(new SelectListItem { Text = "Daily", Value = "1" });
            li_GranularityList.Add(new SelectListItem { Text = "Weekly", Value = "2" });
            li_GranularityList.Add(new SelectListItem { Text = "Monthly", Value = "3" });
            li_GranularityList.Add(new SelectListItem { Text = "Yearly", Value = "4" });

            ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", model.InventoryConsumptionDetailDrillReportDTO.Granularity);
            //For Store
            List<InventoryConsumptionDetailDrillReport> listGeneralUnitsDetails = GetGeneralUnitsDropdownForProccesingUnit(_centreCode);
            List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            foreach (InventoryConsumptionDetailDrillReport item in listGeneralUnitsDetails)
            {
                GeneralUnitsList.Add(new SelectListItem { Text = item.GeneralUnitsName, Value = Convert.ToString(item.GeneralUnitsID + "~" + item.ProcessUnitID) });
            }
            ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory_1/Report/InventoryConsumptionDetailDrillReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(InventoryConsumptionDetailDrillReportViewModel model)
        {



            List<SelectListItem> Granularity = new List<SelectListItem>();
            // ViewBag.Granularity = new SelectList(Granularity, "Value", "Text");
            List<SelectListItem> li_GranularityList = new List<SelectListItem>();
            li_GranularityList.Add(new SelectListItem { Text = "Daily", Value = "1" });
            li_GranularityList.Add(new SelectListItem { Text = "Weekly", Value = "2" });
            li_GranularityList.Add(new SelectListItem { Text = "Monthly", Value = "3" });
            li_GranularityList.Add(new SelectListItem { Text = "Yearly", Value = "4" });

            if (model.IsPosted == true)
            {
                if (model.CentreCode != null)
                {
                    string[] IDsArray = model.SelectedGeneralUnitsID.Split('~');
                    model.GeneralUnitsID = Convert.ToInt32(IDsArray[0]);
                    model.ProcessUnitID = Convert.ToInt32(IDsArray[1]);
                }
                _generalUnitsID = model.GeneralUnitsID;
                _dateFrom = model.DateFrom;
                _dateTo = model.DateTo;
                _granularity = model.Granularity;
                _generalUnitsName = model.GeneralUnitsName;
                _granularityName = model.GranularityName;
                _ProcessUnitID = model.ProcessUnitID;
                _selectedGeneralUnitsID = model.SelectedGeneralUnitsID;
                _centreCode = model.CentreCode;
                _centreName = model.CentreName;
                ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", model.Granularity);

                //model.ListGeneralUnits = GetGeneralUnitsDropdownForProccesingUnit(_centreCode);

                model.IsPosted = false;
            }
            else
            {
                model.GeneralUnitsID = _generalUnitsID;
                model.DateFrom = _dateFrom;
                model.DateTo = _dateTo;
                model.Granularity = _granularity;
                model.GeneralUnitsName = _generalUnitsName;
                model.GranularityName = _granularityName;
                model.ProcessUnitID = _ProcessUnitID;
                model.CentreCode = _centreCode;
                model.CentreName = _centreName;

                ViewBag.GranularityList = new SelectList(li_GranularityList, "Value", "Text", _granularity);
            }

            List<InventoryConsumptionDetailDrillReport> listGeneralUnitsDetails = GetGeneralUnitsDropdownForProccesingUnit(_centreCode);
            List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            foreach (InventoryConsumptionDetailDrillReport item in listGeneralUnitsDetails)
            {
                GeneralUnitsList.Add(new SelectListItem { Text = item.GeneralUnitsName, Value = Convert.ToString(item.GeneralUnitsID + "~" + item.ProcessUnitID) });
            }
            ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text", model.GeneralUnitsID + "~" + model.ProcessUnitID);

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory_1/Report/InventoryConsumptionDetailDrillReport/Index.cshtml", model);
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

        protected List<GeneralUnits> GetGeneralUnitsForItemmaster()
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralUnits> ListGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsServiceAccess.GetGeneralUnitsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }
        //For Proccess unit

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUnitList(string centreCode)
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
            var university = GetGeneralUnitsDropdownForProccesingUnit(centreCode);
            var result = (from s in university
                          select new
                          {
                              id = Convert.ToString(s.GeneralUnitsID + "~" + s.ProcessUnitID),
                              unitName = s.GeneralUnitsName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<InventoryConsumptionDetailDrillReport> GetGeneralUnitsDropdownForProccesingUnit(string centreCode)
        {
            InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = centreCode;
            List<InventoryConsumptionDetailDrillReport> ListInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetGeneralUnitsDropdownForProccesingUnit(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryConsumptionDetailDrillReport;
        }
        //For Group Description

        public List<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_GroupDesciption()
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                if (_dateFrom != null && _dateTo != null)
                {
                    searchRequest.GeneralUnitsName = _generalUnitsName;
                    searchRequest.GranularityName = _granularityName;
                    searchRequest.GeneralUnitsID = _generalUnitsID;
                    searchRequest.Granularity = _granularity;
                    searchRequest.DateFrom = _dateFrom;
                    searchRequest.DateTo = _dateTo;
                    IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventoryConsumptionDetailDrillReportBySearch_GroupDescription(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }

                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //For Dept Name 
        public List<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseDepartmentNameWise(string MarchandiseGroupCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MarchandiseGroupCode = MarchandiseGroupCode;

                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseDepartmentNameWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //// For Category Name
        public List<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(string MerchantiseDepartmentCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MerchantiseDepartmentCode = MerchantiseDepartmentCode;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        ////For Sub category name List
        public List<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseSubCategoryNameWise(string MerchantiseCategoryCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MerchantiseCategoryCode = MerchantiseCategoryCode;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseSubCategoryNameWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        ////For Base Category Name

        public List<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseBaseCategoryNameWise(string MarchandiseSubCatgoryCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MarchandiseSubCatgoryCode = MarchandiseSubCatgoryCode;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseBaseCategoryNameWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        ////for Item Descriptin
        public List<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_DescriptionWise(string MarchandiseBaseCatgoryCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MarchandiseBaseCatgoryCode = MarchandiseBaseCatgoryCode;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventoryConsumptionDetailDrillReportBySearch_DescriptionWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //----------------------------------------------------------Sale and Wastage-----------------------------------------------------
        public List<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_GroupDescription()
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                if (_dateFrom != null && _dateTo != null)
                {
                    searchRequest.GeneralUnitsName = _generalUnitsName;
                    searchRequest.GranularityName = _granularityName;
                    searchRequest.GeneralUnitsID = _generalUnitsID;
                    searchRequest.Granularity = _granularity;
                    searchRequest.DateFrom = _dateFrom;
                    searchRequest.DateTo = _dateTo;
                    IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventorySaleandWastageReportBySearch_GroupDescription(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseDepartmentNameWise(string MarchandiseGroupCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MarchandiseGroupCode = MarchandiseGroupCode;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventorySaleandWastageReportBySearch_MerchandiseDepartmentNameWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseCategoryNameWise(string MerchandiseDepartmentCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MerchandiseDepartmentCode = MerchandiseDepartmentCode;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventorySaleandWastageReportBySearch_MerchandiseCategoryNameWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseSubCategoryNameWise(string MerchandiseCategoryCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MerchandiseCategoryCode = MerchandiseCategoryCode;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventorySaleandWastageReportBySearch_MerchandiseSubCategoryNameWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseBaseCategoryNameWise(string MarchandiseSubCatgoryCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MarchandiseSubCatgoryCode = MarchandiseSubCatgoryCode;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventorySaleandWastageReportBySearch_MerchandiseBaseCategoryNameWise(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_ItemDescription(string MarchandiseBaseCatgoryCode)
        {
            try
            {
                List<InventoryConsumptionDetailDrillReport> listInventoryConsumptionDetailDrillReport = new List<InventoryConsumptionDetailDrillReport>();
                InventoryConsumptionDetailDrillReportSearchRequest searchRequest = new InventoryConsumptionDetailDrillReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                searchRequest.MarchandiseBaseCatgoryCode = MarchandiseBaseCatgoryCode;
                searchRequest.GeneralUnitsName = _generalUnitsName;
                searchRequest.GranularityName = _granularityName;
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.Granularity = _granularity;
                searchRequest.DateFrom = _dateFrom;
                searchRequest.DateTo = _dateTo;
                IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> baseEntityCollectionResponse = _InventoryConsumptionDetailDrillReportServiceAccess.GetInventorySaleandWastageReportBySearch_ItemDescription(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryConsumptionDetailDrillReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryConsumptionDetailDrillReport;
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
