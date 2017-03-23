using SelfService.Model;
using SelfService.Model.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService.Managers.DeviceAPIManager
{
    public interface IDeviceAPIManager
    {
        Task<ObservableCollection<ItemModel>> PostRegistration(string regNumber);
        #region Response
        /// <summary>
        /// 
        /// </summary>
        EttersoktSearchResponse EttersoktSearchResponse { get; }

        #endregion
    }
}
