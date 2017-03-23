using SelfService.Managers.SettingManager;
using SelfService.Model;
using SelfService.Model.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SelfService.Providers.ApiProvider
{
    public class ApiProvider : IApiProvider
    {
        private readonly HttpClient _httpClient;
        List<ItemModel> Items { get; set; }
        public ApiProvider()
        {
            var authData = string.Format("{0}:{1}", SettingsManager.Username, SettingsManager.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            HttpClientHandler handler = new HttpClientHandler();

            _httpClient = new HttpClient(handler);
            TimeSpan ts = TimeSpan.FromMilliseconds(1000000);
            _httpClient.Timeout = ts;
            _httpClient.MaxResponseContentBufferSize = 99999999;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }
        public async Task<ObservableCollection<ItemModel>> Get<T>(string url, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage result = null;
            try
            {
                lock (_httpClient)
                {
                    if (headers != null)
                    {
                        AddHeadersToClient(headers);
                    }
                    result = _httpClient.GetAsync(url).Result;
                    if (headers != null)
                    {
                        RemoveHeadersFromClient(headers);
                    }
                }

                var rawResult = result.Content.ReadAsStringAsync().Result;

                try
                {
                    //var deserialized = JsonConvert.DeserializeObject<T>(rawResult);
                    //var deserialized = JsonConvert.DeserializeObject<ItemModel>(rawResult);
                    ObservableCollection<ItemModel> itemlist = JsonConvert.DeserializeObject<ObservableCollection<ItemModel>>(rawResult);
                    //return new ApiResult<T>(rawResult, (int)result.StatusCode, Activator.CreateInstance<T>());
                    return itemlist;
                }
                catch (Exception ex)
                {
                    //return new ApiResult<T>(rawResult, 501, Activator.CreateInstance<T>());
                    return null;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Message is :-" + e.Message);
            }
            return null;
            //return new ApiResult<T>(null, null != result ? (int)result.StatusCode : 0, default(T));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        /*public ApiResult<T> Get<T>(string url, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage result = null;
            try
            {
                lock (_httpClient)
                {
                    if (headers != null)
                    {
                        AddHeadersToClient(headers);
                    }
                    result = _httpClient.GetAsync(url).Result;
                    if (headers != null)
                    {
                        RemoveHeadersFromClient(headers);
                    }
                }

                var rawResult = result.Content.ReadAsStringAsync().Result;

                try
                {
                    //var deserialized = JsonConvert.DeserializeObject<T>(rawResult);
                    //var deserialized = JsonConvert.DeserializeObject<List<ItemModel>>(rawResult);
                    return new ApiResult<T>(rawResult, (int)result.StatusCode, Activator.CreateInstance<T>());
                }
                catch (Exception ex)
                {
                    return new ApiResult<T>(rawResult, 501, Activator.CreateInstance<T>());
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Message is :-" + e.Message);
            }

            //return new ApiResult<T>(null, null != result ? (int)result.StatusCode : 0, default(T));
            return null;
        }*/

        /// <summary>
        /// Post to the specified url the body.
        /// </summary>
        /// <param name="url">URL to post to.</param>
        /// <param name="body">Body of post.</param>
        /// <typeparam name="T">The Response type (return type) (Jsonable object).</typeparam>
        /// <typeparam name="TR">The RequestType (the body) (Jsonable object).</typeparam>
        public ApiResult<T> Post<T, TR>(string url, TR body, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage result = null;
            try
            {
                lock (_httpClient)
                {
                    if (headers != null)
                    {
                        AddHeadersToClient(headers);
                    }
                    //var x = JsonConvert.SerializeObject(body);
                    result = _httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")).Result;
                    if (headers != null)
                    {
                        RemoveHeadersFromClient(headers);
                    }
                }

                var rawResult = result.Content.ReadAsStringAsync().Result;
                try
                {
                    var deserialized = JsonConvert.DeserializeObject<T>(rawResult);
                    return new ApiResult<T>(rawResult, (int)result.StatusCode, deserialized);
                }
                catch (Exception ex)
                {
                    return new ApiResult<T>(rawResult, 501, Activator.CreateInstance<T>());
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Message is :-" + e.Message);
            }

            return new ApiResult<T>(null, null != result ? (int)result.StatusCode : 0, default(T));
        }

        public ApiResult<T> Delete<T>(string url, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage result = null;
            try
            {
                lock (_httpClient)
                {
                    if (headers != null)
                    {
                        AddHeadersToClient(headers);
                    }
                    result = _httpClient.DeleteAsync(url).Result;
                    if (headers != null)
                    {
                        RemoveHeadersFromClient(headers);
                    }
                }

                var rawResult = result.Content.ReadAsStringAsync().Result;
                try
                {
                    var deserialized = JsonConvert.DeserializeObject<T>(rawResult);
                    return new ApiResult<T>(rawResult, (int)result.StatusCode, deserialized);
                }
                catch (Exception ex)
                {
                    return new ApiResult<T>(rawResult, 501, Activator.CreateInstance<T>());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Message is :-" + e.Message);
            }

            return new ApiResult<T>(null, null != result ? (int)result.StatusCode : 0, default(T));
        }

        public ApiResult<T> Put<T, TR>(string url, TR body, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage result = null;
            try
            {
                lock (_httpClient)
                {
                    if (headers != null)
                    {
                        AddHeadersToClient(headers);
                    }
                    result = _httpClient.PutAsync(url, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")).Result;
                    if (headers != null)
                    {
                        RemoveHeadersFromClient(headers);
                    }
                }

                var rawResult = result.Content.ReadAsStringAsync().Result;

                try
                {
                    var deserialized = JsonConvert.DeserializeObject<T>(rawResult);
                    return new ApiResult<T>(rawResult, (int)result.StatusCode, deserialized);
                }
                catch (Exception ex)
                {
                    return new ApiResult<T>(rawResult, 501, Activator.CreateInstance<T>());
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Message is :-" + e.Message);
            }

            return new ApiResult<T>(null, null != result ? (int)result.StatusCode : 0, default(T));
        }

        void AddHeadersToClient(Dictionary<string, string> headers)
        {
            foreach (var kv in headers)
            {

                _httpClient.DefaultRequestHeaders.Add(kv.Key, kv.Value);
            }
        }

        void RemoveHeadersFromClient(Dictionary<string, string> headers)
        {
            foreach (var kv in headers)
            {
                _httpClient.DefaultRequestHeaders.Remove(kv.Key);
            }
        }

    }
}
