using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Infoset.Core.Response
{
    public class BaseResponse<Object> where Object : class
    {
        public bool Status { get; set; } = true;
        public Object Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
