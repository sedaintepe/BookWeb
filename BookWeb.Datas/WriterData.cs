using Microsoft.Extensions.Options;
using BookWeb.Datas.Infrastructure;
using BookWeb.Datas.Infrastructure.Entities;

namespace BookWeb.Datas
{


    public class WriterData : EntityBaseData<Models.WriterModel>
    {
        public WriterData(IOptions<DatabaseSettings> dbOptions)
            : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}