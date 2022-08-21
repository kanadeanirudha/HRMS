using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
using AERP.Business.BusinessActions;
namespace AERP.Web.UI.Controllers
{
    public class GeneralItemMissingExceptionReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IInventoryReportBA _InventoryReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        public string _ReportFor { get; set; }
        protected static string _ReportForPage;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public GeneralItemMissingExceptionReportController()
        {
            _InventoryReportBA = new InventoryReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
       
        public ActionResult Index()
        {
            InventoryReportViewModel model = new InventoryReportViewModel();

            List<SelectListItem> ItemReportList = new List<SelectListItem>();
            ViewBag.ItemReportList = new SelectList(ItemReportList, "Value", "Text");
            List<SelectListItem> li_ItemReportList = new List<SelectListItem>();

            li_ItemReportList.Add(new SelectListItem { Text = "All", Value = "All" });
            //li_ItemReportList.Add(new SelectListItem { Text = "Restaurant", Value = "RestaurantDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "Category Details", Value = "CategoryDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "UOM Details", Value = "UOMDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "Vendor Details", Value = "VendorDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "Sale Details", Value = "SaleDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "Store Details", Value = "StoreDetails" });

            ViewData["ItemReportList"] = li_ItemReportList;

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory/Report/GeneralItemMissingExceptionReport/Index.cshtml", model);
        }
       [HttpPost]
        public ActionResult Index(InventoryReportViewModel model)
        {
            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            if (model.IsPosted == true)
            {
                model.IsPosted = false;

                _centreCode = model.CentreCode;
                _centreName = model.CentreName;
                _ReportForPage = model.ItemReportList;
            }
            else
            {
                model.ItemReportList = Convert.ToString(_ReportForPage);
                model.CentreCode = _centreCode;
                model.CentreName = _centreName;
            }
            if (model.ItemReportList == null)
            {
                model.ItemReportList = "All";
            }
            model.ListInventoryReport = GetMissingExceptionReportList((model.ItemReportList));

            List<SelectListItem> ItemReportList = new List<SelectListItem>();
            ViewBag.ItemReportList = new SelectList(ItemReportList, "Value", "Text");
            List<SelectListItem> li_ItemReportList = new List<SelectListItem>();

            li_ItemReportList.Add(new SelectListItem { Text = "All", Value = "All" });
       //     li_ItemReportList.Add(new SelectListItem { Text = "Restaurant", Value = "RestaurantDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "Category Details", Value = "CategoryDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "UOM Details", Value = "UOMDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "Vendor Details", Value = "VendorDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "Sale Details", Value = "SaleDetails" });
            li_ItemReportList.Add(new SelectListItem { Text = "Store Details", Value = "StoreDetails" });

            ViewData["ItemReportList"] = new SelectList(li_ItemReportList, "Value", "Text", (model.InventoryReportDTO.ItemReportList).ToString().Trim()); 
            model.ReportFor = model.ItemReportList;

           

            return View("/Views/Inventory/Report/GeneralItemMissingExceptionReport/Index.cshtml", model);
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

           List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByPurchaseManager(AdminRoleMasterID);
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

        public List<InventoryReport> GetMissingExceptionReportList( string ReportFor)
        {
            try
            {
                List<InventoryReport> listInventoryReport = new List<InventoryReport>();
                InventoryReportSearchRequest searchRequest = new InventoryReportSearchRequest();
                searchRequest.ReportFor = ReportFor;
                searchRequest.CentreCode = _centreCode;
                searchRequest.CentreName = _centreName;
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<InventoryReport> baseEntityCollectionResponse = _InventoryReportBA.GetInventoryReportBySearch_PriceList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryReport = baseEntityCollectionResponse.CollectionResponse.ToList();
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
