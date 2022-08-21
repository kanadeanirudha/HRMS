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
    public class InventoryDaysOfCoverReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRetailReportsServiceAccess _RetailReportsServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryDaysOfCoverReportController()
        {
            _RetailReportsServiceAccess = new RetailReportsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            RetailReportsViewModel model = new RetailReportsViewModel();
            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();
            return View("/Views/Inventory_1/Report/InventoryDaysOfCoverReport/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(RetailReportsViewModel model)
        {
            try
            {
                model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

                if (model.IsPosted == true)
                {
                    _centreCode = model.CentreCode;
                    model.IsPosted = false;
                }
                else
                {
                    model.CentreCode = _centreCode;
                }
                return View("/Views/Inventory_1/Report/InventoryDaysOfCoverReport/Index.cshtml", model);
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
                a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                a.CentreName = item.CentreName;
                model.ListGetAdminRoleApplicableCentre.Add(a);
            }
            return model.ListGetAdminRoleApplicableCentre;
        }

        public List<RetailReports> GetInventoryDaysOfCoverReportList()
        {
            try
            {
                List<RetailReports> listRetailReports = new List<RetailReports>();
                RetailReportsSearchRequest searchRequest = new RetailReportsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                if (!string.IsNullOrEmpty(_centreCode))
                {
                    searchRequest.CentreCode = _centreCode.Split(':')[0];
                    IBaseEntityCollectionResponse<RetailReports> baseEntityCollectionResponse = _RetailReportsServiceAccess.GetInventoryDaysOfCoverReportBySearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listRetailReports = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listRetailReports;
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
