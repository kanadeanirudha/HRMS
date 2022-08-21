using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;

namespace AERP.Web.UI.Controllers
{
    public class AdminRoleDetailsController : BaseController
    {

        IAdminRoleDetailsBA _adminRoleDetailsBA = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AdminRoleDetailsController()
        {
            _adminRoleDetailsBA = new AdminRoleDetailsBA();
        }

        #region Controller Methods

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            //System.Threading.Thread.Sleep(1000);
            IEnumerable<AdminRoleDetailsViewModel> model = GetAdminRoleDetails();
            return PartialView("List", model);
        }

        public ActionResult Create()
        {
            AdminRoleDetailsViewModel model = new AdminRoleDetailsViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(AdminRoleDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.AdminRoleDetailsDTO != null)
                {
                    model.AdminRoleDetailsDTO.ConnectionString = _connectioString;
                    model.AdminRoleDetailsDTO.AdminRoleMasterID = 5;
                    model.AdminRoleDetailsDTO.CreatedBy = 1;
                    model.AdminRoleDetailsDTO.CreatedDate = DateTime.Now;
                    model.AdminRoleDetailsDTO.ModifiedBy = null;
                    model.AdminRoleDetailsDTO.ModifiedDate = null;
                    model.AdminRoleDetailsDTO.DeletedBy = null;
                    model.AdminRoleDetailsDTO.DeletedDate = null;
                    model.AdminRoleDetailsDTO.IsDeleted = false;
                    IBaseEntityResponse<AdminRoleDetails> response = _adminRoleDetailsBA.InsertAdminRoleDetails(model.AdminRoleDetailsDTO);
                }
                return Content(Boolean.TrueString);
                //return List();
            }
            else
            {
                return Content("Please review your form");
            }
        }

        public ActionResult Edit(int id)
        {
            AdminRoleDetailsViewModel model = new AdminRoleDetailsViewModel();

            model.AdminRoleDetailsDTO = new AdminRoleDetails();
            model.AdminRoleDetailsDTO.ID = id;
            model.AdminRoleDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<AdminRoleDetails> response = _adminRoleDetailsBA.SelectByID(model.AdminRoleDetailsDTO);

            if (response != null && response.Entity != null)
            {
                model.AdminRoleDetailsDTO.ID = response.Entity.ID;
                model.AdminRoleDetailsDTO.AdminRoleMasterID = response.Entity.AdminRoleMasterID;
                model.AdminRoleDetailsDTO.CreatedBy = response.Entity.CreatedBy;
                model.AdminRoleDetailsDTO.CreatedDate = response.Entity.CreatedDate;
                model.AdminRoleDetailsDTO.IsActive = response.Entity.IsActive;
                model.AdminRoleDetailsDTO.AdminRoleCode = response.Entity.AdminRoleCode;
            }

            return PartialView(model);
        }

        public ActionResult Details(int id)
        {
            AdminRoleDetailsViewModel model = new AdminRoleDetailsViewModel();

            model.AdminRoleDetailsDTO = new AdminRoleDetails();
            model.AdminRoleDetailsDTO.ID = id;
            model.AdminRoleDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<AdminRoleDetails> response = _adminRoleDetailsBA.SelectByID(model.AdminRoleDetailsDTO);

            if (response != null && response.Entity != null)
            {
                model.AdminRoleDetailsDTO.ID = response.Entity.ID;
                model.AdminRoleDetailsDTO.IsActive = response.Entity.IsActive;
                model.AdminRoleDetailsDTO.AdminRoleCode = response.Entity.AdminRoleCode;
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(AdminRoleDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.AdminRoleDetailsDTO != null)
                {
                    if (model != null && model.AdminRoleDetailsDTO != null)
                    {
                        model.AdminRoleDetailsDTO.ConnectionString = _connectioString;
                        model.AdminRoleDetailsDTO.AdminRoleMasterID = model.AdminRoleMasterID;
                        model.AdminRoleDetailsDTO.CreatedBy = model.CreatedBy;
                        model.AdminRoleDetailsDTO.CreatedDate = model.CreatedDate;
                        model.AdminRoleDetailsDTO.ModifiedBy = 1;
                        model.AdminRoleDetailsDTO.ModifiedDate = DateTime.Now;
                        model.AdminRoleDetailsDTO.DeletedBy = null;
                        model.AdminRoleDetailsDTO.DeletedDate = null;
                        model.AdminRoleDetailsDTO.IsDeleted = false;
                        IBaseEntityResponse<AdminRoleDetails> response = _adminRoleDetailsBA.UpdateAdminRoleDetails(model.AdminRoleDetailsDTO);
                    }
                }

                return Content(Boolean.TrueString);
            }
            else
            {
                return Content("Please review your form");
            }
        }


        public ActionResult Delete(int ID)
        {

            AdminRoleDetailsViewModel model = new AdminRoleDetailsViewModel();

            model.AdminRoleDetailsDTO = new AdminRoleDetails();
            model.AdminRoleDetailsDTO.ID = ID;
            model.AdminRoleDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<AdminRoleDetails> response = _adminRoleDetailsBA.SelectByID(model.AdminRoleDetailsDTO);

            if (response != null && response.Entity != null)
            {
                model.AdminRoleDetailsDTO.ID = response.Entity.ID;
                model.AdminRoleDetailsDTO.IsActive = response.Entity.IsActive;
                model.AdminRoleDetailsDTO.AdminRoleCode = response.Entity.AdminRoleCode;
            }

            return PartialView(model);
        }



        [HttpPost]
        public ActionResult Delete(AdminRoleDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    AdminRoleDetails adminRoleDetailsDTO = new AdminRoleDetails();
                    adminRoleDetailsDTO.ConnectionString = _connectioString;
                    adminRoleDetailsDTO.ID = model.ID;
                    IBaseEntityResponse<AdminRoleDetails> response = _adminRoleDetailsBA.DeleteAdminRoleDetails(adminRoleDetailsDTO);
                }
                return Content(Boolean.TrueString);
            }
            else
            {
                return Content("Admin role Not deleted. Please try again.");
            }
        }


        #endregion

        #region Methods

        public IEnumerable<AdminRoleDetailsViewModel> GetAdminRoleDetails()
        {
            AdminRoleDetailsSearchRequest searchRequest = new AdminRoleDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<AdminRoleDetailsViewModel> listAdminRoleDetailsViewModel = new List<AdminRoleDetailsViewModel>();
            List<AdminRoleDetails> listAdminRoleDetails = new List<AdminRoleDetails>();
            IBaseEntityCollectionResponse<AdminRoleDetails> baseEntityCollectionResponse = _adminRoleDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (AdminRoleDetails item in listAdminRoleDetails)
                    {
                        AdminRoleDetailsViewModel adminRoleDetailsViewModel = new AdminRoleDetailsViewModel();
                        adminRoleDetailsViewModel.AdminRoleDetailsDTO = item;
                        listAdminRoleDetailsViewModel.Add(adminRoleDetailsViewModel);
                    }
                }
                else if (baseEntityCollectionResponse.Message != null && baseEntityCollectionResponse.Message.Count > 0)
                {
                    IMessageDTO errordto = baseEntityCollectionResponse.Message.FirstOrDefault();                    
                }
            }
            return listAdminRoleDetailsViewModel;
        }

        #endregion
        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            var allAdminRoleDetails = GetAdminRoleDetails();
            IEnumerable<AdminRoleDetailsViewModel> filteredAdminRoleDetails;
            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
               
                var AdminRoleCodeFilter = Convert.ToString(Request["sSearch_1"]);
                var IsActiveFilter = Convert.ToString(Request["sSearch_2"]);  

                //Optionally check whether the columns are searchable at all 
              
                var isAdminRoleCodeSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isIsActiveSearchable = Convert.ToBoolean(Request["bSearchable_2"]);

                filteredAdminRoleDetails = GetAdminRoleDetails()
                   .Where(c =>
                               isAdminRoleCodeSearchable && c.AdminRoleCode.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isIsActiveSearchable && c.IsActive.ToString().Contains(param.sSearch.ToLower()));
            }
            else
            {
                filteredAdminRoleDetails = allAdminRoleDetails;
            }
            var isAdminRoleCode = Convert.ToBoolean(Request["bSortable_1"]);
            var isIsActive = Convert.ToBoolean(Request["bSortable_2"]);        
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<AdminRoleDetailsViewModel, string> orderingFunction = (c =>
                                                           sortColumnIndex == 0 && isAdminRoleCode ? c.AdminRoleCode :
                                                           sortColumnIndex == 1 && isIsActive ? c.IsActive.ToString() :

                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredAdminRoleDetails = filteredAdminRoleDetails.OrderBy(orderingFunction);
            else
                filteredAdminRoleDetails = filteredAdminRoleDetails.OrderByDescending(orderingFunction);

            var displayedCaste = filteredAdminRoleDetails.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCaste select new[] { c.AdminRoleCode.ToString(), c.IsActive.ToString(), Convert.ToString(c.ID) };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allAdminRoleDetails.Count(),
                iTotalDisplayRecords = filteredAdminRoleDetails.Count(),
                aaData = result
            },
                        JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
