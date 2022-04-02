using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFiles
{
    public class Async
    {
        public async Task CheckAsync()
        {
            var dbp = new DBProvider();

            //sqlserver:
            Task.Run(
                async () =>
                {
                    await dbp.ExecuteQueryAsync("print 1");
                });

            //sqlserver:
            dbp.ExecuteQueryAsync("print 1")
                .GetAwaiter()
                .GetResult()
                ;

            //sqlserver:
            await dbp.ExecuteQueryAsync("print 1");

            //postgresql, system.data.sqlite, microsoft.data.sqlite:
            await dbp.ExecuteQueryAsync(@"
select
    *
from ""stations""
where
    id = @id
");

            //postgresql, microsoft.data.sqlite:
            await dbp.ExecuteQueryAsync(@"
select
    @a::integer;
select
    @b::timestamp;
");

            //postgresql, sqlserver, system.data.sqlite, microsoft.data.sqlite:
            await dbp.ExecuteQueryAsync(@"
select
    1
where
    1 = @my_value;
");

            //postgresql, sqlserver, system.data.sqlite, microsoft.data.sqlite:
            await dbp.ExecuteQueryAsync(@"
select
    1
where
    'a' = @my_value;
");

            //postgresql, sqlserver:
            await dbp.ExecuteQueryAsync(@"
select
    *
from INFORMATION_SCHEMA.COLUMNS
where
    Ordinal_Position between 1 and 2
");

            //empty (play with completion):
            await dbp.ExecuteQueryAsync(@"
select * FROM
");
        }

    }
}
