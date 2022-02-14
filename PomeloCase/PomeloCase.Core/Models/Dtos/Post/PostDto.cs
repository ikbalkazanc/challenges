using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using PomeloCase.Core.Model.Dtos.Category;

namespace PomeloCase.Core.Model.Dtos.Post
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public List<CategoryDto> Categories { get; set; }

        public int PostViews { get; set; }

        public DateTime CreateDate { get; set; }
        public string AuthorMail { get; set; }
    }
}