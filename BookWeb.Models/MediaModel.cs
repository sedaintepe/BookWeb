using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWeb.Models
{
    public class MediaModel:Core.ModelBase
    {
        public string FileUrl { get; set; }
        public string FileName { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }

    }
}
