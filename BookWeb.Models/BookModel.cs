
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWeb.Models
{
    public class BookModel:Core.ModelBase
    {
        public BookModel()
        {
            IsActive = false;
            IsDelete = false;
            PublishDate= DateTime.Now;
        }
       
        public int writerId { get; set; }
        public virtual WriterModel Writer { get; set; }
        public int mediaId { get; set; }
        public virtual MediaModel Media { get; set; }
        public GenreEnum GenreEnum { get; set; }
        public int PageCount { get; set; }
        public string BookName { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public virtual List<BookPublishModel> BookPublishModels { get; set; }
    }
}

