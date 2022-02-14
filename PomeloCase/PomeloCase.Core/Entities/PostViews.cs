using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PomeloCase.Core.Entities
{
    public class PostViews
    {
        public Guid Id { get; set; }
        public int ViewsCount { get; set; }
        [ForeignKey("Post")]
        public Guid PostId { get; set; }
    }
}
