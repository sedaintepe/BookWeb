using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using BookWeb.Datas.Infrastructure;
using BookWeb.Datas.Infrastructure.Entities;

namespace BookWeb.Datas
{


    public class MemberData : EntityBaseData<Models.MemberModel>
    {
        public MemberData(IOptions<DatabaseSettings> dbOptions)
            : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}