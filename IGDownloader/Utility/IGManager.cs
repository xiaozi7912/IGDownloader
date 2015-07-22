using IGDownloader.Model;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;

namespace IGDownloader.Utility
{
    class IGManager
    {
        private static String API_BASE_URL = "https://api.instagram.com/v1";
        private static String USER_SEARCH_URL = API_BASE_URL + "/users/search?q={0}&client_id={1}";
        private static String USER_INFO_URL = API_BASE_URL + "/users/{0}?client_id={1}";
        private static String USER_MEDIA_URL = API_BASE_URL + "/users/{0}/media/recent?count={1}&client_id={2}";
        private static int MAX_RETURN = 30;

        private HttpClient mClient = null;
        private String mClientId = null;

        public IGManager()
        {
            mClient = new HttpClient();
            mClientId = System.Configuration.ConfigurationManager.AppSettings["CLIENDID"];
        }

        public delegate void searchResponseHandler(SearchModel result);
        public delegate void userInfoResponseHandler(UserModel result);
        public delegate void mediaResponseHandler(MediaModel result);
        public delegate void pictureResponseHandler(int index, Image result);

        public static IGManager defaultManager()
        {
            return new IGManager();
        }

        public async void getSearchResult(String account, searchResponseHandler handler)
        {
            Console.WriteLine("getSearchResult");
            String requestUrl = String.Format(USER_SEARCH_URL, account, mClientId);
            HttpResponseMessage response = await mClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            String responseBody = await response.Content.ReadAsStringAsync();
            handler.Invoke(JsonConvert.DeserializeObject<SearchModel>(responseBody));
        }

        public async void getUserInfo(String userId, userInfoResponseHandler handler)
        {
            Console.WriteLine("getUserInfo");
            String requestUrl = String.Format(USER_INFO_URL, userId, mClientId);
            HttpResponseMessage response = await mClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            String responseBody = await response.Content.ReadAsStringAsync();
            handler.Invoke(JsonConvert.DeserializeObject<UserModel>(responseBody));
        }

        public async void getUserMedia(String userId, mediaResponseHandler handler)
        {
            Console.WriteLine("getUserMedia");
            String requestUrl = String.Format(USER_MEDIA_URL, userId, MAX_RETURN, mClientId);
            HttpResponseMessage response = await mClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            String responseBody = await response.Content.ReadAsStringAsync();
            handler.Invoke(JsonConvert.DeserializeObject<MediaModel>(responseBody));
        }

        public async void getNextPageMedia(String nextPageUrl, mediaResponseHandler handler)
        {
            Console.WriteLine("getUserMedia");
            HttpResponseMessage response = await mClient.GetAsync(nextPageUrl);
            response.EnsureSuccessStatusCode();
            String responseBody = await response.Content.ReadAsStringAsync();
            handler.Invoke(JsonConvert.DeserializeObject<MediaModel>(responseBody));
        }

        public async void getPicture(int index, String pictureUrl, pictureResponseHandler handler)
        {
            Console.WriteLine("getPicture");
            String requestUrl = pictureUrl;
            HttpResponseMessage response = await mClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            Stream responseStream = await response.Content.ReadAsStreamAsync();
            Image picture = Image.FromStream(responseStream);
            responseStream.Dispose();
            responseStream.Close();
            handler.Invoke(index, picture);
        }
    }
}
