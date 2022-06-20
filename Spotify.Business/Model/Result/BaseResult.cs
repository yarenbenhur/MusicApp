using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business.Model.Result
{
    public class BaseResult
    {
        public int StatusCode { get; set; }
        public string ResultMessage { get; set; }

        public BaseResult() { }
        public BaseResult(int statusCode, string message)
        {
            StatusCode = statusCode;
            ResultMessage = message;
        }
    }
}
