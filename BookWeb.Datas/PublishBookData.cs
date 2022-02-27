using Microsoft.Extensions.Options;
using BookWeb.Datas.Infrastructure;
using BookWeb.Datas.Infrastructure.Entities;

namespace BookWeb.Datas
{


    public class PublishBookData : EntityBaseData<Models.BookPublishModel>
    {
        public PublishBookData(IOptions<DatabaseSettings> dbOptions)
            : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}