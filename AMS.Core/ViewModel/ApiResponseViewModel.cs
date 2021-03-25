using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.ViewModel
{
    public class ApiResponseViewModel
    {

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object ResponseData { get; set; }



        public ApiResponseViewModel(bool isSuccess)
        {
            IsSuccess = isSuccess;
            
        }


        public ApiResponseViewModel(bool isSuccess,string message)
        {
            IsSuccess = isSuccess;
            Message = message;
            
        }

        public ApiResponseViewModel(bool isSuccess, string message,object data)
        {
            IsSuccess = isSuccess;
            Message = message;
            ResponseData = data;
        }



    }
}
