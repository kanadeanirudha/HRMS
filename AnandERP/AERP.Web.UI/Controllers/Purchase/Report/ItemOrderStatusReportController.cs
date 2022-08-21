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
    public class ItemOrderStatusReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IPurchaseReportMasterServiceAccess _PurchaseReportMasterServiceAccess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        protected static Int16 _generalUnitsID;
        protected static string _ReportForPage;
        protected static string ListAllUnits;
        protected static string _centreName = string.Empty;
        protected static string _GeneralUnitsName = string.Empty;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ItemOrderStatusReportController()
        {
            _PurchaseReportMasterServiceAccess = new PurchaseReportMasterServiceAccess();
            _GeneralUnitsServiceAccess = new GeneralUnitsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            PurchaseReportMasterViewModel model = new PurchaseReportMasterViewModel();

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Purchase/Report/ItemOrderStatusReport/Index.cshtml", model);

           
        }
        [HttpPost]
        public ActionResult Index(PurchaseReportMasterViewModel model)
        {

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            if (model.IsPosted == true)
            {
                _generalUnitsID = model.GeneralUnitsID;
                _centreCode = model.CentreCode;
                _centreName = model.CentreName;
                _GeneralUnitsName = model.GeneralUnitsName;
                model.ListGeneralUnits = GetGeneralUnitsByCentreCode(_centreCode);

                model.IsPosted = false;
            }
            else
            {

                model.GeneralUnitsID = _generalUnitsID;
                model.CentreCode = _centreCode;
                model.CentreName = _centreName;
                model.GeneralUnitsName = _GeneralUnitsName;
                model.ListGeneralUnits = GetGeneralUnitsByCentreCode(_centreCode);
            }
            return View("/Views/Purchase/Report/ItemOrderStatusReport/Index.cshtml", model);
        
        }


        #region ------------CONTROLLER NON ACTION METHODS------------
        // Dropdown for General Units

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

        public List<GeneralUnits> GetGeneralUnitsByCentreCode(string centreCode)
        {
            try
            {
                List<GeneralUnits> listGeneralUnits = new List<GeneralUnits>();
                GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = !string.IsNullOrEmpty(centreCode) ? centreCode.Split(':')[0] : string.Empty;
                IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsServiceAccess.GetGeneralUnitsByCentreCode(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listGeneralUnits;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public List<PurchaseReportMaster> GetItemOrderList()
        {
            try
            {
                List<PurchaseReportMaster> listPurchaseReportMaster = new List<PurchaseReportMaster>();
                PurchaseReportMasterSearchRequest searchRequest = new PurchaseReportMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                //if (_generalUnitsID > 0 && _generalUnitsID != null)
                searchRequest.GeneralUnitsID = _generalUnitsID;
                searchRequest.GeneralUnitsName = _GeneralUnitsName;
                searchRequest.CentreName = _centreName;
                IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollectionResponse = _PurchaseReportMasterServiceAccess.GetItemOrderStatusList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listPurchaseReportMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listPurchaseReportMaster;
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

        #endregion































