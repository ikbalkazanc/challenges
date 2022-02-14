using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloCase.Core.Models.Requests.Post
{
    public class GetPostPageRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public string CategoryName { get; set; }
    }
}
