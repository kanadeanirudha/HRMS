using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AERP.DTO;
using AERP.ViewModel;
using DotNetOpenAuth.AspNet;
using WebMatrix.WebData;
using System.Configuration;
using AERP.Base.DTO;
using System.Security.Principal;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Http;
using AERP.ExceptionManager;
using AERP.Common;
using AERP.Business.BusinessAction;
namespace AERP.Web.UI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILogger _logException;
        IUserMasterBA _userMasterBA = null;
        IUserMainMenuMasterBA _userMainMenuMasterBA = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountController()
        {
            _userMasterBA = new UserMasterBA();
            _userMainMenuMasterBA = new UserMainMenuMasterBA();
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl, string ProjectName)
        {

            //throw new NullReferenceException("This is error");
            if (ProjectName != null && ProjectName != string.Empty)
                Session["ProjectName"] = Resources.ResourceManager.GetString(String.Concat("DisplayName_", ProjectName.ToUpper()));
            else
                Session["ProjectName"] = ProjectName;

            if (ProjectName == "Faculty")
            {
                Session["ImageName"] = "CoverPage.png";
            }
            else
            {
                Session["ImageName"] = "CoverPage-EIS.jpg";
            }
            ViewBag.ReturnUrl = returnUrl;
            UserMasterViewModel _userMasterViewModel = new UserMasterViewModel();
            _userMasterViewModel.IsActive = false;
            return View(_userMasterViewModel);
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserMasterViewModel model, string returnUrl, string Command)
        {
            try
            {
                if (Command == "Next")
                {
                    ViewBag.ReturnUrl = returnUrl;
                    if (Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["IsManualAttendance"]) == "0")
                    {
                        if (!string.IsNullOrEmpty(model.EmailID) && !string.IsNullOrEmpty(model.Latitude) && !string.IsNullOrEmpty(model.Longitude))
                        {
                            UserMasterViewModel _userMasterViewModel = new UserMasterViewModel();
                            _userMasterViewModel.UserMasterDTO = new UserMaster();
                            _userMasterViewModel.UserMasterDTO.EmailID = model.EmailID;
                            _userMasterViewModel.UserMasterDTO.Latitude = model.Latitude;
                            _userMasterViewModel.UserMasterDTO.Longitude = model.Longitude;
                            _userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
                            IBaseEntityResponse<UserMaster> response = _userMasterBA.SelectByEmailID(_userMasterViewModel.UserMasterDTO);

                            if (response.Entity.ErrorCode != 0)
                            {
                                if (response.Entity.ErrorCode == 11)
                                {
                                    _userMasterViewModel.UserMasterDTO.ErrorMessage = Resources.ErrorMessage_SorrySystemDoesnotRecognizeEmail;
                                }
                                else if (response.Entity.ErrorCode == 3)
                                {
                                    _userMasterViewModel.UserMasterDTO.ErrorMessage = Resources.ErrorMessage_PleaseContactYourAdministrator;
                                }
                                else
                                {
                                    _userMasterViewModel.UserMasterDTO.ErrorMessage = Resources.ErrorMessage_PleaseContactYourAdministrator;
                                }
                                ModelState.AddModelError("", _userMasterViewModel.UserMasterDTO.ErrorMessage);
                                ViewData["errorMsg"] = response.Entity.ErrorMessage;

                                _userMasterViewModel.IsActive = false;
                                return View(_userMasterViewModel);
                            }
                            else
                            {
                                if (response.Entity.DistanceFlag == false)
                                {
                                    if (response.Entity.LoginFlag == false)
                                    {
                                        _userMasterViewModel.AttendanceStatus = response.Entity.AttendanceStatus;
                                        _userMasterViewModel.AttendanceFlag = response.Entity.AttendanceFlag;
                                        _userMasterViewModel.LoginFlag = response.Entity.LoginFlag;
                                        _userMasterViewModel.EmailID = response.Entity.EmailID;
                                        _userMasterViewModel.Status = response.Entity.Status;
                                        ModelState.AddModelError("", Resources.ErrorMessage_YouDonotHavePermissiontoLoginfromoutSidetheCampusArea);
                                    }
                                    else if (response.Entity.LoginFlag == true)
                                    {
                                        _userMasterViewModel.IsActive = response.Entity.IsActive;
                                        _userMasterViewModel.EmailID = response.Entity.EmailID;
                                        _userMasterViewModel.FirstName = response.Entity.FirstName;
                                        _userMasterViewModel.LastName = response.Entity.LastName;
                                        _userMasterViewModel.AttendanceStatus = response.Entity.AttendanceStatus;
                                        _userMasterViewModel.AttendanceFlag = response.Entity.AttendanceFlag;
                                        _userMasterViewModel.LoginFlag = response.Entity.LoginFlag;
                                        _userMasterViewModel.DistanceFlag = response.Entity.DistanceFlag;
                                        _userMasterViewModel.Status = response.Entity.Status;
                                    }
                                }
                                else
                                {
                                    _userMasterViewModel.IsActive = response.Entity.IsActive;
                                    _userMasterViewModel.EmailID = response.Entity.EmailID;
                                    _userMasterViewModel.FirstName = response.Entity.FirstName;
                                    _userMasterViewModel.LastName = response.Entity.LastName;
                                    _userMasterViewModel.AttendanceStatus = response.Entity.AttendanceStatus;
                                    _userMasterViewModel.AttendanceFlag = response.Entity.AttendanceFlag;
                                    _userMasterViewModel.LoginFlag = response.Entity.LoginFlag;
                                    _userMasterViewModel.DistanceFlag = response.Entity.DistanceFlag;
                                    _userMasterViewModel.Status = response.Entity.Status;
                                }
                            }
                            return View(_userMasterViewModel);
                        }
                        if (string.IsNullOrEmpty(model.Latitude) && string.IsNullOrEmpty(model.Longitude))
                        {
                            ModelState.AddModelError("", Resources.ErrorMessage_PleaseShareYourLocation);
                        }
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(model.EmailID))
                        {
                            UserMasterViewModel _userMasterViewModel = new UserMasterViewModel();
                            _userMasterViewModel.UserMasterDTO = new UserMaster();
                            _userMasterViewModel.UserMasterDTO.EmailID = model.EmailID;
                            _userMasterViewModel.UserMasterDTO.Latitude = "21.145800";
                            _userMasterViewModel.UserMasterDTO.Longitude = "79.088155";
                            _userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
                            IBaseEntityResponse<UserMaster> response = _userMasterBA.SelectByEmailID(_userMasterViewModel.UserMasterDTO);

                            if (response.Entity.ErrorCode != 0)
                            {
                                if (response.Entity.ErrorCode == 11)
                                {
                                    _userMasterViewModel.UserMasterDTO.ErrorMessage = Resources.ErrorMessage_SorrySystemDoesnotRecognizeEmail;
                                }
                                else if (response.Entity.ErrorCode == 3)
                                {
                                    _userMasterViewModel.UserMasterDTO.ErrorMessage = Resources.ErrorMessage_PleaseContactYourAdministrator;
                                }
                                else
                                {
                                    _userMasterViewModel.UserMasterDTO.ErrorMessage = Resources.ErrorMessage_PleaseContactYourAdministrator;
                                }
                                ModelState.AddModelError("", _userMasterViewModel.UserMasterDTO.ErrorMessage);
                                ViewData["errorMsg"] = response.Entity.ErrorMessage;

                                _userMasterViewModel.IsActive = false;
                                return View(_userMasterViewModel);
                            }
                            else
                            {
                                //if (response.Entity.DistanceFlag == false)
                                //{
                                _userMasterViewModel.IsActive = response.Entity.IsActive;
                                _userMasterViewModel.EmailID = response.Entity.EmailID;
                                _userMasterViewModel.FirstName = response.Entity.FirstName;
                                _userMasterViewModel.LastName = response.Entity.LastName;
                                _userMasterViewModel.AttendanceStatus = response.Entity.AttendanceStatus;
                                _userMasterViewModel.AttendanceFlag = response.Entity.AttendanceFlag;
                                _userMasterViewModel.LoginFlag = response.Entity.LoginFlag;
                                _userMasterViewModel.DistanceFlag = response.Entity.DistanceFlag;
                                _userMasterViewModel.Status = response.Entity.Status;
                                //if (response.Entity.LoginFlag == true && response.Entity.DistanceFlag == true)
                                //{
                                //    _userMasterViewModel.MarkAttendanceCheckInTime = true;
                                //}
                                //else
                                //{
                                //    _userMasterViewModel.MarkAttendanceCheckInTime = false;
                                //}
                                //}
                            }
                            return View(_userMasterViewModel);
                        }

                    }

                }
                if (Command == "Back")
                {
                    if (!string.IsNullOrEmpty(model.EmailID))
                    {
                        UserMasterViewModel _userMasterViewModel = new UserMasterViewModel();
                        _userMasterViewModel.IsActive = false;
                        _userMasterViewModel.EmailID = model.EmailID;
                        _userMasterViewModel.UserMasterDTO.Latitude = model.Latitude;
                        _userMasterViewModel.UserMasterDTO.Longitude = model.Longitude;
                        return View(_userMasterViewModel);
                    }
                }
                else if (Command == "Submit")
                {
                    string c = "";
                    Session.Contents.RemoveAll();
                    Session.Clear();
                    if (ModelState.IsValid && model != null && !string.IsNullOrEmpty(model.EmailID) && !string.IsNullOrEmpty(model.Password))
                    {
                        UserMasterViewModel _userMasterViewModel = new UserMasterViewModel();

                        SetFormAuthentication(model);
                        SetUserGenericPrincipal();

                        _userMasterViewModel.UserMasterDTO = new UserMaster();
                        _userMasterViewModel.UserMasterDTO.EmailID = model.EmailID;
                        _userMasterViewModel.UserMasterDTO.Password = model.Password;
                        _userMasterViewModel.UserMasterDTO.MarkAttendanceCheckInTime = model.MarkAttendanceCheckInTime;
                        //_userMasterViewModel.UserMasterDTO.MachinName = Convert.ToString(Session["ticket"]);
                        _userMasterViewModel.UserMasterDTO.MachinName = string.Empty;
                        _userMasterViewModel.UserMasterDTO.IP = "192.168.10.1";
                        //_userMasterViewModel.UserMasterDTO.IP = model.IP;
                        _userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;


                        IBaseEntityResponse<UserMaster> response = _userMasterBA.SelectByEmailIDPassword(_userMasterViewModel.UserMasterDTO);
                        if (response.Entity.ErrorMessage != "" && response.Entity.ErrorMessage != null)
                        {
                            _userMasterViewModel.UserMasterDTO.ErrorMessage = response.Entity.ErrorMessage;
                            ModelState.AddModelError("", _userMasterViewModel.UserMasterDTO.ErrorMessage);
                            ViewData["errorMsg"] = response.Entity.ErrorMessage;
                            //return View(model);
                        }
                        else
                            if (response != null && response.Entity != null && response.Entity.ID != 0)
                        {
                            _userMasterViewModel.UserMasterDTO.ID = response.Entity.ID;
                            _userMasterViewModel.UserMasterDTO.EmailID = response.Entity.EmailID;
                            _userMasterViewModel.UserMasterDTO.Password = response.Entity.Password;
                            _userMasterViewModel.UserMasterDTO.UserTypeID = response.Entity.UserTypeID;

                            Session["UserId"] = response.Entity.ID.ToString();
                            Session["UserName"] = response.Entity.FirstName + " " + response.Entity.MiddleName + " " + response.Entity.LastName;
                            Session["PersonId"] = response.Entity.PersonID.ToString();
                            _userMasterViewModel.UserMasterDTO.UserType = response.Entity.UserType;
                            Session["UserType"] = response.Entity.UserType.ToString();
                            Session["EmailID"] = response.Entity.EmailID.ToString();
                            Session["ProfilePhoto"] = response.Entity.ProfilePhoto;
                            Session["ProfilePhotoSize"] = response.Entity.ProfilePhotoSize;
                            Session["DefaultModuleID"] = null;
                            // FormsAuthentication.SetAuthCookie(_userMasterViewModel.UserMasterDTO.EmailID, false);

                            //SetFormAuthentication(_userMasterViewModel);
                            //SetUserGenericPrincipal();

                            Session["TotalRendingNotification"] = 0;
                            string ReturnUrl = string.Empty;
                            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            {
                                Session["DefaultModuleCode"] = response.Entity.LastModuleCode;
                                ReturnUrl = returnUrl.Split('/')[1];
                                //return RedirectToAction("Index",ReturnUrl);
                            }
                            //else
                            //{
                            if (_userMasterViewModel.UserMasterDTO.UserType == 'E')
                            {
                                return RedirectToAction("Index", "Home", new { ReturnUrl = ReturnUrl });
                            }
                            else if (_userMasterViewModel.UserMasterDTO.UserType == 'S')
                            {
                                return RedirectToAction("StudentIndex", "Home", new { ReturnUrl = ReturnUrl });
                            }
                            else if (_userMasterViewModel.UserMasterDTO.UserType == 'A')
                            {
                                return RedirectToAction("Index", "Home", new { ReturnUrl = ReturnUrl });
                            }
                            //}
                        }

                        else
                        {
                            ModelState.AddModelError("", Resources.ErrorMessage_ThisaccountdoesnotexistEnteravalidemailaddressorpassword);
                        }
                    }
                    if (string.IsNullOrEmpty(model.EmailID))
                    {
                        ModelState.AddModelError("", Resources.ErrorMessage_PleaseEnteryouremailaddressintheformats);
                    }


                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]            // resolving session issue with rj
        public ActionResult LogOff(string latitude, string longitude)
        {
            UserMasterViewModel _userMasterViewModel = new UserMasterViewModel();
            _userMasterViewModel.UserMasterDTO.MarkAttendanceCheckOutTime = true;
            var LogoutType = "Successfully";
            _userMasterViewModel.Latitude = latitude;
            _userMasterViewModel.Longitude = longitude;
            _userMasterViewModel.UserMasterDTO.ID = Convert.ToInt32(Session["UserId"]);
            _userMasterViewModel.UserMasterDTO.LogoutType = LogoutType;
            _userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
            string ProjectName = Convert.ToString(Session["ProjectName"]);
            Session.Contents.RemoveAll();

            IBaseEntityResponse<UserMaster> response = _userMasterBA.LogOffByUserID(_userMasterViewModel.UserMasterDTO);
            FormsAuthentication.SignOut();

            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account", new { ProjectName = ProjectName });
            //RedirectToAction("Login", "Account");

            //return PartialView("Login");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        public void SetFormAuthentication(UserMasterViewModel item)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, // Ticket version 
                item.EmailID, // Username to be associated with this ticket 
                DateTime.Now, // Date/time ticket was issued 
                DateTime.Now.AddMinutes(20), // Date and time the cookie will expire 
                item.RememberMe = true, // if user has chcked rememebr me then create persistent cookie 
                item.UserTypeID.ToString(), // store the user data, in this case roles of the user                 
                FormsAuthentication.FormsCookiePath); // Cookie path specified in the web.config file in <Forms> tag if any.

            // To give more security it is suggested to hash it 

            string hashCookies = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies); // Hashed ticket 

            Session["ticket"] = hashCookies;

            // Add the cookie to the response, user browser 
            Response.Cookies.Add(cookie);
        }

        public void SetUserGenericPrincipal()
        {
            HttpCookie httpCookie = HttpContext.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (httpCookie != null)
            {
                FormsAuthenticationTicket formsAuthenticationTicket = FormsAuthentication.Decrypt(httpCookie.Value);
                IIdentity id = new FormsIdentity(formsAuthenticationTicket);
                var astrRoles = formsAuthenticationTicket.UserData.Split(new[] { ',' });
                var principal = new GenericPrincipal(id, astrRoles);
                HttpContext.User = principal;
            }
        }

        public List<UserMainMenuMaster> BuildMenu(int ModuleId)
        {
            UserMainMenuMasterSearchRequest searchRequest = new UserMainMenuMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ModuleID = ModuleId;
            //searchRequest.SearchType = 1;
            List<UserMainMenuMaster> mmList = new List<UserMainMenuMaster>();
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollectionResponse = _userMainMenuMasterBA.GetByModuleID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    mmList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return mmList;
        }
    }
}

