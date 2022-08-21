using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using AERP.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using System.Web.Mvc.Ajax;
using System.IO;

namespace AERP.Web.UI.Controllers
{
    public class InventoryPurchaseStockReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IPurchaseReportMasterBA _PurchaseReportMasterBA = null;
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;

        private readonly ILogger _logException;
        protected static string _uptoDate = string.Empty;
        protected string _centreCode = string.Empty;
        protected static string _fromDate = string.Empty;
        protected static int _balanesheetMstID;
        protected static string _LocationName = string.Empty;
        protected static int _LocationID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryPurchaseStockReportController()
        {
            _PurchaseReportMasterBA = new PurchaseReportMasterBA();
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        [HttpGet]
        public ActionResult Index()
        {
            PurchaseReportMasterViewModel model = new PurchaseReportMasterViewModel();
            //---------------------------For Inventory Location List-------------------------//
            _fromDate = string.Empty;
            _uptoDate = string.Empty;
            _LocationID = 0;
            _LocationName = string.Empty;
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<InventoryLocationMaster> inventoryLocationList = GetInventoryLocationMasterList(AdminRoleMasterID);
            model.ListInventoryLocationMaster = inventoryLocationList;
            model.PurchaseReportMasterDTO.BalancesheetID = Convert.ToInt32(Session["BalancesheetID"]);
            return View("/Views/Purchase/Report/InventoryPurchaseStockReport/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(PurchaseReportMasterViewModel model)
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

            List<InventoryLocationMaster> inventoryLocationList = GetInventoryLocationMasterList(AdminRoleMasterID);
            model.ListInventoryLocationMaster = inventoryLocationList;
            model.PurchaseReportMasterDTO.BalancesheetID = Convert.ToInt32(Session["BalancesheetID"]);

            if (model.IsPosted == true)
            {
                model.IsPosted = false;

                _fromDate = model.FromDate;
                _uptoDate = model.UptoDate;
                _LocationID = model.LocationID;
                _LocationName = model.LocationName;
            }
            else
            {
                model.FromDate = _fromDate;
                model.UptoDate = _uptoDate;
                model.LocationID = _LocationID;
                model.LocationName = _LocationName;
            }

            return View("/Views/Purchase/Report/InventoryPurchaseStockReport/Index.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }
        [NonAction]
        protected List<InventoryLocationMaster> GetInventoryLocationMasterList(int UserID)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.UserID = Convert.ToInt32(UserID);
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterlistCenterCodeWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        public List<PurchaseReportMaster> GetInventoryPurchaseStockReport()
        {
            try
            {
                List<PurchaseReportMaster> listPurchaseReportMaster = new List<PurchaseReportMaster>();
                PurchaseReportMasterSearchRequest searchRequest = new PurchaseReportMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                if (!string.IsNullOrEmpty(_fromDate) && !string.IsNullOrEmpty(_uptoDate) && _LocationID > 0)
                {
                    searchRequest.FromDate = _fromDate;
                    searchRequest.UptoDate = _uptoDate;
                    searchRequest.LocationID = _LocationID;
                    searchRequest.LocationName = _LocationName;
                    //searchRequest.BalanceSheetID = _balanesheetMstID;
                    IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollectionResponse = _PurchaseReportMasterBA.GetInventoryPurchaseStockReport(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listPurchaseReportMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listPurchaseReportMaster;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //_headID = 0;
                //_categoryID = 0;
                //_groupID = 0;
                //   _balanesheetMstID = 0;
            }

        }

        #endregion



    }
}
