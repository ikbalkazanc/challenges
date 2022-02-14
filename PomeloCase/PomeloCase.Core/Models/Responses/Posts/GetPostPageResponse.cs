using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomeloCase.Core.Model.Dtos.Category;
using PomeloCase.Core.Model.Dtos.Post;
using PomeloCase.Core.Models.Dtos.Post;

namespace PomeloCase.Core.Model.Responses.Posts
{
    public class GetPostPageResponse
    {
        public List<PostPageDto> Posts { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public CategoryDto Category { get; set; }
    }
}
