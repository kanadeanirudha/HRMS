using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
using AERP.Business.BusinessActions;
namespace AERP.Web.UI.Controllers
{
    public class VendorMasterReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IVendorMasterReportBA _VendorMasterReportBA = null;
        private readonly ILogger _logException;
        protected static int _vendorID;
        protected string _centreCode = string.Empty;
        private short _VendorID;
        public string  _ReportFor { get; set; }
        protected static string _ReportForPage;
        //public string ListAllVendor { get; set; }

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public VendorMasterReportController()
        {
            _VendorMasterReportBA = new VendorMasterReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            VendorMasterReportViewModel model = new VendorMasterReportViewModel();
          //  model.ListAllVendor = GetVendorList(ReportFor);

            List<SelectListItem> VendorReportList = new List<SelectListItem>();
            ViewBag.VendorReportList = new SelectList(VendorReportList, "Value", "Text");
            List<SelectListItem> li_VendorReportList = new List<SelectListItem>();

            li_VendorReportList.Add(new SelectListItem { Text = "All", Value = "All" });
            li_VendorReportList.Add(new SelectListItem { Text = "Vendor Restriction", Value = "VendorRestriction" });
            li_VendorReportList.Add(new SelectListItem { Text = "Replenishment Category", Value = "ReplenishmentCategory" });
            li_VendorReportList.Add(new SelectListItem { Text = "Contact Person", Value = "ContactPerson" });

            ViewData["VendorReportList"] = li_VendorReportList;

            return View("/Views/Inventory/Report/VendorMaster/Index.cshtml",model);
        }
        [HttpPost]
        public ActionResult Index(VendorMasterReportViewModel model)
        {

            if (model.IsPosted == true)
            {
                model.IsPosted = false;
                _ReportForPage = model.VendorReportList;
            }
            else
            {
                model.VendorReportList = Convert.ToString(_ReportForPage);
            }
            if (model.VendorReportList == null)
            {
                model.VendorReportList = "All";
            }
            ListAllVendor = GetVendorList((model.VendorReportList));


             List<SelectListItem> VendorReportList = new List<SelectListItem>();
             ViewBag.VendorReportList = new SelectList(VendorReportList, "Value", "Text");
             List<SelectListItem> li_VendorReportList = new List<SelectListItem>();

             li_VendorReportList.Add(new SelectListItem { Text = "All", Value = "All" });
             li_VendorReportList.Add(new SelectListItem { Text = "Vendor Restriction", Value = "VendorRestriction" });
             li_VendorReportList.Add(new SelectListItem { Text = "Replenishment Category", Value = "ReplenishmentCategory" });
             li_VendorReportList.Add(new SelectListItem { Text = "Contact Person", Value = "ContactPerson" });

             ViewData["VendorReportList"] = new SelectList(li_VendorReportList, "Value", "Text", (model.VendorMasterReportDTO.VendorReportList).ToString().Trim()); 
            model.ReportFor=model.VendorReportList;

            return View("/Views/Inventory/Report/VendorMaster/Index.cshtml",model);
        }

       
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<VendorMasterReport> GetVendorList(string ReportFor)
        {
            try
            {
                List<VendorMasterReport> listVendorMasterReport = new List<VendorMasterReport>();
                VendorMasterReportSearchRequest searchRequest = new VendorMasterReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ReportFor = ReportFor;
                IBaseEntityCollectionResponse<VendorMasterReport> baseEntityCollectionResponse = _VendorMasterReportBA.GetVendorMasterReportBySearch_AllVendorList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listVendorMasterReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listVendorMasterReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
      

        #endregion



        public string ReportFor { get; set; }



       public List<VendorMasterReport> ListAllVendor { get; set; }
    }
}
