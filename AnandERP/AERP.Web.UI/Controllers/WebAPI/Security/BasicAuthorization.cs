using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AERP.Web.UI
{
    public class BasicAuthorization : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string AuthorizationToken = actionContext.Request.Headers.Authorization.Parameter;
                string DecodedAuthorizationToken = Encoding.UTF8.GetString(Convert.FromBase64String(AuthorizationToken));

                string[] Credentials = DecodedAuthorizationToken.Split(':');
                UserMasterViewModel model = new UserMasterViewModel();
                model.EmailID = Credentials[0];
                model.Password = Credentials[1];

                if (DeviceLoginController.IsValidate(model))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(model.EmailID), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}