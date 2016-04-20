using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HuyangReservation
{
    internal class GcmManager
    {
        private const string ApiKey = "AIzaSyCcFDylElWuJkVPvG688WXPxYttV8GHoGM";

        private const string DeviceId = "APA91bEjnv2-SfcFU441y__4LZycOmHNUFN9hBjsi24B3QRyTXT6sQ4TcL8ehpvX9Sn74B9UkOiIFI-Amj-mMOJDhjOL5mvhzohW-n41bbR8BDVO9ChuQjG7VXJ2tv-O5fWeAq8I21_AgF5_2DHMAKV1CuIYfrMtcA";

        private const string TickerText = "cmaping GCM";

        public string SendNotification(string message, string contentTitle)
        {
            var postData =
                "{ \"registration_ids\": [ \"" + DeviceId + "\" ], " +
                "\"data\": {\"GameName\":\"" + TickerText + "\", " +
                "\"FTitle\":\"" + contentTitle + "\", " +
                "\"FContent\":\"" + contentTitle + "\", " +
                "\"PromotionCopy\": \"" + message + "\"}}";
            var response = SendGCMNotification(ApiKey, postData);
            return response;
        }


        /// <summary>
        ///     Send a Google Cloud Message. Uses the GCM service and your provided api key.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="postData"></param>
        /// <param name="postDataContentType"></param>
        /// <returns>The response string from the google servers</returns>
        private string SendGCMNotification(string apiKey, string postData,
            string postDataContentType = "application/json")
        {
            ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertificate;

            //
            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //
            //  CREATE REQUEST
            var Request = (HttpWebRequest) WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = postDataContentType;
            Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
            Request.ContentLength = byteArray.Length;

            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            //
            //  SEND MESSAGE
            try
            {
                var response = Request.GetResponse();
                var responseCode = ((HttpWebResponse) response).StatusCode;
                if (responseCode.Equals(HttpStatusCode.Unauthorized) || responseCode.Equals(HttpStatusCode.Forbidden))
                {
                    string text = "Unauthorized - need new token";
                }
                else if (!responseCode.Equals(HttpStatusCode.OK))
                {
                    string text = "Response from web service isn't OK";
                }

                var reader = new StreamReader(response.GetResponseStream());
                var responseLine = reader.ReadToEnd();
                reader.Close();

                return responseLine;
            }
            catch (Exception e)
            {
            }
            return "error";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        private static bool ValidateServerCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}