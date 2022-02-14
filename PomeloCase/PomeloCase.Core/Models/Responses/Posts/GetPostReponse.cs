using System.Collections.Generic;
using PomeloCase.Core.Model.Dtos.Post;


namespace PomeloCase.Core.Model.Responses.Post
{
    public class GetPostResponse
    {
        public List<PostDto> Posts { get; set; }
    }
}