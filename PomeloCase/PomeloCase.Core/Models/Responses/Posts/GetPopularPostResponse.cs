using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomeloCase.Core.Models.Dtos.Post;

namespace PomeloCase.Core.Models.Responses.Posts
{
    public class GetPopularPostResponse
    {
        public GetPopularPostResponse()
        {
            Posts = new List<PopularPostDto>();
        }
        public List<PopularPostDto> Posts { get; set; }
    }
}
