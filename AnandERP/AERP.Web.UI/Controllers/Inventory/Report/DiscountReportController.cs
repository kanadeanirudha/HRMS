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
    public class DiscountReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRetailReportsServiceAccess _RetailReportsServiceAccess = null;
        ISalePromotionPlanAndDetailsServiceAccess _SalePromotionPlanAndDetailsServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _dateFrom = string.Empty;
        protected static string _dateTo = string.Empty;
        protected static string _DiscountInPercent=string.Empty;
        protected static string _DiscountType = string.Empty;
        protected static string _ReportForPage;
        protected static string _CentreCode = string.Empty;
        protected static string _CentreName = string.Empty;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public DiscountReportController()
        {
            _RetailReportsServiceAccess = new RetailReportsServiceAccess();
            _SalePromotionPlanAndDetailsServiceAccess = new SalePromotionPlanAndDetailsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            RetailReportsViewModel model = new RetailReportsViewModel();

            List<SalePromotionPlanAndDetails> GeneralUnits = GetDiscountInPercent();
            List<SelectListItem> DiscountList = new List<SelectListItem>();

            DiscountList.Add(new SelectListItem { Text = "All", Value = "0~All~False" });

            foreach (SalePromotionPlanAndDetails item in GeneralUnits)
            {
                DiscountList.Add(new SelectListItem { Text = Convert.ToString(item.DiscountInPercent) + " " + Convert.ToString(item.type), Value = Convert.ToString(item.DiscountInPercent) + "~" + Convert.ToString(item.type) + "~" + Convert.ToString(item.IsPercentage) });
            }
            ViewBag.DiscountList = new SelectList(DiscountList, "Value", "Text");

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory_1/Report/DiscountReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(RetailReportsViewModel model)
        {

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            if (model.IsPosted == true)
            {
                _dateFrom = model.DateFrom;
                _dateTo = model.DateTo;
                _DiscountInPercent = model.DiscountInPercent;
                _DiscountType = model.DiscountType;
                _CentreCode = model.CentreCode;
                _CentreName = model.CentreName;
                model.IsPosted = false;
            }
            else
            {
                model.DiscountInPercent = _DiscountInPercent;
                model.DateFrom = _dateFrom;
                model.DateTo = _dateTo;
                model.DiscountType = _DiscountType;
                model.CentreCode = _CentreCode;
                model.CentreName = _CentreName;
            }

            List<SalePromotionPlanAndDetails> GeneralUnits = GetDiscountInPercent();
            List<SelectListItem> DiscountList = new List<SelectListItem>();

            DiscountList.Add(new SelectListItem { Text = "All", Value = "0~All~False" });
            foreach (SalePromotionPlanAndDetails item in GeneralUnits)
            {
                DiscountList.Add(new SelectListItem { Text = Convert.ToString(item.DiscountInPercent) + " " + Convert.ToString(item.type), Value = Convert.ToString(item.DiscountInPercent) + "~" + Convert.ToString(item.type) + "~" + Convert.ToString(item.IsPercentage) });
            }
            ViewBag.DiscountList = new SelectList(DiscountList, "Value", "Text", model.DiscountInPercent + " " + Convert.ToString(model.type));

            return View("/Views/Inventory_1/Report/DiscountReport/Index.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        protected List<SalePromotionPlanAndDetails> GetDiscountInPercent()
        {
            SalePromotionPlanAndDetailsSearchRequest searchRequest = new SalePromotionPlanAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalePromotionPlanAndDetails> ListGeneralUnits = new List<SalePromotionPlanAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> baseEntityCollectionResponse = _SalePromotionPlanAndDetailsServiceAccess.GetDiscountInPercentLIst(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            } 
            return ListGeneralUnits;
        }

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

        public List<RetailReports> GetDiscountReportList()
        {
            try
            {
                List<RetailReports> listRetailReports = new List<RetailReports>();
                RetailReportsSearchRequest searchRequest = new RetailReportsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                if (_dateFrom != string.Empty && _dateTo != string.Empty)
                {
                    searchRequest.DateFrom = _dateFrom;
                    searchRequest.DateTo = _dateTo;
                    searchRequest.DiscountInPercent = _DiscountInPercent;
                    string accnm = searchRequest.DiscountInPercent;
                    string[] accnmArray = accnm.Split('~');
                    searchRequest.DiscountInPercent = Convert.ToString(accnmArray[0]);
                    searchRequest.IsPercentage = Convert.ToBoolean(accnmArray[2]);

                    searchRequest.DiscountType = _DiscountType;
                    searchRequest.CentreCode = _CentreCode;
                    searchRequest.CentreName = _CentreName;

                    IBaseEntityCollectionResponse<RetailReports> baseEntityCollectionResponse = _RetailReportsServiceAccess.GetInventoryDiscountReportBySearch(searchRequest);
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
