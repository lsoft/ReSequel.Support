using Common;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

#nullable enable

namespace TestFiles
{
    public class Unsorted
    {
        public void Check()
        {
            const string a = "select 1";
            string b = "print 2";

            var dbp = new DBProvider();

            dbp.PrepareQuery("print 1", "print 2");

            dbp.SqlText = "select 10 a union all select 20 union all select null";
            dbp.SqlText = "select * from dbo.Station with(index=ix_unknown_index)";
            dbp.SqlText = a;
            dbp.SqlText = b;
            dbp.SqlText = a + b;

            //ReSequel: MUTE next query everywhere
            dbp.ExecuteNonQuery(@"
IF NOT EXISTS (
    SELECT id FROM MY_TABLE WITH (NOLOCK)
    WHERE 1 = 0
)
begin
    insert into MY_TABLE (id, name) values (1)

    SELECT SCOPE_IDENTITY() t_newID
end
");

            dbp.ExecuteNonQuery(@"
--comment 1
select
    1, --1
    2  --2
");

            dbp.ExecuteNonQuery(a);
            dbp.UnrelatedMethod("some unrelated string");
            dbp.ExecuteNonQuery(@"select 1 a union all select 2 a");
            dbp.UnrelatedMethod("some unrelated string");
            dbp.ExecuteNonQuery(@"select 111 a " + "union all " + "select 222 a");

            dbp.ExecuteNonQuery(@"
select
	*
from sys.tables
where
    '20210101' > dateadd( YEAR, -1, '20210101' )
");


            dbp.ExecuteNonQuery(@"
select
    *
from master.INFORMATION_SCHEMA.TABLES
where
	TABLE_NAME = @val
	and TABLE_SCHEMA = @val
");

            dbp.ExecuteNonQuery(@"
select
    *
from master.INFORMATION_SCHEMA.TABLES
where
	1 = @val1
	and getdate() = @val2
");

            dbp.ExecuteNonQuery(@"
declare @var2 datetime

select
    *
from master.INFORMATION_SCHEMA.TABLES
where
	1 = @val1
	and getdate() = @val2
");
        }

    }
}
