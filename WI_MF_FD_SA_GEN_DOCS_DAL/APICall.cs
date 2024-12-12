using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WI_MF_FD_SA_GEN_DOCS_BO
{

    public class APICall
    {
        public APICall()
        {
            //
            // TODO: Add constructor logic here
            //
        }

      
        private static async Task<string> webResponse(HttpWebRequest request)
        {
            try
            {
                string response = string.Empty;
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader Mobile_responseReader = new StreamReader(webStream))
                        {
                            response = Mobile_responseReader.ReadToEnd();
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
        public static string Get_APIResponse(string _req_URL, string _req_JSON, string APIRequestTimeout)
        {
            try
            {
                string response = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_req_URL);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Timeout = Convert.ToInt32(APIRequestTimeout);
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    string json = _req_JSON;
                    requestWriter.Write(json);
                    requestWriter.Flush();
                }

                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader Mobile_responseReader = new StreamReader(webStream))
                        {
                            response = Mobile_responseReader.ReadToEnd();
                        }
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
