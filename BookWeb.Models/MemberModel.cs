using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWeb.Models
{
    public class MemberModel:Core.ModelBase
    {
        public MemberModel()
        {
            IsActive = false;
            IsDelete = false;
        }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
