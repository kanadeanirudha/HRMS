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
    public class ItemHistoryReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IInventoryReportBA _InventoryReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _ItemDescription = string.Empty;
        protected static string _UptoDate = string.Empty;
        protected static string _FromDate = string.Empty;
        protected static int _GeneralItemMasterID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ItemHistoryReportController()
        {
            _InventoryReportBA = new InventoryReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            InventoryReportViewModel model = new InventoryReportViewModel();
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
            model.ListGetAdminRoleApplicableCentre = GetAdminRoleApplicableCentreBySalesManager(AdminRoleMasterID);

            return View("/Views/Inventory/Report/ItemHistoryReport/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(InventoryReportViewModel model)
        {

            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
            model.ListGetAdminRoleApplicableCentre = GetAdminRoleApplicableCentreBySalesManager(AdminRoleMasterID);

            if (model.IsPosted == true)
            {
                _centreCode = model.CentreCode;
                _centreName = model.CentreName;
                _ItemDescription = model.ItemDescription;
                _GeneralItemMasterID = model.GeneralItemMasterID;
                _FromDate = model.FromDate;
                _UptoDate = model.UptoDate;

                model.IsPosted = false;
            }
            else
            {
                model.CentreCode = _centreCode;
                model.CentreName = _centreName;
                model.ItemDescription = _ItemDescription;
                model.GeneralItemMasterID = _GeneralItemMasterID;
                model.FromDate = _FromDate;
                model.UptoDate = _UptoDate;
            }

            return View("/Views/Inventory/Report/ItemHistoryReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<AdminRoleApplicableDetails> GetCentreListByRoleAuthorization()
        {
            InventoryReportViewModel model = new InventoryReportViewModel();
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

        public List<InventoryReport> GetItemHistoryReportList()
        {
            try
            {
                List<InventoryReport> listInventoryReport = new List<InventoryReport>();
                InventoryReportSearchRequest searchRequest = new InventoryReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                
                if (_centreCode != string.Empty && _GeneralItemMasterID != 0)
                {
                    searchRequest.CentreCode = _centreCode;
                    searchRequest.CentreName = _centreName;
                    searchRequest.GeneralItemMasterID = _GeneralItemMasterID;
                    searchRequest.ItemDescription = _ItemDescription;
                    searchRequest.FromDate = _FromDate;
                    searchRequest.UptoDate = _UptoDate;

                    IBaseEntityCollectionResponse<InventoryReport> baseEntityCollectionResponse = _InventoryReportBA.GetItemHistoryReportList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listInventoryReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listInventoryReport;
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
