using Microsoft.Extensions.Options;
using BookWeb.Datas.Infrastructure;
using BookWeb.Datas.Infrastructure.Entities;

namespace BookWeb.Datas
{
   

    public class BookData : EntityBaseData<Models.BookModel>
    {
        public BookData(IOptions<DatabaseSettings> dbOptions)
            : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
