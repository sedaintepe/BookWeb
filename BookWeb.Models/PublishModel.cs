
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWeb.Models
{
    public class PublishModel:Core.ModelBase
    {
        public PublishModel()
        {
            IsActive = false;
            IsDelete = false;
            PublishTime = DateTime.Now;
        }
        public string PublishName { get; set; }
        public string Address { get; set; }
        public DateTime PublishTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
