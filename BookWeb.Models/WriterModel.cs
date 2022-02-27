using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWeb.Models
{
    public class WriterModel:Core.ModelBase
    {
        public WriterModel()
        {
            IsActive = false;
            IsDelete = false;
            
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string About { get; set; }
      
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
