using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SelfService.Model.Response
{
    public class EttersoktSearchResponse : BaseResponseModel
    {
        //public bool success;
        //public ItemModel detail;
        //public List<ItemModel> list { get; set; }
        public ObservableCollection<ItemModel> list { get; set; }
    }
}
