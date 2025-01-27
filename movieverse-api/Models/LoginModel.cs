using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieverse_api.Models
{
    public class LoginResponseModel
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }


        public LoginResponseModel(bool success, int statusCode, string statusMessage)
        {
            Success = success;
            StatusCode = statusCode;
            StatusMessage = statusMessage;
        }
    }
}
