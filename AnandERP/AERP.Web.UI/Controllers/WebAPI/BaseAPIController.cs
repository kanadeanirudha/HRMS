using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Net.Security;

using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Device.Location;
using System.Xml;
using System.Net;
using System.IO;
using AERP.DTO;
using System.Threading;
using System.Configuration;
using AERP.Base.DTO;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI
{
    public class BaseAPIController : ApiController
    {
        #region Check Error
        protected string CheckError(int errorCode)
        {
            string errorMessage = string.Empty;
            switch (errorCode)
            {
                case 200:
                    return "SUCCESS";
                case 505:
                    return "Version Not Supported";
                case 404:
                    return "Invalid Credentials";
                case 405:
                    return "ID is not registered with this device.Contact HR";
                case 100:
                    return "Data Not Found";
                case 101:
                    return "Not Available";
                case 11:
                    return "Duplicate Record";
                case -214:
                    return "Server Not Found";
                default:
                    return "FAILURE";
            }
        }
        #endregion

        protected static DateTime ConvertFromMiliSecondsToDate(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
        protected object SendGCMNotification(string DeviceToken)
        {
            string postDataContentType = "application/json";
            string APIKey = "AAAAjvMWWfg:APA91bGWrUM8PtbO5wWe6AJoeGwQ6MqauMXtxEAKuuqYfAHE7dAxed_AAWFx5myZxOzn-csAsn0PFK_W-TmcNqSwUD5tKWQbVwY45H6t8mlTIlpzJmRSQUUm03Ozluoi2k2H7n-I0lxw";

            string message = "New Call has been Allocated";
            string tickerText = "example test GCM";
            string contentTitle = "content title GCM";
            string postData =
            "{ \"registration_ids\": [ \"" + DeviceToken + "\" ], " +
              "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
                         "\"contentTitle\":\"" + contentTitle + "\", " +
                         "\"message\": \"" + message + "\"}}";


            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };

            //
            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //
            //  CREATE REQUEST
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = postDataContentType;
            Request.Headers.Add(HttpRequestHeader.Authorization, String.Format("key={0}", APIKey));
            Request.UseDefaultCredentials = true;

            Request.ContentLength = byteArray.Length;

            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            //
            //  SEND MESSAGE
            try
            {

                WebResponse Response = Request.GetResponse();

                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    var text = "Unauthorized - need new token";
                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    var text = "Response from web service isn't OK";
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            }
            catch (Exception e)
            {
            }
            return "error";
        }

        public Dictionary<string, Double> getLatLongFromAddress(string address)
        {
            /* var locationService = new GoogleLocationService();
             Thread.Sleep(1000);
             var point = locationService.GetLatLongFromAddress(address);

             var latitude = point.Latitude;
             var longitude = point.Longitude;

             return new Dictionary<string, Double>
             {
                 { "Latitude",latitude },
                 { "Longitude",longitude }
             };*/


            string urlAddress = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + HttpUtility.UrlEncode(address) + "&sensor=false";
            string latitude = "", longitude = "";
            try
            {
                XmlDocument objXmlDocument = new XmlDocument();
                objXmlDocument.Load(urlAddress);
                XmlNodeList objXmlNodeList = objXmlDocument.SelectNodes("/GeocodeResponse/result/geometry/location");
                foreach (XmlNode objXmlNode in objXmlNodeList)
                {
                    // GET LONGITUDE 
                    latitude = objXmlNode.ChildNodes.Item(0).InnerText;

                    // GET LATITUDE 
                    longitude = objXmlNode.ChildNodes.Item(1).InnerText;
                }
                return new Dictionary<string, Double>
                {
                     { "Latitude",Convert.ToDouble(latitude) },
                     { "Longitude",Convert.ToDouble(longitude)}
                };
            }
            catch (Exception e)
            {
                // Process an error action here if needed  
            }

            return new Dictionary<string, Double>
                {
                     { "Latitude",Convert.ToDouble(0) },
                     { "Longitude",Convert.ToDouble(0)}
                };

        }

        public Double getDistanceBetweenTwoLatLong(Dictionary<string, Double> latlongs)
        {
            var DestinationLocation = new GeoCoordinate(latlongs["DestinationLatitude"], latlongs["DestinationLongitude"]);
            var CurrentLocation = new GeoCoordinate(latlongs["CurrentLatitude"], latlongs["CurrentLongitude"]);

            return DestinationLocation.GetDistanceTo(CurrentLocation) / 1000;
        }

        //public ActionResult getData()
        //{
        //    if (ComplaintsRepository.getComplaintsCount() == 1)
        //    {
        //        List<CCRMComplaintLoggingMaster> list = getDeviceToken();
        //        // Dictionary<string, Double> MachineAddress = getLatLongFromAddress(model.MCAddress);
        //        foreach (CCRMComplaintLoggingMaster ComplaintMaster in list)
        //        {
        //            /*   Dictionary<string, Double> latlongs = new Dictionary<string, double>
        //           {
        //               { "DestinationLatitude",MachineAddress["Latitude"] },
        //               { "DestinationLongitude",MachineAddress["Longitude"] },
        //               { "CurrentLatitude",Convert.ToDouble(ComplaintMaster.Latitude) },
        //               { "CurrentLongitude",Convert.ToDouble(ComplaintMaster.Longitude) }
        //           };*/

        //            // if (getDistanceBetweenTwoLatLong(latlongs) < 50)
        //            {
        //                if (ComplaintMaster.DeviceToken != string.Empty)
        //                {
        //                    RunningBackgroundThread(ComplaintMaster.DeviceToken);
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}

        void SendNotification(string DeviceToken)
        {
            SendGCMNotification(DeviceToken);
        }

        void RunningBackgroundThread(string DeviceToken)
        {
            Thread background = new Thread(() => SendNotification(DeviceToken));
            background.IsBackground = true;
            background.Start();
        }

        private List<CCRMComplaintLoggingMaster> getDeviceToken()
        {
            CCRMComplaintLoggingMasterSearchRequest searchRequest = new CCRMComplaintLoggingMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
            ICCRMComplaintLoggingMasterBA _CCRMComplaintLoggingMasterBA = new CCRMComplaintLoggingMasterBA();
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollectionResponse = _CCRMComplaintLoggingMasterBA.GetDeviceToken(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMComplaintLoggingMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMComplaintLoggingMaster;
        }
    }
}