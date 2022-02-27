using Microsoft.Extensions.Options;
using BookWeb.Datas.Infrastructure;
using BookWeb.Datas.Infrastructure.Entities;

namespace BookWeb.Datas
{


    public class MediaData : EntityBaseData<Models.MediaModel>
    {
        public MediaData(IOptions<DatabaseSettings> dbOptions)
            : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
