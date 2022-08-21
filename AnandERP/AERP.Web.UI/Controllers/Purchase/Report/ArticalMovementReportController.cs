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
    public class ArticalReportMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IPurchaseReportMasterBA _PurchaseReportMasterBA = null;
        IGeneralItemMasterBA _generalItemMasterBA = null;
        private readonly ILogger _logException;
        protected static string _uptoDate = string.Empty;
        protected string _centreCode = string.Empty;
        protected static string _fromDate = string.Empty;
        protected static int _balanesheetMstID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ArticalReportMasterController()
        {
            _PurchaseReportMasterBA = new PurchaseReportMasterBA();
            _generalItemMasterBA = new GeneralItemMasterBA();

        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index(string CentreCode)
        {
            PurchaseReportMasterViewModel model = new PurchaseReportMasterViewModel();

            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            //Dropdown for centre
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {

                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode + ":Centre";
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);

                }
            }
            else
            {
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByPurchaseManager(AdminRoleMasterID);
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
            }
            if (!string.IsNullOrEmpty(CentreCode))
            {
                string[] splitCentreCode = CentreCode.Split(':');
                model.CentreCode = splitCentreCode[0];
            }
            return View("/Views/Purchase/Report/ArticalMovementReport/Index.cshtml", model);
        }

        public ActionResult ArticalMovement(string ItemNumber, string CentreCode)
        {
            PurchaseReportMasterViewModel model = new PurchaseReportMasterViewModel();
            model.PurchaseReportMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            model.PurchaseReportMasterDTO.CentreCode = CentreCode;
            if (model.PurchaseReportMasterDTO.ItemNumber > 0)
            {
                model.PurchaseReportMasterDetails = GetPurchaseReportMaster(model.PurchaseReportMasterDTO.ItemNumber, model.PurchaseReportMasterDTO.CentreCode);
            }
            else
            {
                model.PurchaseReportMasterDetails = null;
            }
            return PartialView("/Views/Purchase/Report/ArticalMovementReport/ArticalMovementList.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }

        public List<PurchaseReportMaster> GetPurchaseReportMaster(int Itemnumber, string CentreCode)
        {
            try
            {
                List<PurchaseReportMaster> listPurchaseReportMaster = new List<PurchaseReportMaster>();
                PurchaseReportMasterSearchRequest searchRequest = new PurchaseReportMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ItemNumber = Itemnumber;
                searchRequest.CentreCode = CentreCode;
                //searchRequest.UptoDate = _uptoDate;
                //searchRequest.BalanceSheetID = _balanesheetMstID;
                IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollectionResponse = _PurchaseReportMasterBA.GetArticalMovementReport(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listPurchaseReportMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
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
        [HttpPost]
        public JsonResult GetItemSearchList(string term, string StorageLocationID, string CentreCode)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //   searchRequest.LocationID = Convert.ToInt32(!string.IsNullOrEmpty(StorageLocationID) ? StorageLocationID : null);
            searchRequest.SearchWord = term;

            string[] splitCentreCode = CentreCode.Split(':');
            searchRequest.CentreCode = splitCentreCode[0];

            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _generalItemMasterBA.GetGeneralItemMasterSearchListForReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              itemNumber = r.ItemNumber,
                              //itemDescription = String.Concat(r.ItemDescription, '(', r.UomCode, ')'),
                              itemDescription = r.ItemDescription,
                              barCode = r.BarCode,
                              uomCode = r.UomCode,
                              generalItemCodeID = r.GeneralItemCodeID,
                              id = r.GeneralItemMasterID,
                              orderUomCode = r.OrderUomCode,
                              baseUomCode = r.BaseUOMCode,
                              baseUomQuantity = r.BaseUOMQuantity
                              //  lastPurchasePrice = r.LastPurchasePrice,
                              //  genTaxGroupMasterID = r.GenTaxGroupMasterID,
                              //   PurchaseGroupCode = r.PurchaseGroupCode

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion



    }
}
