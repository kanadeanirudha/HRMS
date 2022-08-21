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
namespace AMS.Web.UI.Controllers
{
    public class ECommerceSystemSettingsController : BaseController
    {
        IECommerceSystemSettingsServiceAccess _ECommerceSystemSettingsServiceAcess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public ECommerceSystemSettingsController()
        {
            _ECommerceSystemSettingsServiceAcess = new ECommerceSystemSettingsServiceAccess();
            _GeneralUnitsServiceAccess = new GeneralUnitsServiceAccess();

        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                ECommerceSystemSettingsViewModel model = new ECommerceSystemSettingsViewModel();
                return View("/Views/Inventory_1/ECommerceSystemSettings/Index.cshtml");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List()
        {
            try
            {
                ECommerceSystemSettingsViewModel model = new ECommerceSystemSettingsViewModel();

                return PartialView("/Views/Inventory_1/ECommerceSystemSettings/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        //-------------------CreateGeneralStoreData------------------------------------------
        public ActionResult CreateGeneralStoreData(string TaskCode)
        {
            ECommerceSystemSettingsSearchRequest searchRequest = new ECommerceSystemSettingsSearchRequest();

            if (TaskCode == "" || TaskCode == null)
            {
                TaskCode = "GeneralStoreData";
            }

            searchRequest.TaskCode = TaskCode;
            searchRequest.ConnectionString = _connectioString;

            IBaseEntityCollectionResponse<ECommerceSystemSettings> baseEntityCollectionResponse = _ECommerceSystemSettingsServiceAcess.GetBySearch(searchRequest);
            // ------DropDown For GeneralUnitID-------------------------------------
            List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster();
            List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            foreach (GeneralUnits item in GeneralUnits)
            {
                GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");

            ECommerceSystemSettingsViewModel model = new ECommerceSystemSettingsViewModel();
            model.TaskCode = TaskCode;
            model.GeneralUnitsID = baseEntityCollectionResponse.CollectionResponse[0].GeneralUnitsID;
            return PartialView("/Views/Inventory_1/ECommerceSystemSettings/CreateGeneralStoreData.cshtml", model);
        }

        //---------------------------GeneralMenusData---------------------------------
        public ActionResult CreateGeneralMenusData(string TaskCode)
        {

            ECommerceSystemSettingsSearchRequest searchRequest = new ECommerceSystemSettingsSearchRequest();
            searchRequest.TaskCode = TaskCode;
            searchRequest.ConnectionString = _connectioString;

            List<ECommerceSystemSettings> EComSystemSettings_SavedMenus = new List<ECommerceSystemSettings>();
            IBaseEntityCollectionResponse<ECommerceSystemSettings> baseEntityCollectionResponse = _ECommerceSystemSettingsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {

                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    EComSystemSettings_SavedMenus = baseEntityCollectionResponse.CollectionResponse.ToList();
                }

            }
            ViewBag.EComSystemSettings_SavedMenus = EComSystemSettings_SavedMenus;

            List<SelectListItem> li_EComSystemSettings_Menus = new List<SelectListItem>();
            li_EComSystemSettings_Menus.Add(new SelectListItem { Text = "Merchandise Group", Value = "1" });
            li_EComSystemSettings_Menus.Add(new SelectListItem { Text = "Department", Value = "2" });
            li_EComSystemSettings_Menus.Add(new SelectListItem { Text = "Category", Value = "3" });
            li_EComSystemSettings_Menus.Add(new SelectListItem { Text = "Sub Category", Value = "4" });
            li_EComSystemSettings_Menus.Add(new SelectListItem { Text = "Base Merchandise Category", Value = "5" });

            ViewBag.EComSystemSettings_Menus = new SelectList(li_EComSystemSettings_Menus, "Value", "Text");
            ECommerceSystemSettingsViewModel model = new ECommerceSystemSettingsViewModel();
            model.TaskCode = TaskCode;

            return PartialView("/Views/Inventory_1/ECommerceSystemSettings/CreateGeneralMenusData.cshtml", model);
        }
        [HttpPost]
        public ActionResult Create(ECommerceSystemSettingsViewModel model)
        {
            try
            {
                if (model != null && model.ECommerceSystemSettingsDTO != null)
                {
                    //GeneralStoreData
                    model.ECommerceSystemSettingsDTO.ConnectionString = _connectioString;
                    model.ECommerceSystemSettingsDTO.EComStoreSettingID = model.EComStoreSettingID;
                    model.ECommerceSystemSettingsDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.ECommerceSystemSettingsDTO.TaskCode = model.TaskCode;
                    //GeneralMenusData
                    model.ECommerceSystemSettingsDTO.EComCategorySettingID = model.EComCategorySettingID;
                    model.ECommerceSystemSettingsDTO.SelectedIDs = model.SelectedIDs;

                    IBaseEntityResponse<ECommerceSystemSettings> response = _ECommerceSystemSettingsServiceAcess.InsertECommerceSystemSettings(model.ECommerceSystemSettingsDTO);
                    model.ECommerceSystemSettingsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.ECommerceSystemSettingsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        // Non-Action Method
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
     
    }
}