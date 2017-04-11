using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicsLibrary.DataModel;
using Newtonsoft.Json;

namespace AcademicsLibrary.NetworkService
{
    public class NetworkService
    {
        private const string BASE_URI_STRING = "http://myffcs.in:8080/campus/";

        private const string LOGIN_STRING_FORMAT = "{0}/login/";
        private const string REFRESH_STRING_FORMAT = "{0}/refresh/";
        private const string COURSEPAGE_STRING_FORMAT = "{0}/coursepage/data/";
        private static Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
        private static Windows.Web.Http.Headers.HttpRequestHeaderCollection headers = httpClient.DefaultRequestHeaders;
        private static Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();


        public static async Task<User> Login(string campus, string reg, string pass)
        {
            string httpResponseBody = "";
            var user = new User(campus, reg, pass);
            try
            {
                var postContent = new Windows.Web.Http.HttpFormUrlEncodedContent(
                                    new KeyValuePair<string, string>[2] {
                                        new KeyValuePair<string, string>("regNo",user.RegNo),
                                        new KeyValuePair<string, string>("psswd",user.Pass),

                                    });
                string uriString = BASE_URI_STRING + String.Format(LOGIN_STRING_FORMAT, campus);
                httpResponse = await httpClient.PostAsync(new Uri(uriString), postContent);
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                User _user = JsonConvert.DeserializeObject<User>(httpResponseBody);                
                //  User __user = JsonConvert.DeserializeObject<User>(httpResponse);               
                var __user = new User(campus, reg, pass,_user.status.code,_user.status.message);
                return _user;

            }

            catch (Exception e)
            {
                var error = new User();
                error.status.code = 5;
                httpResponseBody = "Error: " + e.HResult.ToString("X") + " Message: " + e.Message;
                error.status.message = httpResponseBody;
                return error;
            }
        }
        public static async Task<RefreshModel> Refresh(string campus,string reg,string pass)
        {
            string httpResponseBody = "";
            var user = new User(campus,reg,pass);  
            try
            {
                var postContent = new Windows.Web.Http.HttpFormUrlEncodedContent(
                                    new KeyValuePair<string, string>[2] {
                                        new KeyValuePair<string, string>("regNo",user.RegNo),
                                        new KeyValuePair<string, string>("psswd",user.Pass),

                                    });
                string uriString = BASE_URI_STRING + String.Format(REFRESH_STRING_FORMAT, campus);
                httpResponse = await httpClient.PostAsync(new Uri(uriString), postContent);
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                RefreshModel _refresh = JsonConvert.DeserializeObject<RefreshModel>(httpResponseBody);
                return _refresh;
            }

            catch (Exception e)
            {
                httpResponseBody = "Error: " + e.HResult.ToString("X") + " Message: " + e.Message;
                var x = new RefreshModel();
                return x ;
            }
        }

    }
}
