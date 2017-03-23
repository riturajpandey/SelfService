﻿using System;
using System.Collections.Generic;
using System.Linq;
using SelfService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService.Providers.ApiProvider
{
    public interface IApiProvider
    {
        Task<ObservableCollection<ItemModel>> Get<T>(string url, Dictionary<string, string> headers = null);
        ///ApiResult<T> Get<T>(string url, Dictionary<string, string> headers = null);

        /// <summary>
        /// Post to the specified url the body.
        /// </summary>
        /// <param name="url">URL to post to.</param>
        /// <param name="body">Body of post.</param>
        /// <typeparam name="T">The Response type (Jsonable object).</typeparam>
        /// <typeparam name="TR">The RequestType (Jsonable object).</typeparam>
        ApiResult<T> Post<T, TR>(string url, TR body, Dictionary<string, string> headers = null);
        ApiResult<T> Delete<T>(string url, Dictionary<string, string> headers = null);
        ApiResult<T> Put<T, TR>(string url, TR body, Dictionary<string, string> headers = null);

    }
}
