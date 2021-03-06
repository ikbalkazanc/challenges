using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloCase.Core.Models.Dtos.Post
{
    public class UpdateOrCreatePostDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public List<Guid> CategoryIds { get; set; }
    }
}
