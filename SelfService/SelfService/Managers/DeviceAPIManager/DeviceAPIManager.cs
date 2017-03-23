using SelfService.Managers.SettingManager;
using SelfService.Model;
using SelfService.Model.Response;
using SelfService.Providers.ApiProvider;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService.Managers.DeviceAPIManager
{
    public class DeviceAPIManager : IDeviceAPIManager
    {
        #region Property
        /// <summary>
        /// Class Level varriable declaration.
        /// </summary>
        private readonly IApiProvider _apiProvider;
        private readonly ISettingsManager _settingsManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Call to API Manager Method
        /// </summary>
        /// <param name="apiProvider"></param>
        /// <param name="settingsManager"></param>
        public DeviceAPIManager(IApiProvider apiProvider, ISettingsManager settingsManager)
        {
            _apiProvider = apiProvider;
            _settingsManager = settingsManager;
        }
        #endregion
        public async Task<ObservableCollection<ItemModel>> PostRegistration(string regNumber)
        {
            bool IsNetwork = IsConnected();
            if (IsNetwork)
            {
                var url = string.Format("{0}{1}", _settingsManager.ApiHost, regNumber);
                return await _apiProvider.Get<ObservableCollection<ItemModel>>(url);
            }
            else
            {
                BaseResponseModel error = new BaseResponseModel { ResponseMessage = "Please check your internet connection!" };
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /*public void GetItemsBySearch(Action success, Action<BaseResponseModel> failed)
        {
            bool IsNetwork = IsConnected();
            if (IsNetwork)
            {

                var url = string.Format("{0}", _settingsManager.ApiHost, "");
                //var result = _apiProvider.Get<EttersoktSearchResponse>(url);
                ettersoktSearchResponse.list = _apiProvider.Get1<ObservableCollection<ItemModel>>(url);
                if (result.IsSuccessful)
                {

                    if (result.Result.Succeeded == true || result.RawResult.Length>0)
                    {
                        ettersoktSearchResponse = result.Result;
                        ettersoktSearchResponse.list = JsonConvert.DeserializeObject<ObservableCollection<ItemModel>>(result.RawResult);
                        

                        success.Invoke();
                    }
                    else
                    {
                        failed.Invoke(result.Result);
                    }
                    
                }
                else
                {
                    failed.Invoke(result.Result);
                }

            }
            else
            {
                BaseResponseModel error = new BaseResponseModel { ResponseMessage = "Please check your internet connection!" };
                failed.Invoke(error);
            }

        }*/

        #region Response
        private EttersoktSearchResponse ettersoktSearchResponse;
        public EttersoktSearchResponse EttersoktSearchResponse
        {
            get { return ettersoktSearchResponse; }
        }
        #endregion

        #region Connectivity
        /// <summary>
        /// TODO : Get Network Connection.
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            //var networkConnection = CrossConnectivity.Current.IsConnected;
            //return networkConnection;
            return true;
        }
        #endregion
    }
}
