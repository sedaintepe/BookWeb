using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWeb.Models
{
    public class BookPublishModel:Core.ModelBase
    {
        public BookPublishModel(int bookid,int publishid)
        {
            Bookid = bookid;    
            Publishid = publishid;
        }
        public int Bookid { get; set; }
        public int Publishid { get; set; }
    }
}
