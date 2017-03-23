using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService.Model.Response
{
    public class BaseResponseModel
    {
        //public virtual int ErrorCode { get; set; }

        //public virtual string ErrorMessage { get; set; }

        public int StatusCode { get; set; }

        public string ResponseMessage { get; set; }

        public virtual bool Succeeded { get; set; }

        public BaseResponseModel()
        {
            ResponseMessage = "Network Error";
        }
    }
}
