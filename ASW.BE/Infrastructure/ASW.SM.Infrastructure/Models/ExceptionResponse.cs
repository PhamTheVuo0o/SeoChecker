using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASW.SM.Infrastructure.Models
{
    public class ExceptionResponse : BaseResponse<ExceptionModel>
    {
        public ExceptionResponse(int statusCode, string message, string? details = "") : base(new ExceptionModel(statusCode), false, message, details)
        {
        }
    }
    public class ExceptionModel
    {
        public int StatusCode { get; set; }
        public ExceptionModel(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
